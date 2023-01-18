using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealtApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealtyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdvertPage : ContentPage
	{
		public AdvertPage (ViewModels.AdvertViewModel advert)
		{
			InitializeComponent ();
            //advert = new Advert();
            BindingContext = advert;
            //Price.Text = advert.Name;
            //Carousel.ItemsSource = advert.Images;
            NavigationPage.SetHasNavigationBar(this, false);
            //Carousel.ItemsSource = images;
            Device.StartTimer(TimeSpan.FromSeconds(10), (Func<bool>)(() =>
            {
                Carousel.Position = (Carousel.Position + 1) % advert.Images.Count;
                return true;
            }));
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
        void LikeButton_Clicked_1(System.Object sender, System.EventArgs e)
        {            
        }

        void ShareButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        void Expander_Tapped(System.Object sender, System.EventArgs e)
        {
            if (DescTitle.IsVisible == true)
            {
                DescTitle.IsVisible = false;
                MoreBtn.IsVisible = false;
            }
            else
            {
                DescTitle.IsVisible = true;
                MoreBtn.IsVisible = true;
            }
        }

        void HideBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Expander.IsExpanded = false;
            DescTitle.IsVisible = true;
            MoreBtn.IsVisible = true;
        }

        void ScrollView_Scrolled(System.Object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
            TitleHeader.FadeTo(0, 500);
            
        }
    }
}

