using LojaDoSeuManoel.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs.Admin
{
    public class BoxAdminDTO
    {
        public BoxTypeEnum BoxType { get;  set; }
        public decimal Height { get;  set; }
        public decimal Width { get;  set; }
        public decimal Length { get;  set; }
        public decimal Volume { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }
}
