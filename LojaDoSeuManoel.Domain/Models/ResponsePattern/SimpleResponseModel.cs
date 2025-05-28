using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Models.ResponsePattern
{
    public class SimpleResponseModel
    {
        public SimpleResponseModel(bool status, string message)
        {
            Status = status;
            Message = message;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
