using LojaDoSeuManoel.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Generic
{
    public interface IOrderGenericInterface
    {

        Task<SimpleResponseModel> UpdateOrderToCancelled(int OrderId);
    }
}
