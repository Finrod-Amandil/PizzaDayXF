using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PizzaDayXF.Models;
using PizzaDayXF.Services;
using Xamarin.Forms;
using MenuItem = PizzaDayXF.Models.MenuItem;

namespace PizzaDayXF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItem> _menuItems = new ObservableCollection<MenuItem>();

        public ICommand ImageTappedCommand { get; private set; }
        public INavigation Navigation { get; private set; }

        public Restaurant Restaurant { get; set; }
        public ObservableCollection<MenuItem> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public MenuViewModel(INavigation navigation, Restaurant restaurant)
        {
            Restaurant = restaurant;
            Navigation = navigation;
            ImageTappedCommand = new Command<MenuItem>(Redirect);
        }

        public async Task LoadMenuItems(int restaurantId)
        {
            ApiService service = new ApiService();

            _menuItems = new ObservableCollection<MenuItem>();
            var menuItems = await service.GetMenuItemsAsync(restaurantId);
            foreach (var menuItem in menuItems)
            {
                menuItem.VariationString = "";
                menuItem.Variations.ForEach(v => menuItem.VariationString += v.Description + " - CHF " + v.Price + "\n");
                menuItem.ImageUri =
                    $"https://pizzaday.noser.com/img/content/restaurants/{menuItem.RestaurantId}/menu/{menuItem.MenuItemId}.png";

                _menuItems.Add(menuItem);
            }

            MenuItems = new ObservableCollection<MenuItem>(_menuItems);
        }

        private async void Redirect(MenuItem menuItem)
        {
            await Navigation.PushAsync(new MenuItemImagePage(menuItem));
        }
    }
}
