using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItemListDelete.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemViewTemplate : ContentView
    {
        public ItemViewTemplate()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ParentContextProperty =
           BindableProperty.Create("ParentContext", typeof(object), typeof(ItemViewTemplate), null, propertyChanged: OnParentContextPropertyChanged);

        public object ParentContext
        {
            get { return GetValue(ParentContextProperty); }
            set { SetValue(ParentContextProperty, value); }
        }

        private static void OnParentContextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && newValue != null)
            {
                (bindable as ItemViewTemplate).ParentContext = newValue;
            }
        }
    }
}