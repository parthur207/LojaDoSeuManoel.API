using LojaDoSeuManoel.Application.DTOs.Customer;
using LojaDoSeuManoel.Application.Interfaces.Costumer;
using LojaDoSeuManoel.Application.Mappers;
using LojaDoSeuManoel.Application.Repositories;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Services.Costumer
{
    public class ProductGameService : IProductGameInterface
    {
        private readonly IProductGameRepository _productGameRepository;
        public ProductGameService(IProductGameRepository productGameRepository)
        {
            _productGameRepository = productGameRepository;
        }

        public async Task<ResponseModel<List<ProductGameDTO>?>> GetAllProductGames()
        {
            ResponseModel<List<ProductGameDTO>?> response = new ResponseModel<List<ProductGameDTO>?>();

            var responseRepository = await _productGameRepository.GetAllProductGameAsync();

            if (responseRepository.Status is false)
            {
                response.Status = false;
                response.Message = "Nenhum resultado foi encontrado.";

                return response;
            }
            foreach (var PG in responseRepository.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameDTO(PG);

                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameDTO>?>> GetProductGameByCategory(ProductGameCategoryEnum category)
        {
            ResponseModel<List<ProductGameDTO>?> response = new ResponseModel<List<ProductGameDTO>?>();

            var responseRepository = await _productGameRepository.GetProductGameByCategoryAsync(category);

            if (responseRepository.Status is false)
            {
                response.Status = false;
                response.Message = "Nenhum resultado foi encontrado.";
                return response;
            }

            foreach (var PG in responseRepository.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameDTO(PG);

                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameDTO>?>> GetProductGameByNameOrDescription(string ItemOfQuery)
        {
            
            ResponseModel<List<ProductGameDTO>?> response = new ResponseModel<List<ProductGameDTO>?>();

            var responseRepository = await _productGameRepository.GetProductGameByNameOrDescriptionAsync(ItemOfQuery);

            if (responseRepository.Status is false)
            {
                response.Status = false;
                response.Message = "Nenhum resultado foi encontrado.";
                return response;
            }

            foreach (var PG in responseRepository.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameDTO(PG);

                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<List<ProductGameDTO>?>> GetProductGameByPrice(decimal Price)
        {
            
            ResponseModel<List<ProductGameDTO>?> response = new ResponseModel<List<ProductGameDTO>?>();

            var responseRepository = await _productGameRepository.GetProductGameByPriceAsync(Price);

            if (responseRepository.Status is false)
            {
                response.Status = false;
                response.Message = "Nenhum resultado foi encontrado.";
                return response;
            }

            foreach (var PG in responseRepository.Content)
            {
                var productMapped = ProductGameMapper.ToProductGameDTO(PG);

                response.Content.Add(productMapped);
            }

            response.Status = true;
            return response;
        }
    }
}
