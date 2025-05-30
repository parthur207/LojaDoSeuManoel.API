using LojaDoSeuManoel.Application.Interfaces.Generic;

using LojaDoSeuManoel.Application.Mappers;
using LojaDoSeuManoel.Application.Repositories;
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
        private readonly IAuthRepository _authRepository;

        public async Task<SimpleResponseModel> CreateNewCustomer(CreateCustomerModel model)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            if (model is null)
            {
                response.Status = false;
                response.Message = "Um mais dados estão nulos.";
                return response;
            }

            var CustomerMapped = CustomerMapper.ToCreateCustomerEntity(model);

            var responseRespository = await _authRepository.CreateNewCustomerAsync(CustomerMapped);

            if (responseRespository.Status is false)
            {
                return responseRespository;
            }

            response.Status = true;
            response.Message = "Cliente cadastrado com sucesso.";
            return response;
        }

        public async Task<ResponseModel<object?>> ValidationCredentials(LoginModel model)
        {
            ResponseModel<object?> response = new ResponseModel<object?>();
            if (model is null)
            {
                response.Status = false;
                response.Message = "Dados de login inválidos.";
                return response;
            }

            var customerMapped = CustomerMapper.ToCustomerLoginEntity(model);

            var responseRepository =await _authRepository.ValidationCredentialsAsync(customerMapped);

            if (responseRepository.Status ==false)
            {
                response.Status = false;
                response.Message = responseRepository.Message;

                return response;
            }

            response.Status = true;
            response.Message = "Login realizado com sucesso.";
            response.Content = responseRepository.Content;
            return response;
        }
    }
}
