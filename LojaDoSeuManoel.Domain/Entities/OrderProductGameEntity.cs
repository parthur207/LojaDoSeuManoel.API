using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entities
{
    public class OrderProductGameEntity : BaseEntity
    {
        public OrderProductGameEntity(Guid orderId, Guid productGameId, int quantity)
        {
            OrderId = orderId;
            ProductGameId = productGameId;
            Quantity = quantity;
        }

        public Guid OrderId { get; private set; }
        public OrderEntity Order { get; private set; }

        public Guid ProductGameId { get; private set; }
        public ProductGameEntity ProductGame { get; private set; }

        public int Quantity { get; private set; }
    }
}
