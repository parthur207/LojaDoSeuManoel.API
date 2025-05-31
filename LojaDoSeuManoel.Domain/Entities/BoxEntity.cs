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

        public BoxEntity() { }
        public BoxEntity(BoxTypeEnum boxType, decimal height, decimal width, decimal length)
        {
            BoxType = boxType;
            Height = height;
            Width = width;
            Length = length;
            Volume = height*width*length;
        }

        public BoxTypeEnum BoxType { get; protected set; }//Tipos: 1, 2 ou 3
        public decimal Height { get; protected set; }
        public decimal Width { get; protected set; }
        public decimal Length { get; protected set; }
        public decimal Volume { get; protected set; }//Volume = Height * Width * Length;   
    }
}
