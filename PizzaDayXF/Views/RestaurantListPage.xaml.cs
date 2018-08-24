using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDayXF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaDayXF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestaurantListPage : ContentPage
	{
	    private readonly RestaurantListViewModel _viewModel;

	    public RestaurantListPage()
	    {
            _viewModel = new RestaurantListViewModel(Navigation);
	        InitializeComponent();
	        this.BindingContext = _viewModel;
	    }

	    protected override async void OnAppearing()
	    {
	        await _viewModel.LoadRestaurants();
	        loadingInformation.IsVisible = false;
	        restaurantList.IsVisible = true;
	    }
    }
}