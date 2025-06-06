﻿using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs.Generic
{
    public class OrderGenericDTO
    {
        public List<OrderProductGameEntity> OrderList { get; set; }
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalValue { get; set; }
        public OrderStatusEnum Status { get; set; }
        public BoxTypeEnum BoxType { get; set; } // 1, 2 ou 3
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

    }
}
