using System;
using System.ComponentModel;

namespace Altkom.Shop.Models
{
    public class Caretaker
    {
        public static void Clone(ref Customer memento, Customer customer )
        {
            customer = (Customer)memento.Clone();
        }
    }

    // https://www.pluralsight.com/guides/property-copying-between-two-objects-using-reflection
    public class PropertyCopier<TParent, TChild> where TParent : class
                                            where TChild : class
    {
        public static void Copy(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType && childProperty.CanWrite)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }
    }

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
            memento = (Customer)this.Clone();

            this.ResetDirty();
        }

        public void CancelEdit()
        {
            //this.FirstName = memento.FirstName;
            //this.LastName = memento.LastName;
            //this.Email = memento.Email;
            //this.InvoiceAddress = memento.InvoiceAddress;
            //this.ShipAddress = memento.ShipAddress;

            // można zautomatyzować za pomocą Reflection

            PropertyCopier<Customer, Customer>.Copy(memento, this);

            this.ResetDirty();
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
            Customer clone = (Customer)this.MemberwiseClone();
            clone.InvoiceAddress = (Address)this.InvoiceAddress.Clone();
            clone.ShipAddress = (Address)this.ShipAddress.Clone();

            return clone;

            // FastDeepCloner
            // https://github.com/AlenToma/FastDeepCloner

            // return this.MemberwiseClone();  // Płytka kopia (shallow copy)
        }

        #endregion

    }

}
