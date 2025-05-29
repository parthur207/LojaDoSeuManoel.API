using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Admin
{
    public interface IAdminCostumerInterface
    {
        //Querys
        Task<ResponseModel<List<CustomerAdminDTO>?>> GetAllCustomersAdmin();
        Task<ResponseModel<CustomerAdminDTO?>> GetCustomerByEmailAdmin();


        //Commands
        Task<SimpleResponseModel> InactivateCustomerAdmin(string Email);
        Task<SimpleResponseModel> ActiveCustomerAdmin(string Email);


    }
}
