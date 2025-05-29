using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Models.ResponsePattern
{
    public class ResponseModel <T>
    {
        public ResponseModel(){ }

        public T? Content { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
