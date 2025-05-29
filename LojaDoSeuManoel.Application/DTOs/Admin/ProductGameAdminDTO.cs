using LojaDoSeuManoel.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs.Admin
{
    public class ProductGameAdminDTO
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public decimal Price { get;  set; }
        public decimal Height { get;  set; }
        public decimal Width { get;  set; }
        public decimal Length { get;  set; }
        public int Stock { get;  set; }
        public int Sales { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public ProductGameStatusEnum Status { get;  set; }
        public ProductGameCategoryEnum Category { get;  set; }
        public string? ImageUrl { get;  set; }

    }
}
