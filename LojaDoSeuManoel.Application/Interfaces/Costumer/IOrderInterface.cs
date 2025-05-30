using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;

namespace LojaDoSeuManoel.Application.Interfaces.Costumer
{
    public interface IOrderInterface
    {
        //Querys
        Task<ResponseModel<List<OrderGenericDTO>?>> GetAllOrders(int CustomerId);


        Task<SimpleResponseModel> UpdateOrderToCancelled(int OrderId);
    }
}
