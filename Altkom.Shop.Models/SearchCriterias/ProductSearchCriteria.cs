using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.Shop.Models.SearchCriterias
{
    public abstract class SearchCriteria : Base
    {

    }

    public class ProductSearchCriteria : SearchCriteria
    {
        public string Color { get; set; }
        public decimal? UnitPriceFrom { get; set; }
        public decimal? UnitPriceTo { get; set; }
        public float? WeightFrom { get; set; }
        public float? WeightTo { get; set; }

        public ProductSearchCriteria()
        {
            UnitPriceFrom = 0;
            UnitPriceTo = 1000;
        }
    }

    public class CustomerSearchCriteria : SearchCriteria
    {

    }

    public class ServiceSearchCriteria : SearchCriteria
    {

    }
}
