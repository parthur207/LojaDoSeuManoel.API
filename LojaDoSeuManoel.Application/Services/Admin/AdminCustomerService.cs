using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Application.Interfaces.Admin;
using LojaDoSeuManoel.Application.Mappers;
using LojaDoSeuManoel.Application.Repositories;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Services.Admin
{
    public class AdminCustomerService : IAdminCustomerInterface
    {
        private readonly ICustomerRepository _customerRepository;
        public AdminCustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<SimpleResponseModel> ActiveCustomerAdmin(string Email)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            if (string.IsNullOrEmpty(Email))
            {
                response.Status = false;
                response.Message = "O email não pode ser nulo ou vazio.";
                return response;
            }

            var responseRepository = await _customerRepository.ActiveCustomerAsync(Email);

            if (responseRepository.Status is false)
            {
                return responseRepository;
            }

            response.Status = true;
            response.Message = "Cliente ativado com sucesso.";
            return response;
        }

        public async Task<ResponseModel<List<CustomerGenericDTO>?>> GetAllCustomersAdmin()
        {
            ResponseModel<List<CustomerGenericDTO>?> response = new ResponseModel<List<CustomerGenericDTO>?>();
            
            var customers = await _customerRepository.GetAllCustomersAsync();

            if (customers.Content is null || !customers.Content.Any())
            {
                response.Message = "Sem resultados para clientes.";
                response.Status = false;
                return response;
            }
            foreach(var customer in customers.Content)
            {
                var customerMapped = CustomerMapper.ToCustomerDTO(customer);
                response.Content.Add(customerMapped);

            }
            response.Status = true;
            return response;
        }

        public async Task<ResponseModel<CustomerGenericDTO?>> GetCustomerByEmailAdmin(string email)
        {
            ResponseModel<CustomerGenericDTO?> response= new ResponseModel<CustomerGenericDTO?>();

            if (string.IsNullOrEmpty(email))
            {
                response.Status = false;
                response.Message = "O email não pode ser nulo ou vazio.";
                return response;
            }

            var customer = await _customerRepository.GetCustomerByEmailAsync(email);

            if (customer.Content is null)
            {
                response.Status = false;
                response.Message = "Cliente não encontrado.";
                return response;
            }
            response.Content = CustomerMapper.ToCustomerDTO(customer.Content);
            response.Status = true;
            return response;
        }

        public async Task<SimpleResponseModel> InactivateCustomerAdmin(string Email)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();

            if (string.IsNullOrEmpty(Email))
            {
                response.Status = false;
                response.Message = "O email não pode ser nulo ou vazio.";
                return response;
            }

            var responseRepository = await _customerRepository.InactivateCustomerAsync(Email);

            if (responseRepository.Status is false)
            {
                return responseRepository;
            }

            response.Status = true;
            response.Message = "Cliente inativado com sucesso.";
            return response;
        }
    }
}
