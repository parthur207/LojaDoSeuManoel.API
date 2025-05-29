using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.Admin;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using LojaDoSeuManoel.Infrastruture.Persistense;
using LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastruture.Repositories
{
    public class ProductGameRepository : IProductGameRepository
    {

        private readonly LojaDoSeuManoelDbContext _Dbcontext;

        public ProductGameRepository(LojaDoSeuManoelDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        public async Task<ResponseModel<SimpleResponseModel>> CreateProductGameAsync(CreateProductGameModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllProductGameAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesByCategoryAsync(ProductGameCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByCategoryAsync(ProductGameCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByNameOrDescriptionAsync(string ItemOfQuery)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByPriceAsync(decimal Price)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByStatusAsync(ProductGameStatusEnum status)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameInactiveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameNoStockAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetTopFiveSalesAsync(ProductGameCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> UpdateDataProductGameAsync(int ProductGameID, UpdateProductGameModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<SimpleResponseModel>> UpdateStatusProductGameAsync(ProductGameStatusEnum NewStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<SimpleResponseModel>> UpdateStockTotalAsync(int ProductGameID, int NewStock)
        {
            throw new NotImplementedException();
        }
    }
}
