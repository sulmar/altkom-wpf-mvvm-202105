using System;

namespace Altkom.Shop.Models
{
    public class Customer : BaseEntity
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string LastName
        {
            get => lastName; set
            {
                lastName = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FullName => $"{FirstName} {LastName}";
        public CustomerType CustomerType { get; set; }
        public string Avatar { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal? CreditAmount { get; set; }
        public Address InvoiceAddress { get; set; }
        public Address ShipAddress { get; set; }
        public bool IsRemoved { get; set; }

    }

}
