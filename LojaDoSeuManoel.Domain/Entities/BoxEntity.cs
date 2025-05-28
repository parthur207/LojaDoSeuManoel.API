using LojaDoSeuManoel.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entities
{
    public class BoxEntity : BaseEntity
    {
        public BoxTypeEnum BoxType { get; private set; }//Tipos: 1, 2 ou 3
        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public decimal Length { get; private set; }

        //Volume = Height * Width * Length;
    }
}
