using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using PizzaDayXF.Models;
using PizzaDayXF.Services;

namespace PizzaDayXF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItem> _menuItems = new ObservableCollection<MenuItem>();

        public ObservableCollection<MenuItem> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public async Task LoadMenuItems(int restaurantId)
        {
            ApiService service = new ApiService();

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
    }
}
