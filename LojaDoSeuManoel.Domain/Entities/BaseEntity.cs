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

        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public bool Active { get; private set; }


        public void SetAsInactived()
        {
            Active = false;
        }

        public void SetDateUpdate()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
