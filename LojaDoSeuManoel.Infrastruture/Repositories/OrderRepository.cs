using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Enuns;
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
    public class OrderRepository : IOrderRepository
    {

        private readonly LojaDoSeuManoelDbContext _dbContext;
        public OrderRepository(LojaDoSeuManoelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<List<OrderEntity>?>> GetAllOrdersAsync()
        {
            ResponseModel<List<OrderEntity>?> response = new ResponseModel<List<OrderEntity>?>();

            try
            {
                var orders = await _dbContext.Order.ToListAsync();
                if (orders is null || !orders.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhum pedido encontrado.";
                    return response;
                }

                response.Content = orders;
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

        public async Task<ResponseModel<List<OrderEntity>?>> GetOrderByCustomerAsync(string Email)
        {
            ResponseModel<List<OrderEntity>?> response = new ResponseModel<List<OrderEntity>?>();
            try
            {
                var orders = await _dbContext.Order
                    .Where(x => x.Costumer.Email == Email)
                    .ToListAsync();

                if (orders is null || !orders.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhum pedido encontrado para este cliente.";
                    return response;
                }

                response.Content = orders;
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

        public async Task<ResponseModel<List<OrderEntity>?>> GetOrderByIdAsync(int OrderId)
        {
            ResponseModel<List<OrderEntity>?> response = new ResponseModel<List<OrderEntity>?>();
            try
            {
                var orders = await _dbContext.Order
                    .Where(x => x.Id == OrderId)
                    .ToListAsync();

                if (orders is null || !orders.Any())
                {
                    response.Status = false;
                    response.Message = "Pedido não encontrado.";
                    return response;
                }

                response.Content = orders;
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

        public async Task<SimpleResponseModel> CreateOrderAsync(OrderEntity Entity)
        {

           SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                if (Entity is null)
                {
                    response.Status = false;
                    response.Message = "Pedido inválido.";
                    return response;
                }

                await _dbContext.Order.AddAsync(Entity);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = $"Pedido de Id '{Entity.Id}' criado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }}


        public async Task<SimpleResponseModel> UpdateOrderToCancelledAsync(int OrderId)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == OrderId);

                if (order is null)
                {
                    response.Status = false;
                    response.Message = "Pedido não encontrado.";
                    return response;
                }

                order.UpdateOrderStatus(OrderStatusEnum.Cancelled);
                _dbContext.Order.Update(order);

                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = $"Pedido de Id '{OrderId}' cancelado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> UpdateStatusToDeliveredAsync(int OrderId)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == OrderId);
                if (order is null)
                {
                    response.Status = false;
                    response.Message = "Pedido não encontrado.";
                    return response;
                }

                order.UpdateOrderStatus(OrderStatusEnum.Delivered);
                _dbContext.Order.Update(order);

                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = $"O pedido de Id '{OrderId}' foi entregue com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> UpdateStatusToProcessingAsync(int OrderId)
        {
           
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == OrderId);

                if (order is null)
                {
                    response.Status = false;
                    response.Message = "Pedido não encontrado.";
                    return response;
                }

                order.UpdateOrderStatus(OrderStatusEnum.Processing);
                _dbContext.Order.Update(order);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = $"O pedido de Id '{OrderId}' está em processamento.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> UpdateStatusToReturnedAsync(int OrderId)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == OrderId);

                if (order is null)
                {
                    response.Status = false;
                    response.Message = "Pedido não encontrado.";
                    return response;
                }

                order.UpdateOrderStatus(OrderStatusEnum.Returned);
                _dbContext.Order.Update(order);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = $"O pedido de Id '{OrderId}' foi retornado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> UpdateStatusToShippedAsync(int OrderId)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == OrderId);

                if (order is null)
                {
                    response.Status = false;
                    response.Message = "Pedido não encontrado.";
                    return response;
                }

                order.UpdateOrderStatus(OrderStatusEnum.Shipped);
                _dbContext.Order.Update(order);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = $"O pedido de Id '{OrderId}' foi enviado com sucesso.";
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
