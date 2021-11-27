using System;
using System.Collections.Generic;

namespace Asset_Management.Models
{
    public partial class AssetType
    {
        public AssetType()
        {
            AssetDefinition = new HashSet<AssetDefinition>();
            PurchaseOrder = new HashSet<PurchaseOrder>();
            Vendor = new HashSet<Vendor>();
        }

        public int AssetId { get; set; }
        public string AssetName { get; set; }

        public virtual ICollection<AssetDefinition> AssetDefinition { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual ICollection<Vendor> Vendor { get; set; }
    }
}
