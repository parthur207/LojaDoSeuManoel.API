using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Application.Interfaces.Costumer;
using LojaDoSeuManoel.Application.Mappers;
using LojaDoSeuManoel.Application.Repositories;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Services.Admin
{
    public class AdminOrderService : IAdminOrderInterface
    {
        private readonly IOrderRepository _orderRepository;
        public AdminOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResponseModel<List<OrderGenericDTO>?>> GetAllOrdersAdmin()
        {
            ResponseModel<List<OrderGenericDTO>?> response = new ResponseModel<List<OrderGenericDTO>?>();

            var orders =await _orderRepository.GetAllOrdersAsync();

            if (orders.Content is null || !orders.Content.Any())
            {
                response.Message = "Sem resultados para pedidos.";
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

        public async Task<ResponseModel<List<OrderGenericDTO>?>> GetOrderByCustomerAdmin(string Email)
        {
            ResponseModel<List<OrderGenericDTO>?> response = new ResponseModel<List<OrderGenericDTO>?>();

            if (string.IsNullOrEmpty(Email))
            {
                response.Status = false;
                response.Message = "O email não pode ser nulo ou vazio.";
                return response;
            }

            var orders = await _orderRepository.GetOrderByCustomerAsync(Email);

            if (orders.Content is null || !orders.Content.Any())
            {
                response.Message = "Sem resultados para pedidos com o email informado.";
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

        public async Task<ResponseModel<List<OrderGenericDTO>?>> GetOrderByIdAdmin(int OrderId)
        {
            ResponseModel<List<OrderGenericDTO>?> response = new ResponseModel<List<OrderGenericDTO>?>();

            if (OrderId <= 0)
            {
                response.Status = false;
                response.Message = "O ID do pedido deve ser maior que zero.";
                return response;
            }

            var orders = await _orderRepository.GetOrderByIdAsync(OrderId);

            if (orders.Content is null || !orders.Content.Any())
            {
                response.Message = "Sem resultados para pedidos com o ID informado.";
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

        public async Task<SimpleResponseModel> UpdateStatusToDeliveredAdmin(int OrderId)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            if (OrderId <= 0)
            {
                response.Status = false;
                response.Message = "O ID do pedido deve ser maior que zero.";
                return response;
            }

            var updateResult = await _orderRepository.UpdateStatusToDeliveredAsync(OrderId);

            if (updateResult.Status is false)
            {
                return updateResult;
            }

            response.Status = true;
            response.Message = "Pedido atualizado com sucesso.";
            return response;
            
        }

        public async Task<SimpleResponseModel> UpdateStatusToProcessingAdmin(int OrderId)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            
            if (OrderId <= 0)
            {
                response.Status = false;
                response.Message = "O ID do pedido deve ser maior que zero.";
                return response;
            }

            var updateResult = await _orderRepository.UpdateStatusToProcessingAsync(OrderId);

            if (updateResult.Status is false)
            {
                return updateResult;
            }

            response.Status = true;
            response.Message = "Pedido atualizado com sucesso.";
            return response;
        }

        public async Task<SimpleResponseModel> UpdateStatusToReturnedAdmin(int OrderId)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            
            if (OrderId <= 0)
            {
                response.Status = false;
                response.Message = "O ID do pedido deve ser maior que zero.";
                return response;
            }

            var updateResult = await _orderRepository.UpdateStatusToReturnedAsync(OrderId);

            if (updateResult.Status is false)
            {
                return updateResult;
            }

            response.Status = true;
            response.Message = "Pedido atualizado com sucesso.";
            return response;
            
        }

        public async Task<SimpleResponseModel> UpdateStatusToShippedAdmin(int OrderId)
        {
            SimpleResponseModel response = new SimpleResponseModel();
                        
            if (OrderId <= 0)
            {
                response.Status = false;
                response.Message = "O ID do pedido deve ser maior que zero.";
                return response;
            }

            var updateResult = await _orderRepository.UpdateStatusToShippedAsync(OrderId);

            if (updateResult.Status is false)
            {
                return updateResult;
            }

            response.Status = true;
            response.Message = "Pedido atualizado com sucesso.";
            return response;
        }

        public async Task<SimpleResponseModel> UpdateOrderToCancelledAdmin(int OrderId)
        {    
            SimpleResponseModel response = new SimpleResponseModel();
            
            if (OrderId <= 0)
            {
                response.Status = false;
                response.Message = "O ID do pedido deve ser maior que zero.";
                return response;
            }

            var updateResult = await _orderRepository.UpdateOrderToCancelledAsync(OrderId);

            if (updateResult.Status is false)
            {
                return updateResult;
            }

            response.Status = true;
            response.Message = "Pedido cancelado com sucesso.";
            return response;
        }
    }
}
