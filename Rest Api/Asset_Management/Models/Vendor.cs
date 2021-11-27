using System;
using System.Collections.Generic;

namespace Asset_Management.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public int Vid { get; set; }
        public string VdName { get; set; }
        public string VdType { get; set; }
        public int? VdTypeId { get; set; }
        public DateTime? VdFrom { get; set; }
        public DateTime? VdTo { get; set; }
        public string VdAddress { get; set; }

        public virtual AssetType VdTypeNavigation { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
