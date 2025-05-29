using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;

namespace LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository
{
    public interface IOrderRepository
    {
        //Querys
        Task<ResponseModel<List<OrderGenericDTO>?>> GetAllOrdersAsync();
        Task<ResponseModel<List<OrderGenericDTO>?>> GetOrderByCustomerAsync(string Email);
        Task<ResponseModel<List<OrderGenericDTO>?>> GetOrderByIdAsync(int OrderId);

        //Commands
        Task<SimpleResponseModel> UpdateStatusToProcessingAsync(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToShippedAsync(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToDeliveredAsync(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToReturnedAsync(int OrderId);
        Task<SimpleResponseModel> UpdateOrderToCancelledAsync(int OrderId);
    }
}
