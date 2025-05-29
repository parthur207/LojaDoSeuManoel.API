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
        public BoxTypeEnum BoxType { get; private set; }
        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public decimal Length { get; private set; }
        public decimal Volume { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
