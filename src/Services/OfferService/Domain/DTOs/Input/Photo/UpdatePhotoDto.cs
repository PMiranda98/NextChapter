using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Input.Photo
{
    public class UpdatePhotoDto
    {
        public required string Id { get; set; }
        public required string Url { get; set; }
    }
}
