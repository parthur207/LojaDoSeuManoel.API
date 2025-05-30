using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Models.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        //Commands
        Task<SimpleResponseModel> CreateNewCustomerAsync(CustomerEntity model);
        Task<SimpleResponseModel> ValidationCredentials(LoginModel model);
        Task<ResponseModel<(int, string)>> GetUserDatas(string email);
    }
}
