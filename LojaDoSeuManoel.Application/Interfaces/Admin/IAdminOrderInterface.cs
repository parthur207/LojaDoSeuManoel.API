using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Application.Interfaces.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Admin
{
    public interface IAdminOrderInterface
    {
        //Querys
        Task<ResponseModel<List<OrderGenericDTO>?>> GetAllOrdersAdmin();

        Task<ResponseModel<List<OrderGenericDTO>?>> GetOrderByCustomerAdmin(string Email);

        Task<ResponseModel<OrderGenericDTO>?> GetOrderByIdAdmin(int OrderId);


        //Commands
        Task<SimpleResponseModel> UpdateStatusToProcessingAdmin(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToShippedAdmin(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToDeliveredAdmin(int OrderId);
        Task<SimpleResponseModel> UpdateOrderToCancelledAdmin(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToReturnedAdmin(int OrderId);


    }
}
