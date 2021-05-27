using Altkom.Shop.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Altkom.Shop.WpfClient
{
    public class WpfMessageBoxService : IMesageBoxService
    {
        public bool ShowDialog(string title, string message)
        {
            return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }
    }
}
