using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Altkom.Shop.Models.SearchCriterias
{
    public abstract class SearchCriteria : Base
    {

    }

    public class ProductSearchCriteria : SearchCriteria, IDataErrorInfo, INotifyDataErrorInfo
    {
        public string Color { get; set; }
        public decimal? UnitPriceFrom { get; set; }
        public decimal? UnitPriceTo { get; set; }
        public float? WeightFrom { get; set; }
        public float? WeightTo { get; set; }





        #region IDataErrorInfo

        // ValidatesOnDataErrors
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                if (columnName==nameof(UnitPriceFrom))
                {
                    if (UnitPriceFrom < 0)
                        return $"Poza zakresem";
                }

                if (columnName == nameof(UnitPriceTo))
                {
                    if (UnitPriceTo > 100)
                        return $"Poza zakresem";
                }

                return string.Empty;
               
            }
        }

        #endregion

        public ProductSearchCriteria()
        {
            UnitPriceFrom = 0;
            UnitPriceTo = 1000;
        }

        #region INotifyDataErrorInfo

        // ValidatesOnNotifyDataErrors
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => throw new NotImplementedException();
        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class CustomerSearchCriteria : SearchCriteria
    {

    }

    public class ServiceSearchCriteria : SearchCriteria
    {

    }
}
