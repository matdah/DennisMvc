using System;
using System.ComponentModel.DataAnnotations;

namespace DennisMvc.Models
{
    public class Destinations
    {
        // Properties
        public int Id { get; set; }

        [Required]
        public String? DestinationName { get; set; }

        [Required]
        public String? DestinationUrl { get; set; }
    }
}
