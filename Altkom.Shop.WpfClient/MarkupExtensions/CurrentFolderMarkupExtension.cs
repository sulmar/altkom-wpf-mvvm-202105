using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Altkom.Shop.WpfClient.MarkupExtensions
{
    public class CurrentFolderMarkupExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Environment.CurrentDirectory;
        }
    }
}
