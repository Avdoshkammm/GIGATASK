namespace GIGATASK.Interfaces
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAllProducts();
        Task<T> GetProductById(int id);
        Task<T> CreateProduct(T entity);
        Task<T> UpdateProduct(T entity, int id);
        Task<T> DeleteProduct(int id, T entity);
    }
}