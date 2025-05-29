using LojaDoSeuManoel.Application.DTOs.Costumer;
using LojaDoSeuManoel.Application.DTOs.Generic;
using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Models.Customer;
using LojaDoSeuManoel.Domain.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Mappers
{
    public class CustomerMapper
    {

        //Model para Entity

        public static CustomerEntity ToCreateCustomerEntity(CreateCustomerModel model)
        {
            return new
            (
                model.Name,
                model.BirthDate,
                model.Address,
                model.PhoneNumber,
                model.Email,
                model.Password
            );
        }

        public static CustomerEntity ToCustomerLoginEntity(LoginModel model)
        {
            return new CustomerEntity(model.Email, model.Password);
        }


        //entity para dto
        public static CustomerGenericDTO ToCustomerDTO(CustomerEntity entity)
        {
            return new CustomerGenericDTO 
            { 
                Name=entity.Name,
                BirthDate=entity.BirthDate,
                PhoneNumber= entity.PhoneNumber, 
                Email=entity.Email,
                Role= entity.Role, 
                OrderList=entity.OrderList, 
                Active=entity.Active 
            };
        }

     

    }
}
