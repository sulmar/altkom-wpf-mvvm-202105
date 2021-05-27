using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altkom.Shop.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderDetail> Details { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount => Details.Sum(d => d.LineAmount);

        public Order()
        {
            foreach (var detal in Details)
            {
                detal.PropertyChanged += Detal_PropertyChanged;
            }
        }

        private void Detal_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName==nameof(OrderDetail.Quantity) || e.PropertyName==nameof(OrderDetail.UnitPrice))
            {
                OnPropertyChanged(nameof(TotalAmount));
            }
        }
    }
}
