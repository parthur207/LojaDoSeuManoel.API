using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using LojaDoSeuManoel.Infrastruture.Persistense;
using LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository;
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

        public async Task<SimpleResponseModel> ActiveCustomeAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<CustomerGenericDTO>?>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<CustomerGenericDTO?>> GetCustomerByEmailAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> InactivateCustomerAsync(string Email)
        {
            throw new NotImplementedException();
        }
    }
}
