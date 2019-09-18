using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnxietyNZ
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class overview : ContentPage
	{
		public overview ()
		{
			InitializeComponent ();

            OverviewIcon.Source = ImageSource.FromFile("anxietynz.png");
        }
	}
}