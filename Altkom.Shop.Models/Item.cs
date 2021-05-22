using System.Collections.Generic;
using System.Text;

namespace Altkom.Shop.Models
{
    public abstract class Item : BaseEntity
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
