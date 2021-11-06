using System;
using System.Collections.Generic;

#nullable disable

namespace DTP.Entity.Models
{
    public partial class Route
    {
        public short Id { get; set; }
        public string RouteName { get; set; }
        public TimeSpan? TimeOfPassage { get; set; }
    }
}
