using API_Netcore_Data_Productos_MySQL.NetCore_Cafe_Soluble.Model;

namespace NetCore_Cafe_Soluble.Data.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProductos();
        Task<Producto> GetDetails(int id);
        Task<bool> InsertProducto(Producto producto);
        Task<bool> UpdateProducto(Producto producto);
        Task<bool> DeleteProducto(Producto producto);
    }
}
