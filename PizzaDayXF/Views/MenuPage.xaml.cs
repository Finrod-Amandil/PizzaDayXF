using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDayXF.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaDayXF.ViewModels;

namespace PizzaDayXF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        private readonly MenuViewModel _viewModel;
	    private readonly int _restaurantId;

	    public MenuPage(Restaurant restaurant)
	    {
	        _restaurantId = restaurant.RestaurantId;
	        InitializeComponent();
	        this.Title = "Menü — " + restaurant.Name;

            _viewModel = new MenuViewModel(Navigation, restaurant);
            this.BindingContext = _viewModel;
	    }

	    protected override async void OnAppearing()
	    {
	        await _viewModel.LoadMenuItems(_restaurantId);
            loadingInformation.IsVisible = false;
            menuItemList.IsVisible = true;
	    }
	}
}