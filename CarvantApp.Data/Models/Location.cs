using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarvantApp.Data.Models;

public partial class Location
{
    //public Guid UniqueId { get; set; }
    public string? Zip { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? County { get; set; }

    public double? Latitude { get; set; }

    public double? Longtitude { get; set; }
    [Key]
    public int Id { get; set; }
}
