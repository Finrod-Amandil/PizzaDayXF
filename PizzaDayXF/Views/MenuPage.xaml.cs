using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaDayXF.ViewModels;

namespace PizzaDayXF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        private readonly MenuViewModel _viewModel = new MenuViewModel();
	    private readonly int _restaurantId;

	    public MenuPage(int restaurantId)
	    {
	        _restaurantId = restaurantId;
	        InitializeComponent();
            this.BindingContext = _viewModel;
	    }

	    protected override async void OnAppearing()
	    {
	        await _viewModel.LoadMenuItems(_restaurantId);
            loadingInformation.IsVisible = false;
            menuItemList.IsVisible = true;
	    }

	    private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	    {
	        Console.WriteLine("Tapped.");
        }
	}
}