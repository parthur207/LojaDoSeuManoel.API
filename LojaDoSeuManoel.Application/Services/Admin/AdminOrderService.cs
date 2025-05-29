using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Application.Interfaces.Costumer;
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
        public Task<ResponseModel<List<OrderGenericDTO>?>> GetAllOrdersAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<OrderGenericDTO>?>> GetOrderByCustomerAdmin(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<OrderGenericDTO>?>> GetOrderByIdAdmin(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> UpdateStatusToDeliveredAdmin(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> UpdateStatusToProcessingAdmin(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> UpdateStatusToReturnedAdmin(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> UpdateStatusToShippedAdmin(int OrderId)
        {
            throw new NotImplementedException();
        }
    }
}
