using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Output.Photos
{
    public class PhotoUploadResult
    {
        public required string PublicId { get; set; }
        public required string Url { get; set; }
    }
}
