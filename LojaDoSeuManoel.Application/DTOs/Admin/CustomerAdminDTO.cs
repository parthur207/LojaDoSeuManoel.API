using LojaDoSeuManoel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs.Admin
{
    public class CustomerAdminDTO
    {
        public string Name { get; set; }
        public DateOnly BirthDate { get;  set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<OrderEntity>? OrderList { get; set; }
        public bool Active { get; set; }

    }
}
