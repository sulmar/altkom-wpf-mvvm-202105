using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Altkom.Shop.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        private string selectedView;

        public string SelectedView
        {
            get => selectedView; set
            {
                selectedView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowViewCommand { get; private set; }

        public ShellViewModel()
        {
            ShowViewCommand = new DelegateCommand<string>(ShowView);
        }

        private void ShowView(string view)
        {
            SelectedView = view;
        }
    }
}
