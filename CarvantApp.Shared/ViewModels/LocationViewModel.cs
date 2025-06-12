using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarvantApp.Shared.ViewModels
{
    public partial class LocationViewModel
    {
        public string? Zip { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? County { get; set; }

        public double? Latitude { get; set; }

        public double? Longtitude { get; set; }

        public int Id { get; set; }
    }
}
