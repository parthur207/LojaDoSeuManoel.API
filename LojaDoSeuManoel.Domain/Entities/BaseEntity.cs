using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LojaDoSeuManoel.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            Active = true;
        }

        public int Id { get; private set; }

        public DateTime CreatedAt { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        public bool Active { get; private set; }


        public void SetToInactived()
        {
            Active = false;
        }

        public void SetToActived()
        {
            Active = true;
        }

        public void SetDateUpdate()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
