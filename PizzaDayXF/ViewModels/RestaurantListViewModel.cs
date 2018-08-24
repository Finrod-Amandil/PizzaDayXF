using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PizzaDayXF.Models;
using PizzaDayXF.Services;
using Xamarin.Forms;

namespace PizzaDayXF.ViewModels
{
    public class RestaurantListViewModel : ViewModelBase
    {
        private ObservableCollection<Restaurant> _restaurants = new ObservableCollection<Restaurant>();

        public ICommand RedirectCommand { get; private set; }
        public INavigation Navigation { get; private set; }

        public ObservableCollection<Restaurant> Restaurants
        {
            get => _restaurants;
            set => SetProperty(ref _restaurants, value);
        }

        public RestaurantListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            RedirectCommand = new Command<Restaurant>(Redirect);
        }

        public async Task LoadRestaurants()
        {
            _restaurants = new ObservableCollection<Restaurant>();
            ApiService service = new ApiService();

            var restaurants = await service.GetRestaurantsAsync();
            foreach (var restaurant in restaurants)
            {
                restaurant.ImageUri =
                    $"https://pizzaday.noser.com/img/content/restaurants/{restaurant.RestaurantId}/logo.png";

                _restaurants.Add(restaurant);
            }

            Restaurants = new ObservableCollection<Restaurant>(_restaurants);
        }

        private async void Redirect(Restaurant restaurant)
        {
            await Navigation.PushAsync(new MenuPage(restaurant));
        }
    }
}
