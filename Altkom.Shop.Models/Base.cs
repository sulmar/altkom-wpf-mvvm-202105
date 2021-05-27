using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Altkom.Shop.Models
{
    public abstract class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsDirty { get; set; }

        // public event EventHandler IsDirtyChanged;

        public Base()
        {
            EnableTracking();
        }

        private void EnableTracking()
        {
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName != nameof(IsDirty))
                {
                    IsDirty = true;
                    // IsDirtyChanged?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public void ResetDirty() => IsDirty = false;
    }

}
