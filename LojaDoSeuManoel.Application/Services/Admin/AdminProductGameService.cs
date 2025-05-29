using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.Admin;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Services.Admin
{
    public class AdminProductGameService : IAdminProductGameInterface
    {
        public Task<ResponseModel<SimpleResponseModel>> CreateProductGameAdmin(CreateProductGameModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllProductGameAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesByCategoryAdmin(ProductGameCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByCategoryAdmin(ProductGameCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByNameOrDescriptionAdmin(string ItemOfQuery)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByPriceAdmin(decimal Price)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByStatusAdmin(ProductGameStatusEnum status)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameInactiveAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameNoStockAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProductGameAdminDTO>?>> GetTopFiveSalesAdmin(ProductGameCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> UpdateDataProductGameAdmin(int ProductGameID, UpdateProductGameModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<SimpleResponseModel>> UpdateStatusProductGameAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<SimpleResponseModel>> UpdateStockTotalAdmin(int ProductGameID, int NewStock)
        {
            throw new NotImplementedException();
        }
    }
}
