using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Application.DTOs.Costumer;
using LojaDoSeuManoel.Domain.Enuns;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Costumer
{
    public interface IProductGameInterface
    {

        Task<ResponseModel<List<ProductGameDTO>?>> GetAllProductGames();

        Task<ResponseModel<List<ProductGameDTO>?>> GetProductGameByCategory(ProductGameCategoryEnum category);

        Task<ResponseModel<List<ProductGameDTO>?>> GetProductGameByNameOrDescription(string ItemOfQuery);

        Task<ResponseModel<List<ProductGameDTO>?>> GetProductGameByPrice(decimal Price);

    }
}
