using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models.Inventory
{
    public partial class InventorySalesman
    {
        public InventorySalesman()
        {
            Orders = new HashSet<InventoryOrders>();
        }

        public decimal SalesmanId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public decimal? Commission { get; set; }

        public virtual ICollection<InventoryOrders> Orders { get; set; }
    }
}
