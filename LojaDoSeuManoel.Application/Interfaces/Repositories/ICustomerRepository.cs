using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
 
        Task<ResponseModel<List<CustomerEntity>?>> GetAllCustomersAsync();
        Task<ResponseModel<CustomerEntity?>> GetCustomerByEmailAsync(string Email);
        Task<SimpleResponseModel> InactivateCustomerAsync(string Email);
        Task<SimpleResponseModel> ActiveCustomerAsync(string Email);
    }
}
