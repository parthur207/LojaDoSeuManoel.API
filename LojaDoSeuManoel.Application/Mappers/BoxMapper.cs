using LojaDoSeuManoel.Application.DTOs.Admin;
using LojaDoSeuManoel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Mappers
{
    public class BoxMapper
    {

        public static BoxAdminDTO ToBoxDTO(BoxEntity entity)
        {
            return new BoxAdminDTO 
            { 
                BoxType=entity.BoxType, 
                Height=entity.Height, 
                Width=entity.Width, 
                Length=entity.Length,
                Volume = entity.Volume,
                CreatedAt= entity.CreatedAt 
            };
        }
    }
}
