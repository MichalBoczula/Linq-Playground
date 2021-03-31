using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class PlayerBooked
    {
        public int? MatchNo { get; set; }
        public int? TeamId { get; set; }
        public int? PlayerId { get; set; }
        public int? BookingTime { get; set; }
        public string SentOff { get; set; }
        public string PlaySchedule { get; set; }
        public int? PlayHalf { get; set; }

        public virtual MatchMast MatchNoNavigation { get; set; }
        public virtual PlayerMast Player { get; set; }
    }
}
