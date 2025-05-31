using LojaDoSeuManoel.Domain.Entities;
using LojaDoSeuManoel.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.UseCases
{
    public class BoxPackingUseCase : BoxEntity
    {
        public static List<string> CalculateBoxes(List<ProductGameEntity> products)
        {
            var productVolumes = products.Select(p => p.Height * p.Width * p.Length).ToList();
            var totalVolume = productVolumes.Sum();

            var boxes = new List<BoxEntity>
            {
                new BoxPackingUseCase { BoxType =BoxTypeEnum.One, Height = 30, Width = 40, Length = 80 },//96
                new BoxPackingUseCase { BoxType = BoxTypeEnum.Two, Height = 80, Width = 50, Length = 40 },//160
                new BoxPackingUseCase { BoxType = BoxTypeEnum.Three, Height = 50, Width = 80, Length = 60 }//240
            };

            var usedBoxes = new List<string>();

            while (totalVolume > 0)
            {
                var box = boxes.OrderByDescending(b => b.Volume)
                               .FirstOrDefault(b => b.Volume <= totalVolume);

                if (box == null)
                {
                    box = boxes.OrderByDescending(b => b.Volume).First();
                }

                usedBoxes.Add(box.BoxType.ToString());
                totalVolume -= box.Volume;
            }

            return usedBoxes;
        }
    }
}
