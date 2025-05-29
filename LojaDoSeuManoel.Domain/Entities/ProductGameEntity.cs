using LojaDoSeuManoel.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entities
{
    public class ProductGameEntity : BaseEntity
    {
        public ProductGameEntity(string name, string description, decimal price, decimal height, decimal width, decimal length, int stock, ProductGameCategoryEnum category, string? imageUrl)
        {
            Name = name;
            Description = description;
            Price = price;
            Height = height;
            Width = width;
            Length = length;
            if (stock>0) 
            {
                Status = ProductGameStatusEnum.Available;
                Stock = stock;
            }
            else
            {
                Status = ProductGameStatusEnum.NoStock;
                Stock = stock;
            }
            Sales = 0;
            Category = category;
            ImageUrl = imageUrl;
        }

        public ProductGameEntity(string name, string description, decimal price, decimal height, decimal width, decimal length, string? imagemUrl)
        {
            Name = name;
            Description = description;
            Price = price;
            Length = length;
            Height = height;
            Width = width;
            ImageUrl = imagemUrl;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public decimal Length { get; private set; }
        public  int Stock { get; private set; }
        public int Sales { get; private set; }
        public ProductGameStatusEnum Status { get; private set; }
        public ProductGameCategoryEnum Category { get; private set; }
        public string? ImageUrl { get; private set; }

        public void SetProductName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName) || Name == newName)
            {
                return;
            }
            Name = newName;
        }
        public void SetProductDescription(string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newDescription) || Description == newDescription)
            {
                return;
            }
            Description = newDescription;
        }
        public void SetProductPrice(decimal newPrice)
        {
            if (newPrice <= 0 || Price == newPrice)
            {
                return;
            }
            Price = newPrice;
        }


        public void IncreaseSales(int n)
        {
            Sales += n;
        }

        public void IncreaseStock(int n)
        {
            Stock += n;
        }

        public void ReduceStock(int n)
        {
            if (Stock > 0)
            {
                Stock -= n;

                if (Stock == 0)
                {
                    Status = ProductGameStatusEnum.NoStock;
                }
            }
        }

        public bool SetProductCategory(ProductGameCategoryEnum newCategory)
        {
            if (Category == newCategory)
            {
                return false;
            }
            Category = newCategory;
            return true;
        }

        public bool SetProductStatusToAvailable()
        {
            if (Status== ProductGameStatusEnum.Available)
            {
                return false;
            }
            Status = ProductGameStatusEnum.Available;
            return true;
        }

        public bool SetProductStatusToUnavailable()
        {
            if (Status == ProductGameStatusEnum.Unavailable)
            {
                return false;
            }
            Status = ProductGameStatusEnum.Unavailable;
            return true;
        }

        public bool SetProductStatusToReserved()
        {
            if (Status == ProductGameStatusEnum.Reserved)
            {
                return false;
            }
            Status = ProductGameStatusEnum.Reserved;
            return true;
        }

        public bool SetProductStatusToSold()
        {
            if (Status == ProductGameStatusEnum.Sold)
            {
                return false;
            }
            Status = ProductGameStatusEnum.Sold;
            return true;
        }

        
    }
}
