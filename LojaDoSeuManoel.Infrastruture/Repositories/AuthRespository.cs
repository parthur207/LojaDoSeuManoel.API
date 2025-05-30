using LojaDoSeuManoel.Application.Repositories;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Models.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using LojaDoSeuManoel.Infrastructure.Persistense;
using LojaDoSeuManoel.Infrastruture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastruture.Repositories
{
    public class AuthRespository : IAuthRepository
    {
        private readonly LojaDoSeuManoelDbContext _context;
        public AuthRespository(LojaDoSeuManoelDbContext context)
        {
            _context = context;
        }

        public async Task<SimpleResponseModel> CreateNewCustomerAsync(CustomerEntity entity)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                if (entity is null)
                {

                    response.Status = false;
                    response.Message = "Erro. Dados vazios.";
                    return response;
                }

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                response.Status = true;
                response.Message = "Cadastro realizado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"An error occurred while creating the customer: {ex.Message}";
                return response;
            }
        }
        public async Task<ResponseModel<int>> ValidationCredentialsAsync(CustomerEntity login)
        {
            ResponseModel<int> response = new ResponseModel<int>();

            try
            {
                if (login is null)
                {
                    response.Status = false;
                    response.Message = "Dados de login inválidos.";
                    return response;
                }

                var userExists = await _context.Customer.AnyAsync(x => x.Email == login.Email && x.Password == login.Password);

                if (userExists is false)
                {
                    response.Status = false;
                    response.Message = "Dados de login inválidos.";
                    return response;
                }

                var UserId = await _context.Customer
                    .Where(x => x.Email == login.Email && x.Password == login.Password)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();

                response.Content = UserId;
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

        public async Task<ResponseModel<int>> GetUserDataAsync(string Email)
        {
            ResponseModel<int> response = new ResponseModel<int>();
            try
            {
                if (string.IsNullOrEmpty(Email))
                {
                    response.Status = false;
                    response.Message = "Email inválido.";
                    return response;
                }

                var userExists = await _context.Customer.AnyAsync(x => x.Email == Email);

                if (userExists is false)
                {
                    response.Status = false;
                    response.Message = "Usuário não encontrado.";
                    return response;
                }

                var userId = await _context.Customer
                   .Where(x => x.Email == Email)
                   .Select(x => (int)x.Id)//casting
                   .FirstOrDefaultAsync();

                response.Content = userId;
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
    }
}

