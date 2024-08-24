using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Output.Photo
{
    public class PhotoDto
    {
        public required string Id { get; set; }
        public required string Url { get; set; }
    }
}
