using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Application.DTOs.Customer;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Mappers
{
    public class ProductGameMapper
    {

        //Model para entity

        public static ProductGameEntity ToCreateProductGameEntity(CreateProductGameModel model)
        {
            return new ProductGameEntity(model.Name, model.Description,model.Price, model.Height, model.Width, model.Length, model.Stock, model.Category, model.ImageUrl);
        }

        public static ProductGameEntity ToUpdateProductGameEntity(UpdateProductGameModel model)
        {
            return new ProductGameEntity(model.Name, model.Description, model.Price, model.Height, model.Width, model.Length, model.ImageUrl);
        }

        //Entity para DTO
        public static ProductGameAdminDTO ToProductGameAdminDTO(ProductGameEntity entity)
        {
            return new ProductGameAdminDTO
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Height = entity.Height,
                Width = entity.Width,
                Length = entity.Length,
                Stock = entity.Stock,
                Sales = entity.Sales,
                Status = entity.Status,
                Category = entity.Category,
                ImageUrl = entity.ImageUrl
            };
        }

        public ProductGameDTO ToProductGameDTO(ProductGameEntity entity)
        {
            return new ProductGameDTO
            { 
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Height = entity.Height,
                Width = entity.Width,
                Length = entity.Length,
                Stock = entity.Stock,
                Category = entity.Category,
                ImageUrl = entity.ImageUrl
            };
        }
    }
}
