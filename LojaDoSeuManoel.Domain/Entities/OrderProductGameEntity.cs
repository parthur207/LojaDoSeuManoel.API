using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entities
{
    public class OrderProductGameEntity : BaseEntity
    {
        public OrderProductGameEntity(int orderId, int productGameId, int quantity)
        {
            OrderId = orderId;
            ProductGameId = productGameId;
            Quantity = quantity;
        }

        public int OrderId { get; private set; }
        public OrderEntity Order { get; private set; }

        public int ProductGameId { get; private set; }
        public ProductGameEntity ProductGame { get; private set; }

        public int Quantity { get; private set; }
    }
}
