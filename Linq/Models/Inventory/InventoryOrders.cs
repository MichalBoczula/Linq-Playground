using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models.Inventory
{
    public partial class InventoryOrders
    {
        public decimal? SalesmanId { get; set; }
        public decimal OrdNo { get; set; }
        public decimal? PurchAmt { get; set; }
        public DateTime? OrdDate { get; set; }
        public decimal? CustomerId { get; set; }

        public virtual InventoryCustomer Customer { get; set; }
        public virtual InventorySalesman Salesman { get; set; }
    }
}
