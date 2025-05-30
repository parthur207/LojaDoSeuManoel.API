using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Application.Interfaces.Costumer;
using LojaDoSeuManoel.Application.Mappers;
using LojaDoSeuManoel.Application.Repositories;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Services.Costumer
{
    public class OrderService : IOrderInterface
    {
        private readonly IOrderRepository _orderRepository;

        public async Task<ResponseModel<List<OrderGenericDTO>?>> GetAllOrders(int CustomerId)
        {

            ResponseModel<List<OrderGenericDTO>?> response = new ResponseModel<List<OrderGenericDTO>?>();

            var orders = await _orderRepository.GetOrderByIdAsync(CustomerId);

            if (orders.Content is null || !orders.Content.Any())
            {
                response.Message = "Sem resultados para pedidos com com o Id informado.";
                response.Status = false;
                return response;
            }
            foreach (var order in orders.Content)
            {
                var OrderMapped = OrderMapper.ToOrderGenericDTO(order);
                response.Content.Add();
            }
           response.Content = 
            }).ToList();
          
            };
           
            
        }

        public Task<SimpleResponseModel> UpdateOrderToCancelled(int OrderId)
        {
            throw new NotImplementedException();
        }
    }
}
