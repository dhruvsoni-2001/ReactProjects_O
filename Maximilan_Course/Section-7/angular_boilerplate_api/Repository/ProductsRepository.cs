using AutoMapper;
using BoilerPlate.DbConnector;
using BoilerPlate.Models;
using BoilerPlate.Request.Products;
using BoilerPlate.Request.User;
using BoilerPlate.Response;
using BoilerPlate.Response.Products;
using BoilerPlate.Response.User;

namespace BoilerPlate.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DatabaseExecutor databaseExecutor;
        private readonly IMapper mapper;

        public ProductsRepository(DatabaseExecutor _databaseExecutor, IMapper _mapper)
        {
            databaseExecutor = _databaseExecutor;
            mapper = _mapper;
        }

        public BaseTotalRecordResponse<ProductsResponse> GetProducts(int limit, int start, string? search, string order_col, string order_by)
        {
            var products = databaseExecutor.GetAll<Products>();
            var response = new BaseTotalRecordResponse<ProductsResponse>()
            {
                Response = new List<ProductsResponse>(),
            };

            if (!string.IsNullOrWhiteSpace(search))
            {
                products = products.Where(x => x.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            response.RecordsTotal = products.Count();

            if (!string.IsNullOrWhiteSpace(order_col))
            {
                if (order_col.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    products = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? products.OrderBy(x => x.Name) : products.OrderByDescending(x => x.Name);
                }
                else
                {
                    products = order_by.Equals("Asc", StringComparison.OrdinalIgnoreCase) ? products.OrderBy(x => x.Id) : products.OrderByDescending(x => x.Id);
                }
            }

            products = products.Skip(start).Take(limit);

            foreach (var product in products)
            {
                response.Response.Add(mapper.Map<Products, ProductsResponse>(product));
            }

            return response;
        }

        public ProductsResponse GetProductById(int id)
        {
            var product = databaseExecutor.GetById<Products>(id);
            product.Id = id;
            return mapper.Map<Products, ProductsResponse>(product);
        }

        public ProductsResponse CreateProduct(CreateProductRequest createProductRequest)
        {
            var data = mapper.Map<CreateProductRequest, Products>(createProductRequest);
            var id = databaseExecutor.Create(data);
            data.Id = id;
            data.CreatedAt = DateTime.Now;
            return mapper.Map<Products, ProductsResponse>(data);
        }

        public UpdateProductResponse UpdateProduct(int id, CreateProductRequest updateProductRequest)
        {
            var updateProduct = databaseExecutor.GetById<Products>(id);
            updateProduct.Name = updateProductRequest.Name;
            updateProduct.UpdatedAt = DateTime.Now;
            databaseExecutor.Update(updateProduct);
            return mapper.Map<Products, UpdateProductResponse>(updateProduct);
        }

        public void DeleteProduct(int id)
        {
            databaseExecutor.Delete<Products>(id);
        }

        public UpdatedStatusResponse UpdateStatus(int id, UpdatedStatusRequest updatedStatusRequest)
        {
            var data = databaseExecutor.GetById<Products>(id);
            data.Status = updatedStatusRequest.Status;
            databaseExecutor.Update(data);
            return new UpdatedStatusResponse() { Status = updatedStatusRequest.Status };
        }
    }
}
