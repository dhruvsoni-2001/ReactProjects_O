using BoilerPlate.Request.Products;
using BoilerPlate.Request.User;
using BoilerPlate.Response;
using BoilerPlate.Response.Products;
using BoilerPlate.Response.User;

namespace BoilerPlate.Repository
{
    public interface IProductsRepository
    {
        public BaseTotalRecordResponse<ProductsResponse> GetProducts(int limit, int start, string? search, string order_col, string order_by);
        
        public ProductsResponse GetProductById(int id);
        
        public ProductsResponse CreateProduct(CreateProductRequest createProductRequest);
        
        public UpdateProductResponse UpdateProduct(int id, CreateProductRequest updateProductRequest);
        
        public void DeleteProduct(int id);

        public UpdatedStatusResponse UpdateStatus(int id, UpdatedStatusRequest updatedStatusRequest);
    }
}
