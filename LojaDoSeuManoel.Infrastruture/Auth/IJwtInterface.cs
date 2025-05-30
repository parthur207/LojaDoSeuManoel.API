using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infrastructure.Auth
{
    public interface IJwtInterface
    {
        string GenerateToken(int UserId, string userType);
    }
}
