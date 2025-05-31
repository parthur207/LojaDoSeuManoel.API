using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;

namespace LojaDoSeuManoel.Application.Repositories
{
    public interface IOrderRepository
    {
        //Querys
        Task<ResponseModel<List<OrderEntity>?>> GetAllOrdersAsync();
        Task<ResponseModel<List<OrderEntity>?>> GetOrderByCustomerAsync(string Email);
        Task<ResponseModel<OrderEntity>?> GetOrderByOrderIdAsync(int OrderId);
        Task<ResponseModel<List<OrderEntity>?>> GetAllOrdersCustomerAsync(int CustomerID);

        //Commands
        Task<SimpleResponseModel> CreateOrderAsync(OrderEntity Entity);
        Task<SimpleResponseModel> UpdateStatusToProcessingAsync(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToShippedAsync(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToDeliveredAsync(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToReturnedAsync(int OrderId);
        Task<SimpleResponseModel> UpdateOrderToCancelledAsync(int OrderId);
    }
}
