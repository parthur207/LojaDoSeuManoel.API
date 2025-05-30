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
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetTopFiveSalesAdmin();


        //Commands
        Task<ResponseModel<SimpleResponseModel>> CreateProductGameAdmin(CreateProductGameModel model);
        Task<SimpleResponseModel> UpdateProductStatusToUnavailableAdmin(int ProductGameId);
        Task<SimpleResponseModel> UpdateProductStatusToAvailableAdmin(int ProductGameId);
        Task<SimpleResponseModel> UpdateStockTotalAdmin(int ProductGameID, int NewStock);
        Task<SimpleResponseModel> UpdateDimensionsProductGame(int ProductGameID,  decimal n1, decimal n2, decimal n3);
        Task<SimpleResponseModel> DeleteProductGameAdmin(int ProductGameID);


    }
}
