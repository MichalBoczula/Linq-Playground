using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models.Inventory
{
    public partial class InventoryCustomer
    {
        public InventoryCustomer()
        {
            Orders = new HashSet<InventoryOrders>();
        }

        public decimal? SalesmanId { get; set; }
        public decimal CustomerId { get; set; }
        public string CustName { get; set; }
        public string City { get; set; }
        public decimal? Grade { get; set; }

        public virtual ICollection<InventoryOrders> Orders { get; set; }
    }
}
