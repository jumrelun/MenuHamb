using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuHamb
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "PA",
                IconSource = "icon.png",
                TargetType = typeof(PageA)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "PB",
                IconSource = "icon.png",
                TargetType = typeof(PageB)
            });

            listView.ItemsSource = masterPageItems;


        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                //var page = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                App.MasterDetail.Detail.Navigation.PushAsync((Page)Activator.CreateInstance(item.TargetType));
                listView.SelectedItem = null;
                App.MasterDetail.IsPresented = false;
            }
        }
    }
}
