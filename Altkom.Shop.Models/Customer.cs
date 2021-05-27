using System;
using System.ComponentModel;

namespace Altkom.Shop.Models
{
    public class Customer : BaseEntity, IEditableObject, ICloneable
    {
        //private string firstName;
        //private string lastName;

        //public string FirstName
        //{
        //    get => firstName;
        //    set
        //    {
        //        firstName = value;

        //        OnPropertyChanged();
        //        OnPropertyChanged(nameof(FullName));
        //    }
        //}
        //public string LastName
        //{
        //    get => lastName; set
        //    {
        //        lastName = value;

        //        OnPropertyChanged();
        //        OnPropertyChanged(nameof(FullName));
        //    }
        //}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Avatar { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal? CreditAmount { get; set; }
        public Address InvoiceAddress { get; set; }
        public Address ShipAddress { get; set; }
        public bool IsRemoved { get; set; }


        public Customer()
        {
            InvoiceAddress = new Address();
            ShipAddress = new Address();
        }


        #region IEditableObject

        private Customer memento;

        public void BeginEdit()
        {
            memento = (Customer) this.Clone();
        }

        public void CancelEdit()
        {
            this.FirstName = memento.FirstName;
            this.LastName = memento.LastName;
            this.Email = memento.Email;
            this.InvoiceAddress = memento.InvoiceAddress;
            this.ShipAddress = memento.ShipAddress;

            // można zautomatyzować za pomocą Reflection
        }

        public void EndEdit()
        {
            memento = null;
        }
        #endregion

        #region IClonable

        public object Clone()
        {
            // głęboka kopia
            Customer clone = (Customer) this.MemberwiseClone();
            clone.InvoiceAddress = (Address) this.InvoiceAddress.Clone();
            clone.ShipAddress = (Address) this.ShipAddress.Clone();

            return clone;

            // FastDeepCloner
            // https://github.com/AlenToma/FastDeepCloner

            // return this.MemberwiseClone();  // Płytka kopia (shallow copy)
        }

        #endregion

    }

}
