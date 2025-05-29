using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using LojaDoSeuManoel.Infrastruture.Persistense;
using LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastruture.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LojaDoSeuManoelDbContext _dbContext;
        public CustomerRepository(LojaDoSeuManoelDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<ResponseModel<List<CustomerEntity>?>> GetAllCustomersAsync()
        {
            ResponseModel<List<CustomerEntity>?> response = new ResponseModel<List<CustomerEntity>?>();
            try
            {

                var customers = await _dbContext.Customer.Include(x=>x.OrderList).ToListAsync();

                if(customers is null || !customers.Any())
                {
                    response.Status = false;
                    response.Message = "Nenhum cliente encontrado.";
                    return response;
                }

                response.Content = customers;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<CustomerEntity?>> GetCustomerByEmailAsync(string Email)
        {
           
            ResponseModel<CustomerEntity?> response = new ResponseModel<CustomerEntity?>();
            try
            {
                var customer = await _dbContext.Customer.Include(x => x.OrderList).FirstOrDefaultAsync(x => x.Email == Email);

                if (customer is null)
                {
                    response.Status = false;
                    response.Message = "Cliente não encontrado.";
                    return response;
                }

                response.Content = customer;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> ActiveCustomerAsync(string email)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {

                var Customer = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Email == email);

                if (Customer is null)
                {
                    response.Status = false;
                    response.Message = "Cliente não encontrado.";
                    return response;
                }

                if (Customer.Active is true)
                {
                    response.Status = false;
                    response.Message = "Cliente já está ativo.";
                    return response;
                }

                Customer.SetToActived();
                Customer.SetDateUpdate();
                _dbContext.Customer.Update(Customer);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = "Cliente ativado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> InactivateCustomerAsync(string Email)
        {
           SimpleResponseModel response= new SimpleResponseModel();

            try
            {
                var Customer = await _dbContext.Customer.FirstOrDefaultAsync(x => x.Email == Email);

                if (Customer is null)
                {
                    response.Status = false;
                    response.Message = "Cliente não encontrado.";
                    return response;
                }

                if (Customer.Active is false)
                {
                    response.Status = false;
                    response.Message = "Cliente já está inativo.";
                    return response;
                }

                Customer.SetToInactived();
                Customer.SetDateUpdate();
                _dbContext.Customer.Update(Customer);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = "Cliente inativado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }
    }
}
