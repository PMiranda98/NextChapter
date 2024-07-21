using Domain.DTOs.Input.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Output.Advertisement
{
    public class CreatedAdvertisementDto
    {
        public Guid Id { get; set; }
        public int SellingPrice { get; set; }
        public required CreateItemDto Item { get; set; }
    }
}
