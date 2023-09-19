using Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BoilerPlate.DbConnector
{
    public static class ReflectionHelper
    {
        const string InsertFormat = "INSERT INTO {0} ({1}) VALUES ({2});";
        const string UpdateFormat = "UPDATE {0} SET {1} WHERE {2}";
        const string DeleteFormat = "DELETE FROM {0} WHERE {1}";
        const string IdWhereCondition = "Id = @Id";
        const string SelectByIdWithColumnsFormat = "SELECT {0} FROM {1} WHERE {2};";
        const string SelectAllFormat = "SELECT {0} FROM {1};";

        public static Tuple<string, DynamicParameters> GetCreateStatement<T>(this T entity)
        {
            var properties = GetPropertyInfos(typeof(T));
            string columns = string.Empty;
            string columnValues = string.Empty;
            var parameters = new DynamicParameters();

            foreach (var property in properties)
            {
                var propertyName = GetNameFromProperty(property);
                if (IsPrimaryKey(property))
                {
                    continue;
                }

                columns += $"{propertyName},";
                columnValues += $"@{propertyName},";
                parameters.Add(propertyName, property.GetValue(entity));
            }

            columns = columns.TrimEnd(',');
            columnValues = columnValues.TrimEnd(',');
            return new Tuple<string, DynamicParameters>(string.Format(InsertFormat, new string[] { GetTableName<T>(), columns, columnValues }), parameters);
        }

        public static Tuple<string, DynamicParameters> GetUpdateStatement<T>(this T entity)
        {
            var properties = GetPropertyInfos(typeof(T));
            string columns = string.Empty;
            var parameters = new DynamicParameters();

            foreach (var property in properties)
            {
                var propertyName = GetNameFromProperty(property);
                if (IsPrimaryKey(property))
                {
                    parameters.Add(propertyName, property.GetValue(entity));
                    continue;
                }
                columns += $"{propertyName} = @{propertyName},";
                parameters.Add(propertyName, property.GetValue(entity));
            }

            columns = columns.TrimEnd(',');
            return new Tuple<string, DynamicParameters>(string.Format(UpdateFormat, new string[] { GetTableName<T>(), columns, IdWhereCondition }), parameters);
        }

        public static Tuple<string, DynamicParameters> GetDeleteStatement<T>(this object idValue)
        {
            var idProperty = GetIdProperty(typeof(T));
            var parameters = new DynamicParameters();
            parameters.Add(idProperty.Name, idValue);

            return new Tuple<string, DynamicParameters>(string.Format(DeleteFormat, new string[] { GetTableName<T>(), IdWhereCondition }), parameters);
        }

        public static Tuple<string, DynamicParameters> GetSelectStatement<T>(this object idValue)
        {
            var idProperty = GetIdProperty(typeof(T));
            var parameters = new DynamicParameters();
            parameters.Add(idProperty.Name, idValue);

            var properties = GetPropertyInfos(typeof(T));
            string columns = string.Empty;

            foreach (var property in properties)
            {
                var propertyName = GetNameFromProperty(property);
                columns += $"{propertyName} as {property.Name},";
            }

            columns = columns.TrimEnd(',');
            return new Tuple<string, DynamicParameters>(string.Format(SelectByIdWithColumnsFormat, new string[] { columns, GetTableName<T>(), IdWhereCondition }), parameters);
        }

        public static string GetSelectAllStatement<T>()
        {
            var properties = GetPropertyInfos(typeof(T));
            string columns = string.Empty;

            foreach (var property in properties)
            {
                var propertyName = GetNameFromProperty(property);
                columns += $"{propertyName} as {property.Name},";
            }

            columns = columns.TrimEnd(',');
            return string.Format(SelectAllFormat, new string[] { columns, GetTableName<T>() });
        }

        private static PropertyInfo GetIdProperty(Type type)
        {
            return GetPropertyInfos(type).FirstOrDefault(x => IsPrimaryKey(x));
        }

        private static PropertyInfo[] GetPropertyInfos(Type type)
        {
            return GetPropertyInfos(type, BindingFlags.Public | BindingFlags.Instance);
        }

        private static PropertyInfo[] GetPropertyInfos(Type type, BindingFlags bindingFlags)
        {
            return type.GetProperties(bindingFlags);
        }

        private static bool IsPrimaryKey(PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes();
            if (attributes == null || attributes.Count() == 0)
            {
                return propertyInfo.Name.Equals("Id", StringComparison.InvariantCultureIgnoreCase);
            }

            return attributes.Any(x => x is KeyAttribute);
        }

        private static string GetNameFromProperty(PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes();
            if (attributes == null || attributes.Count() == 0)
            {
                return propertyInfo.Name;
            }

            var nameAttribute = attributes.FirstOrDefault(x => x is JsonPropertyNameAttribute);
            if (nameAttribute == null)
            {
                return propertyInfo.Name;
            }
            return (nameAttribute as JsonPropertyNameAttribute).Name;
        }

        private static string GetTableName<T>()
        {
            var attributes = typeof(T).GetCustomAttributes();
            if (attributes == null || attributes.Count() == 0)
            {
                return typeof(T).Name;
            }

            var tableAttribute = attributes.FirstOrDefault(x => x is TableAttribute);
            if (tableAttribute == null)
            {
                return typeof(T).Name;
            }

            return (tableAttribute as TableAttribute).Name;
        }
    }
}
