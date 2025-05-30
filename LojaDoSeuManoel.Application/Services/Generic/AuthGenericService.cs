using LojaDoSeuManoel.Application.Interfaces.Generic;
using LojaDoSeuManoel.Application.Interfaces.Repositories;
using LojaDoSeuManoel.Domain.Models.Customer;
using LojaDoSeuManoel.Domain.Models.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Services.Generic
{
    public class AuthGenericService : IAuthGenericInterface
    {
        private readonly IAuthRepository _authGenericInterface;

        public Task<SimpleResponseModel> CreateNewCustomer(CreateCustomerModel model)
        {
            var response = _authGenericInterface.CreateNewCustomer(model);
        }

        public Task<ResponseModel<(int, string)>> GetUserDatas(string email)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> ValidationCredentials(LoginModel model)
        {
            throw new NotImplementedException();
        }
    }
}
