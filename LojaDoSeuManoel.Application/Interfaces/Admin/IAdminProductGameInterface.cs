using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.Admin;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;

namespace LojaDoSeuManoel.Application.Interfaces.Admin
{
    public interface IAdminProductGameInterface
    {
        //Querys
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllProductGameAdmin();
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByNameOrDescriptionAdmin(string ItemOfQuery);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByStatusAdmin(ProductGameStatusEnum status);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByCategoryAdmin(ProductGameCategoryEnum category);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByPriceAdmin(decimal Price);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameNoStockAdmin();
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameInactiveAdmin();

        //Vendas
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesAdmin();
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesByCategoryAdmin(ProductGameCategoryEnum category);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetTopFiveSalesAdmin(ProductGameCategoryEnum category);


        //Commands
        Task<ResponseModel<SimpleResponseModel>> CreateProductGameAdmin(CreateProductGameModel model);
        Task<SimpleResponseModel> UpdateDataProductGameAdmin(int ProductGameID, UpdateProductGameModel model);
        Task<ResponseModel<SimpleResponseModel>> UpdateStockTotalAdmin(int ProductGameID, int NewStock);
        Task<ResponseModel<SimpleResponseModel>> UpdateStatusProductGameAdmin(ProductGameStatusEnum NewStatus);
    }
}
