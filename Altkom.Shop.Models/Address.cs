using System;

namespace Altkom.Shop.Models
{
    public class Address : Base, ICloneable
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
