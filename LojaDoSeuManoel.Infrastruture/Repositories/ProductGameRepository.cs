using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Application.Repositories;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.Admin;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using LojaDoSeuManoel.Infrastructure.Persistense;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastructure.Repositories
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

            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var sales = await _Dbcontext.ProductGame
                    .Where(x => x.Status == ProductGameStatusEnum.Sold)
                    .ToListAsync();

                if (sales is null || !sales.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhuma venda encontrada.";
                    return response;
                }

                response.Content = sales;
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

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetAllSalesByCategoryAsync(ProductGameCategoryEnum category)
        {

            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var salesByCategory = await _Dbcontext.ProductGame
                    .Where(x => x.Category == category && x.Status == ProductGameStatusEnum.Sold)
                    .ToListAsync();

                if (salesByCategory is null || !salesByCategory.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhuma venda encontrada para a categoria especificada.";
                    return response;
                }

                response.Content = salesByCategory;
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

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByCategoryAsync(ProductGameCategoryEnum category)
        {

            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var productGamesByCategory = await _Dbcontext.ProductGame
                    .Where(x => x.Category == category)
                    .ToListAsync();

                if (productGamesByCategory is null || !productGamesByCategory.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhum jogo encontrado para a categoria especificada.";
                    return response;
                }

                response.Content = productGamesByCategory;
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

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByNameOrDescriptionAsync(string ItemOfQuery)
        {

            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var productGames = await _Dbcontext.ProductGame
                    .Where(x => x.Name.Contains(ItemOfQuery) || x.Description.Contains(ItemOfQuery))
                    .ToListAsync();

                if (productGames is null || !productGames.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhum jogo encontrado com o critério de pesquisa especificado.";
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

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByPriceAsync(decimal Price)
        {

            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var productGamesByPrice = await _Dbcontext.ProductGame
                    .Where(x => x.Price <= Price)
                    .ToListAsync();

                if (productGamesByPrice is null || !productGamesByPrice.Any())
                {
                    response.Status = false;
                    response.Message = $"Nenhum jogo encontrado com o preço de R$ 0.00 a R$ {Price}.";
                    return response;
                }

                response.Content = productGamesByPrice;
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

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameByStatusAsync(ProductGameStatusEnum status)
        {

            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var productGamesByStatus = await _Dbcontext.ProductGame
                    .Where(x => x.Status == status)
                    .ToListAsync();

                if (productGamesByStatus is null || !productGamesByStatus.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhum jogo encontrado com o status especificado.";
                    return response;
                }

                response.Content = productGamesByStatus;
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

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameInactiveAsync()
        {

            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var inactiveGames = await _Dbcontext.ProductGame
                    .Where(x => x.Active == false || x.Status == ProductGameStatusEnum.Unavailable)
                    .ToListAsync();

                if (inactiveGames is null || !inactiveGames.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhum jogo inativo encontrado.";
                    return response;
                }

                response.Content = inactiveGames;
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

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetProductGameNoStockAsync()
        {

            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var noStockGames = await _Dbcontext.ProductGame
                    .Where(x => x.Stock == 0)
                    .ToListAsync();

                if (noStockGames is null || !noStockGames.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhum jogo sem estoque encontrado.";
                    return response;
                }

                response.Content = noStockGames;
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

        public async Task<ResponseModel<List<ProductGameEntity>?>> GetTopFiveSalesAsync()
        {

            ResponseModel<List<ProductGameEntity>?> response = new ResponseModel<List<ProductGameEntity>?>();

            try
            {
                var topSales = await _Dbcontext.ProductGame
                    .OrderByDescending(x => x.Sales)
                    .Take(5)
                    .ToListAsync();

                if (topSales is null || !topSales.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhuma venda encontrada para a categoria especificada.";
                    return response;
                }

                response.Content = topSales;
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

        public async Task<SimpleResponseModel> UpdateNameProductGameAsync(int ProductGameID, string Name)
        {

            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var existingGame = await _Dbcontext.ProductGame.FirstOrDefaultAsync(x => x.Id == ProductGameID);

                if (existingGame is null)
                {
                    response.Message = "Jogo não encontrado.";
                    response.Status = false;
                    return response;
                }

                existingGame.SetProductName(Name);
                _Dbcontext.ProductGame.Update(existingGame);
                await _Dbcontext.SaveChangesAsync();

                response.Message = "Nome do jogo atualizado com sucesso.";
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

        public async Task<SimpleResponseModel> UpdateDescriptionProductGameAsync(int ProductGameID, string NewDescription)
        {

            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var existingGame = await _Dbcontext.ProductGame.FirstOrDefaultAsync(x => x.Id == ProductGameID);

                if (existingGame is null)
                {
                    response.Message = "Jogo não encontrado.";
                    response.Status = false;
                    return response;
                }

                existingGame.SetProductDescription(NewDescription);
                _Dbcontext.ProductGame.Update(existingGame);
                await _Dbcontext.SaveChangesAsync();

                response.Message = "Descrição do jogo atualizados com sucesso.";
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

        public async Task<SimpleResponseModel> UpdatePriceProductGameAsync(int ProductGameID, decimal NewPrice)
        {

            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var existingGame = await _Dbcontext.ProductGame.FirstOrDefaultAsync(x => x.Id == ProductGameID);
                if (existingGame is null)
                {
                    response.Message = "Jogo não encontrado.";
                    response.Status = false;
                    return response;
                }

                existingGame.SetProductPrice(NewPrice);
                _Dbcontext.ProductGame.Update(existingGame);
                await _Dbcontext.SaveChangesAsync();

                response.Message = "Preço do jogo atualizado com sucesso.";
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

        public async Task<SimpleResponseModel> UpdateDimensionsProductGameAsync(int ProductGameID, decimal height, decimal width, decimal length)
        {

            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var existingGame = await _Dbcontext.ProductGame.FirstOrDefaultAsync(x => x.Id == ProductGameID);

                if (existingGame is null)
                {
                    response.Message = "Jogo não encontrado.";
                    response.Status = false;
                    return response;
                }

                existingGame.SetDimensionsOfProductGame(height, width, length);
                _Dbcontext.ProductGame.Update(existingGame);
                await _Dbcontext.SaveChangesAsync();

                response.Message = "Dimensões do jogo atualizadas com sucesso.";
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

        public async Task<SimpleResponseModel> UpdateStockTotalAsync(int ProductGameID, int NewStock)
        {

            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                if (NewStock < 0)
                {
                    response.Message = "O estoque não pode ser negativo.";
                    response.Status = false;
                    return response;
                }

                var Product = await _Dbcontext.ProductGame.FirstOrDefaultAsync(X => X.Id == ProductGameID);

                if (Product is null)
                {
                    response.Status = false;
                    response.Message = $"Produto (Jogo) com o Id ({ProductGameID}) não existe.";
                    return response;
                }

                Product.IncreaseStock(NewStock);
                _Dbcontext.ProductGame.Update(Product);
                await _Dbcontext.SaveChangesAsync();
                response.Message = "Estoque atualizado com sucesso.";
                response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}.";
                return response;
            }
        }

        public async Task<SimpleResponseModel> UpdateProductStatusToAvailableAsync(int ProductGameId)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var productGame = await _Dbcontext.ProductGame.FirstOrDefaultAsync(x => x.Id == ProductGameId);

                if (productGame is null)
                {
                    response.Status = false;
                    response.Message = $"Nenhum jogo com a Id '{ProductGameId}' foi encontrado.";
                    return response;
                }


                productGame.SetProductStatusToAvailable();
                _Dbcontext.ProductGame.Update(productGame);
                await _Dbcontext.SaveChangesAsync();

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
        public async Task<SimpleResponseModel> UpdateProductStatusToUnavailableAsync(int ProductGameId)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var productGame = await _Dbcontext.ProductGame.FirstOrDefaultAsync(x => x.Id == ProductGameId);

                if (productGame is null)
                {
                    response.Status = false;
                    response.Message = $"Nenhum jogo com a Id '{ProductGameId}' foi encontrado.";
                    return response;
                }

                productGame.SetProductStatusToUnavailable();
                _Dbcontext.ProductGame.Update(productGame);
                await _Dbcontext.SaveChangesAsync();

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

        public async Task<SimpleResponseModel> DeleteProductGameAsync(int ProductGameId)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var productGame = await _Dbcontext.ProductGame.FirstOrDefaultAsync(x => x.Id == ProductGameId);

                if (productGame is null)
                {
                    response.Status = false;
                    response.Message = $"Nenhum jogo com a Id '{ProductGameId}' foi encontrado.";
                    return response;
                }

                productGame.SetToInactived();
                _Dbcontext.ProductGame.Update(productGame);

                await _Dbcontext.SaveChangesAsync();

                response.Status = true;
                response.Message = "Jogo excluído com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }
    }
}

