using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Admin
{
    public interface IAdminCustomerInterface
    {
        //Querys
        Task<ResponseModel<List<CustomerGenericDTO>?>> GetAllCustomersAdmin();
        Task<ResponseModel<CustomerGenericDTO?>> GetCustomerByEmailAdmin(string Email);

        //Commands
        Task<SimpleResponseModel> InactivateCustomerAdmin(string Email);
        Task<SimpleResponseModel> ActiveCustomerAdmin(string Email);


    }
}
