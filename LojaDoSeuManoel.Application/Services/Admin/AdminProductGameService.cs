using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Application.Mappers;
using LojaDoSeuManoel.Application.Repositories;
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
        private readonly IProductGameRepository _adminProductGameRespository;
        public AdminProductGameService(IProductGameRepository adminProductGameRespository)
        {
            _adminProductGameRespository = adminProductGameRespository;
        }
        public async Task<ResponseModel<SimpleResponseModel>> CreateProductGameAdmin(CreateProductGameModel model)
        {
            ResponseModel<SimpleResponseModel> response = new ResponseModel<SimpleResponseModel>();

  
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Description) || model.Price <= 0 || model.Stock < 0)
            {
                response.Status = false;
                response.Message = "Os campos obrigatórios não podem estar vazios ou inválidos.";
                return response;
            }

            var productGameMapped = ProductGameMapper.ToCreateProductGameEntity(model);

            var responseRepository = await _adminProductGameRespository.CreateProductGameAsync(productGameMapped);

            if (responseRepository.Status is false)
            {
                response.Status = false;
                response.Message = "Erro ao criar o produto.";
                return response;
            }

            response.Status = true;
            response.Message = "Produto criado com sucesso.";
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllProductGameAdmin()
        {
            
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            var products = await _adminProductGameRespository.GetAllProductGameAsync();

            if (products.Content is null || !products.Content.Any())
            {
                response.Message = "Sem resultados para produtos.";
                response.Status = false;
                return response;
            }

            foreach (var product in products.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameAdminDTO(product);
                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesAdmin()
        {
            
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            var sales = await _adminProductGameRespository.GetAllSalesAsync();

            if (sales.Content is null || !sales.Content.Any())
            {
                response.Message = "Sem resultados para vendas.";
                response.Status = false;
                return response;
            }

            foreach (var sale in sales.Content)
            {
                var saleMapped = ProductGameMapper.ToProductGameAdminDTO(sale);
                response.Content.Add(saleMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetAllSalesByCategoryAdmin(ProductGameCategoryEnum category)
        {
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            var salesByCategory = await _adminProductGameRespository.GetAllSalesByCategoryAsync(category);

            if (salesByCategory.Content is null || !salesByCategory.Content.Any())
            {
                response.Message = "Sem resultados para vendas na categoria informada.";
                response.Status = false;
                return response;
            }

            foreach (var sale in salesByCategory.Content)
            {
                var saleMapped = ProductGameMapper.ToProductGameAdminDTO(sale);
                response.Content.Add(saleMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByCategoryAdmin(ProductGameCategoryEnum category)
        {
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            var productsByCategory = await _adminProductGameRespository.GetProductGameByCategoryAsync(category);

            if (productsByCategory.Content is null || !productsByCategory.Content.Any())
            {
                response.Message = "Sem resultados para produtos na categoria informada.";
                response.Status = false;
                return response;
            }

            foreach (var product in productsByCategory.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameAdminDTO(product);
                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByNameOrDescriptionAdmin(string ItemOfQuery)
        {
            
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            if (string.IsNullOrEmpty(ItemOfQuery))
            {
                response.Status = false;
                response.Message = "O termo de pesquisa não pode ser nulo ou vazio.";
                return response;
            }

            var products = await _adminProductGameRespository.GetProductGameByNameOrDescriptionAsync(ItemOfQuery);

            if (products.Content is null || !products.Content.Any())
            {
                response.Message = "Nenhum produto encontrado com o termo de pesquisa informado.";
                response.Status = false;
                return response;
            }

            foreach (var product in products.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameAdminDTO(product);
                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByPriceAdmin(decimal Price)
        {
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            if (Price <= 0)
            {
                response.Status = false;
                response.Message = "O preço deve ser maior que zero.";
                return response;
            }

            var productsByPrice = await _adminProductGameRespository.GetProductGameByPriceAsync(Price);

            if (productsByPrice.Content is null || !productsByPrice.Content.Any())
            {
                response.Message = "Nenhum produto encontrado com o preço informado.";
                response.Status = false;
                return response;
            }

            foreach (var product in productsByPrice.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameAdminDTO(product);
                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameByStatusAdmin(ProductGameStatusEnum status)
        {
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            var productsByStatus = await _adminProductGameRespository.GetProductGameByStatusAsync(status);

            if (productsByStatus.Content is null || !productsByStatus.Content.Any())
            {
                response.Message = "Nenhum produto encontrado com o status informado.";
                response.Status = false;
                return response;
            }

            foreach (var product in productsByStatus.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameAdminDTO(product);
                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameInactiveAdmin()
        {
            
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            var inactiveProducts = await _adminProductGameRespository.GetProductGameInactiveAsync();

            if (inactiveProducts.Content is null || !inactiveProducts.Content.Any())
            {
                response.Message = "Nenhum produto inativo encontrado.";
                response.Status = false;
                return response;
            }

            foreach (var product in inactiveProducts.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameAdminDTO(product);
                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetProductGameNoStockAdmin()
        {
            
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            var noStockProducts = await _adminProductGameRespository.GetProductGameNoStockAsync();

            if (noStockProducts.Content is null || !noStockProducts.Content.Any())
            {
                response.Message = "Nenhum produto sem estoque encontrado.";
                response.Status = false;
                return response;
            }

            foreach (var product in noStockProducts.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameAdminDTO(product);
                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameAdminDTO>?>> GetTopFiveSalesAdmin()
        {
            ResponseModel<List<ProductGameAdminDTO>?> response = new ResponseModel<List<ProductGameAdminDTO>?>();

            var topSales = await _adminProductGameRespository.GetTopFiveSalesAsync();

            if (topSales.Content is null || !topSales.Content.Any())
            {
                response.Message = "Nenhum produto encontrado nas vendas mais altas.";
                response.Status = false;
                return response;
            }

            foreach (var sale in topSales.Content)
            {
                var saleMapped = ProductGameMapper.ToProductGameAdminDTO(sale);
                response.Content.Add(saleMapped);
            }

            response.Status = true;
            return response;
        }

       

        public async Task<SimpleResponseModel> UpdateStockTotalAdmin(int ProductGameID, int NewStock)
        {
           
            SimpleResponseModel response = new SimpleResponseModel();

            if (ProductGameID <= 0 || NewStock < 0)
            {
                response.Status = false;
                response.Message = "O ID do produto deve ser maior que zero e o estoque não pode ser negativo.";
                return response;
            }

            var updateResult = await _adminProductGameRespository.UpdateStockTotalAsync(ProductGameID, NewStock);

            if (updateResult.Status is false)
            {
                response.Status = false;
                response.Message = "Erro ao atualizar o estoque do produto.";
                return response;
            }

            response.Status = true;
            response.Message = "Estoque atualizado com sucesso.";
            return response;
        }

       

        public async Task<SimpleResponseModel> UpdateProductStatusToUnavailableAdmin(int ProductGameId)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            if (ProductGameId <= 0)
            {
                response.Status = false;
                response.Message = "O ID do produto deve ser maior que zero.";
                return response;
            }

            var updateResult = await _adminProductGameRespository.UpdateProductStatusToUnavailableAsync(ProductGameId);

            if (updateResult.Status is false)
            {
                response.Status = false;
                response.Message = "Erro ao atualizar o status do produto para indisponível.";
                return response;
            }

            response.Status = true;
            response.Message = "Status do produto atualizado para indisponível com sucesso.";
            return response;
            
        }

        public async Task<SimpleResponseModel> UpdateProductStatusToAvailableAdmin(int ProductGameId)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            
            if (ProductGameId <= 0)
            {
                response.Status = false;
                response.Message = "O ID do produto deve ser maior que zero.";
                return response;
            }

            var updateResult = await _adminProductGameRespository.UpdateProductStatusToAvailableAsync(ProductGameId);

            if (updateResult.Status is false)
            {
                response.Status = false;
                response.Message = "Erro ao atualizar o status do produto para disponível.";
                return response;
            }

            response.Status = true;
            response.Message = "Status do produto atualizado para disponível com sucesso.";
            return response;
        }



        public async Task<SimpleResponseModel> UpdateDimensionsProductGame(int ProductGameID, decimal n1, decimal n2, decimal n3)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            
            if (ProductGameID <= 0)
            {
                response.Status = false;
                response.Message = "O ID do produto deve ser maior que zero.";
                return response;
            }

            var updateResult = await _adminProductGameRespository.UpdateDimensionsProductGameAsync(ProductGameID, n1, n2, n3);

            if (updateResult.Status is false)
            {
                response.Status = false;
                response.Message = "Erro ao atualizar as dimensões do produto.";
                return response;
            }

            response.Status = true;
            response.Message = "Dimensões do produto atualizadas com sucesso.";
            return response;
        }

        public async Task<SimpleResponseModel> DeleteProductGameAdmin(int ProductGameID)
        {
         
            SimpleResponseModel response = new SimpleResponseModel();
            if (ProductGameID <= 0)
            {
                response.Status = false;
                response.Message = "O ID do produto deve ser maior que zero.";
                return response;
            }
            var deleteResult = await _adminProductGameRespository.DeleteProductGameAsync(ProductGameID);
            if (deleteResult.Status is false)
            {
                response.Status = false;
                response.Message = "Erro ao excluir o produto.";
                return response;
            }
            response.Status = true;
            response.Message = "Produto excluído com sucesso.";
            return response;
        }
    }
}
