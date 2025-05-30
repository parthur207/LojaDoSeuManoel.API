using LojaDoSeuManoel.Domain.Models.Customer;
using LojaDoSeuManoel.Domain.Models.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Generic
{
    public interface IAuthGenericInterface
    {
        //Commands
        Task<SimpleResponseModel> CreateNewCustomer(CreateCustomerModel model);
        Task<ResponseModel<object?>> ValidationCredentials(LoginModel model);
    }
}
