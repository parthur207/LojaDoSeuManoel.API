using LojaDoSeuManoel.Infrastruture.Persistense;
using LojaDoSeuManoel.Infrastruture.Repositories.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastruture.Repositories
{
    public class ProductGameRepository : IProductGameRepository
    {

        private readonly LojaDoSeuManoelDbContext _Dbcontext;

        public ProductGameRepository(LojaDoSeuManoelDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }
    }
}
