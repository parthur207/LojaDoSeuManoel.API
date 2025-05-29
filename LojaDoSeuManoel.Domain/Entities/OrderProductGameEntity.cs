using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entities
{
    public class OrderProductGameEntity : BaseEntity
    {
        public OrderProductGameEntity() { }
        public OrderProductGameEntity(int orderId, int productGameId, int quantity)
        {
            OrderId = orderId;
            ProductGameId = productGameId;
            Quantity = quantity;
        }

        public OrderProductGameEntity( int productGameId, int quantity)
        {
            ProductGameId = productGameId;
            Quantity = quantity;
        }

        public int OrderId { get;  set; }
        public OrderEntity Order { get;  set; }

        public int ProductGameId { get;  set; }
        public ProductGameEntity ProductGame { get;  set; }

        public int Quantity { get;  set; }
    }
}
