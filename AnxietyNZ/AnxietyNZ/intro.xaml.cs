﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnxietyNZ
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class intro : ContentPage
	{
		public intro ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new master.MasterDetailPage1Master());
        }
    }
}