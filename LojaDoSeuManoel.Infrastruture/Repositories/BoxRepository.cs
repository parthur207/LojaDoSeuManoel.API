using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Enuns;
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
    public class BoxRepository : IBoxRepository
    {

        private readonly LojaDoSeuManoelDbContext _dbContext;

        public BoxRepository(LojaDoSeuManoelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseModel<List<BoxAdminDTO>?>> GetAllBoxesAdminAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<BoxAdminDTO>?> GetBoxByTypeAdminAsync(BoxTypeEnum Type)
        {
            throw new NotImplementedException();
        }
    }
}
