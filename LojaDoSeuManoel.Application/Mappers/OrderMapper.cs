using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Mappers
{
    public class OrderMapper
    {

        //Model para entity

        public OrderEntity ToOrderEntity(CreateOrderModel model, int CustomerId)
        {
            return new OrderEntity
            (
                CustomerId,
                model.ShoppingList.Select(item => new OrderProductGameEntity
                {
                    ProductGameId = item.Id,
                    Quantity = item.Quantity
                }).ToList()
            );
        }

        //Entity para DTO

        public OrderGenericDTO ToOrderGenericDTO(OrderEntity entity)
        {
            return new OrderGenericDTO 
            {
                OrderList=entity.OrderList, 
                OrderId=entity.Id, 
                CreatedAt=entity.CreatedAt, 
                TotalValue=entity.TotalValue,
                Status=entity.OrderStatus,
                BoxType=entity.Box.BoxType,
                CustomerName=entity.Costumer.Name,
                CustomerEmail=entity.Costumer.Email
            };
        }
    }
}
