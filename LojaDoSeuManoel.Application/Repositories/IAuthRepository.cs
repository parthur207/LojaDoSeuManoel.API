using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Models.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Repositories
{
    public interface IAuthRepository
    {
        //Commands
        Task<SimpleResponseModel> CreateNewCustomerAsync(CustomerEntity entity);
        Task<ResponseModel<int>> ValidationCredentialsAsync(CustomerEntity entity);
    }
}
