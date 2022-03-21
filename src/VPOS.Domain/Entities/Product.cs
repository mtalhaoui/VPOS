using System;
using System.ComponentModel.DataAnnotations;
using VPOS.Domain.Enums;
using VPOS.Domain.Exceptions;

namespace VPOS.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
        public ProductStatus Status { get; private set; }

        public void ChangeStatus(ProductStatus status)
        {
            Status = status;
        }

        public void SellProduct()
        {
            if (Status == ProductStatus.Sold)
            {
                throw new ProductAlreadySoldException(Name);
            }
            else if (Status == ProductStatus.Damaged)
            {
                throw new ProductIsDamagedException(Name);
            }

            Status = ProductStatus.Sold;
        }
    }
}
