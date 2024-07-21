using Application.DTOs.Input.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Input.Advertisements
{
    public class UpdatedAdvertisementDto
    {
        public Guid Id { get; set; }
        public required UpdatedItemDto Item { get; set; }
    }
}
