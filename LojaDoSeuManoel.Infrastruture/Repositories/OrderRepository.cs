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
    public class OrderRepository : IOrderRepository
    {

        private readonly LojaDoSeuManoelDbContext _dbContext;
        public OrderRepository(LojaDoSeuManoelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<List<OrderGenericDTO>?>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<OrderGenericDTO>?>> GetOrderByCustomerAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<OrderGenericDTO>?>> GetOrderByIdAsync(int OrderId)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> UpdateOrderToCancelledAsync(int OrderId)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> UpdateStatusToDeliveredAsync(int OrderId)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> UpdateStatusToProcessingAsync(int OrderId)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> UpdateStatusToReturnedAsync(int OrderId)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> UpdateStatusToShippedAsync(int OrderId)
        {
            throw new NotImplementedException();
        }
    }
}
