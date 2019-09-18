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
	public partial class contributorDetailPage : ContentPage
	{
		public contributorDetailPage (string contributor_id, string contributor_name, string contributor_phone_number, string contributor_email, string contributor_address)
		{
			InitializeComponent ();

            contributor_name_label.Text = contributor_name;
            contributor_phone_number_label.Text = contributor_phone_number;
            contributor_email_label.Text = contributor_email;
            contributor_address_label.Text = contributor_address;
            
            profile.Source = ImageSource.FromFile("profile.png");
		}
	}
}