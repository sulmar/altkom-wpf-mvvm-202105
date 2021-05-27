using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Shop.IServices
{
    public interface IMesageBoxService
    {
        bool ShowDialog(string title, string message);

    }
}
