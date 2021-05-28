using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Altkom.Shop.WpfClient.Behaviors
{
    // dotnet add package Microsoft.Xaml.Behaviors.Wpf
    public class MouseEnterButtonBehavior : Behavior<Button>
    {
        // public double Offset { get; set; }

        public double Offset
        {
            get { return (double)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Offset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetProperty =
            DependencyProperty.Register(nameof(Offset), typeof(double), typeof(MouseEnterButtonBehavior), new PropertyMetadata(0d, MyCallback));

        private static void MyCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MouseEnterButtonBehavior behavior = (MouseEnterButtonBehavior)d;

            Button button = (Button)behavior.AssociatedObject;
            button.Width += (double) e.NewValue;
            button.Height += (double) e.NewValue;

        }

        protected override void OnAttached()
        {
            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
        }

        private void AssociatedObject_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            AssociatedObject.Width += Offset;
            AssociatedObject.Height += Offset;
        }
    }
}
