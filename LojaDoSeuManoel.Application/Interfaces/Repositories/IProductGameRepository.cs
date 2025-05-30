using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Entities;
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
        Task<ResponseModel<List<ProductGameEntity>?>> GetAllProductGameAsync();
        Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByNameOrDescriptionAsync(string ItemOfQuery);
        Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByStatusAsync(ProductGameStatusEnum status);
        Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByCategoryAsync(ProductGameCategoryEnum category);
        Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByPriceAsync(decimal Price);
        Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameNoStockAsync();
        Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameInactiveAsync();

        //Vendas
        Task<ResponseModel<List<ProductGameEntity>?>> GetAllSalesAsync();
        Task<ResponseModel<List<ProductGameEntity>?>> GetAllSalesByCategoryAsync(ProductGameCategoryEnum category);
        Task<ResponseModel<List<ProductGameEntity>?>> GetTopFiveSalesAsync(ProductGameCategoryEnum category);


        //Commands
        Task<SimpleResponseModel> CreateProductGameAsync(ProductGameEntity model);
        Task<SimpleResponseModel> UpdateProductStatusToUnavailableAsync(int ProductGameId);
        Task<SimpleResponseModel> UpdateProductStatusToAvailableAsync(int ProductGameId);
        Task<SimpleResponseModel> UpdateStockTotalAsync(int ProductGameID, int NewStock);
        Task<SimpleResponseModel> UpdateDimensionsProductGameAsync(int ProductGameID, decimal height, decimal width, decimal length)
    }
}
