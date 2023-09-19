namespace BoilerPlate.Response.User
{
    /// <summary>
    /// This Class is used for Creating User Response Data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CreateUserResponseData<T>
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public CreateUserResponseData()
        {
            Data = (T)Activator.CreateInstance(typeof(T));
        }
    }
}
