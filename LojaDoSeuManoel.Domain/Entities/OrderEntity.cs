using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        public OrderEntity(List<ProductGameEntity> orderList)
        {
            OrderList = orderList;
        }

        public List<ProductGameEntity> OrderList { get; private set; }

    }
}
