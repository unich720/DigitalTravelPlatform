using System;
using System.Collections.Generic;

#nullable disable

namespace DTP.Entity.Models
{
    public partial class RoutePlace
    {
        public short? RouteId { get; set; }
        public short? PlaceId { get; set; }

        public virtual Place Place { get; set; }
        public virtual Route Route { get; set; }
    }
}
