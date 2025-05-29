using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Services.Admin
{
    public class AdminCostumerService : IAdminCustomerInterface
    {
        public Task<SimpleResponseModel> ActiveCustomerAdmin(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CustomerGenericDTO>?>> GetAllCustomersAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<CustomerGenericDTO?>> GetCustomerByEmailAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> InactivateCustomerAdmin(string Email)
        {
            throw new NotImplementedException();
        }
    }
}
