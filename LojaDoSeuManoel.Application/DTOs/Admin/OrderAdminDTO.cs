using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs.Admin
{
    public class OrderAdminDTO
    {
        public List<OrderProductGameEntity> OrderList { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalValue { get; set; }
        public OrderStatusEnum Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
