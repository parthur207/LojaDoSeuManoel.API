using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Costumer
{
    public interface IOrderInterface
    {
        //Querys
        Task<ResponseModel<List<OrderGenericDTO>?>> GetAllOrders(int CustomerId);


        Task<SimpleResponseModel> UpdateOrderToCancelled(int OrderId);
    }

}
}
