using LojaDoSeuManoel.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public CustomerEntity(string email, string password)//para validação de login
        {
            Email = email;
            Password = password;
        }


        public CustomerEntity(string name, DateOnly birthDate, string address, int? phoneNumber, string email, string password)
        {
            Name = name;
            BirthDate = birthDate;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Role = RolesTypes.Customer;
            OrderList = new List<OrderEntity>();
        }

        

        public string Name { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public string Address { get; private set; }
        public int? PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public List<OrderEntity>? OrderList { get; private set; }

    }
}
