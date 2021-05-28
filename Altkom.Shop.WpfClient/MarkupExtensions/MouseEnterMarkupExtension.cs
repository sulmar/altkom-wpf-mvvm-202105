using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Altkom.Shop.WpfClient.MarkupExtensions
{
    public class MouseEnterMarkupExtension : MarkupExtension
    {
        public int Offset { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new MouseEventHandler(OnMouseEventHandler);
        }

        private void OnMouseEventHandler(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;

            button.Width += Offset;
            button.Height += Offset;
        }
    }
}
