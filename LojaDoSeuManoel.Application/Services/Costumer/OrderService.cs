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
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResponseModel<List<OrderGenericDTO>?>> GetAllOrders(int CustomerId)
        {

            ResponseModel<List<OrderGenericDTO>?> response = new ResponseModel<List<OrderGenericDTO>?>();

            var orders = await _orderRepository.GetAllOrdersCustomerAsync(CustomerId);

            if (orders.Content is null || !orders.Content.Any())
            {
                response.Message = "Sem resultados para pedidos com com o Id informado.";
                response.Status = false;
                return response;
            }

            foreach (var order in orders.Content)
            {
                var OrderMapped = OrderMapper.ToOrderGenericDTO(order);
                response.Content.Add(OrderMapped);
            }

            response.Status = true;
            return response;
        }

        public async Task<SimpleResponseModel> UpdateOrderToCancelled(int OrderId)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            if (OrderId <= 0)
            {
                response.Status = false;
                response.Message = "O Id do pedido não pode ser menor ou igual a zero.";
                return response;
            }

            var responseRepository = await _orderRepository.UpdateOrderToCancelledAsync(OrderId);

            if (responseRepository.Status is false)
            {
                return responseRepository;
            }

            response.Status = true;
            response.Message = "Pedido cancelado com sucesso.";
            return response;
        }
    }
}
