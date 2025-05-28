using LojaDoSeuManoel.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Models.Admin
{
    public class UpdateProductGameModel
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public ProductGameStatusEnum Status { get; private set; }
        public ProductGameCategoryEnum Category { get; private set; }
        public string? ImageUrl { get; private set; }

    }
}
