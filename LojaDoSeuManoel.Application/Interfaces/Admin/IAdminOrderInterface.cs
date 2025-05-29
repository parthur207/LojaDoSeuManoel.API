using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Application.DTOs.Costumer;
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
        Task<ResponseModel<List<OrderAdminDTO>?>> GetAllOrdersAdmin();

        Task<ResponseModel<List<OrderAdminDTO>?>> GetOrderByCustomerAdmin(string Email);

        Task<ResponseModel<List<OrderAdminDTO>?>> GetOrderByIdAdmin(int OrderId);


        //Commands
        Task<SimpleResponseModel> UpdateStatusToProcessingAdmin(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToShippedAdmin(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToDeliveredAdmin(int OrderId);
        Task<SimpleResponseModel> UpdateStatusToReturnedAdmin(int OrderId);


    }
}
