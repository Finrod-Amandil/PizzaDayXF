using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaDayXF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuItemImagePage : ContentPage
	{
		public MenuItemImagePage(Models.MenuItem menuItem)
		{
			InitializeComponent ();
		    image.Source = menuItem.ImageUri;
		    this.Title = menuItem.Name;
		}
	}
}