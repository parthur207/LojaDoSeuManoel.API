using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository
{
    public interface ICustomerRepository
    {
 
        Task<ResponseModel<List<CustomerGenericDTO>?>> GetAllCustomersAsync();
        Task<ResponseModel<CustomerGenericDTO?>> GetCustomerByEmailAsync(string Email);
        Task<SimpleResponseModel> InactivateCustomerAsync(string Email);
        Task<SimpleResponseModel> ActiveCustomeAsync(string Email);
    }
}
