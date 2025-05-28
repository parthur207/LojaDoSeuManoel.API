using LojaDoSeuManoel.Domain.Enuns;
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
            OrderStatus = OrderStatusEnum.Pending;
        }

        public List<ProductGameEntity> OrderList { get; private set; }
        public OrderStatusEnum OrderStatus { get; private set; }
        public int CustomerId { get; private set; }
        public CustomerEntity Costumer { get; private set; }
        public decimal TotalValue { get; private set; }


        public void UpdateOrderStatus(OrderStatusEnum NewStatus)
        {
            if (NewStatus == OrderStatus)
            {
                return;
            }
            OrderStatus = NewStatus;
        }
        public void CalculateTotalValue()
        {
            TotalValue = OrderList
            .Where(x => x. != null)
            .Sum(x => (decimal)x.Quantity * (decimal)x.Product.Price);
        }
    }
}
