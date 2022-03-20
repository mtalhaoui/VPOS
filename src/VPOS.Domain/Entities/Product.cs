using System;
using System.ComponentModel.DataAnnotations;
using VPOS.Domain.Enums;

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
    }
}
