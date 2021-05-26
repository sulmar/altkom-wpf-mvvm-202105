using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using System.Collections.Generic;

namespace Altkom.Shop.ViewModels
{
    public class ServicesViewModel : BaseViewModel
    {
        public IEnumerable<Service> Services { get; set; }

        public Service SelectedService { get; set; }

        private readonly IServiceService serviceService;

        public ServicesViewModel(IServiceService serviceService)
        {
            this.serviceService = serviceService;


            Services = serviceService.Get();
        }
    }
}
