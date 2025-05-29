using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.Admin;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using LojaDoSeuManoel.Infrastruture.Persistense;
using LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
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

        public async Task<SimpleResponseModel> CreateProductGameAsync(ProductGameEntity Entity)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var GameExists = await _Dbcontext.ProductGame
                    .AnyAsync(x => x.Name.Equals(Entity.Name, StringComparison.OrdinalIgnoreCase));

                if (GameExists is true)
                {
                    response.Message = $"Erro. Já existe um jogo com o nome '{Entity.Name}'.";
                    response.Status = false;
                    return response;
                }

                await _Dbcontext.ProductGame.AddAsync(Entity);
                await _Dbcontext.SaveChangesAsync();

                response.Message = "Um novo jogo adicionado ao catálogo.";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetAllProductGameAsync()
        {
            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var productGames = await _Dbcontext.ProductGame.ToListAsync();
                if (productGames is null || !productGames.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhum jogo encontrado.";
                    return response;
                }

                response.Content = productGames;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetAllSalesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetAllSalesByCategoryAsync(ProductGameCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByCategoryAsync(ProductGameCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByNameOrDescriptionAsync(string ItemOfQuery)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByPriceAsync(decimal Price)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByStatusAsync(ProductGameStatusEnum status)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameInactiveAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameNoStockAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetTopFiveSalesAsync(ProductGameCategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> UpdateDataProductGameAsync(int ProductGameID, ProductGameEntity Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> UpdateStatusProductGameAsync(ProductGameStatusEnum NewStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> UpdateStockTotalAsync(int ProductGameID, int NewStock)
        {
            throw new NotImplementedException();
        }
    }
}
