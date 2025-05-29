using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.Admin;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository
{
    public interface IProductGameRepository
    {
        //Querys
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllProductGameAsync();
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByNameOrDescriptionAsync(string ItemOfQuery);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByStatusAsync(ProductGameStatusEnum status);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByCategoryAsync(ProductGameCategoryEnum category);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByPriceAsync(decimal Price);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameNoStockAsync();
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameInactiveAsync();

        //Vendas
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesAsync();
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesByCategoryAsync(ProductGameCategoryEnum category);
        Task<ResponseModel<List<ProductGameAdminDTO>?>> GetTopFiveSalesAsync(ProductGameCategoryEnum category);


        //Commands
        Task<ResponseModel<SimpleResponseModel>> CreateProductGameAsync(CreateProductGameModel model);
        Task<SimpleResponseModel> UpdateDataProductGameAsync(int ProductGameID, UpdateProductGameModel model);
        Task<ResponseModel<SimpleResponseModel>> UpdateStockTotalAsync(int ProductGameID, int NewStock);
        Task<ResponseModel<SimpleResponseModel>> UpdateStatusProductGameAsync(ProductGameStatusEnum NewStatus);
    }
}
