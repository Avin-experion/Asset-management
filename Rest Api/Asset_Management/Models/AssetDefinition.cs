using System;
using System.Collections.Generic;

namespace Asset_Management.Models
{
    public partial class AssetDefinition
    {
        public AssetDefinition()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public int AdId { get; set; }
        public string AdName { get; set; }
        public int AdTypeId { get; set; }
        public string AdClass { get; set; }

        public virtual AssetType AdType { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
