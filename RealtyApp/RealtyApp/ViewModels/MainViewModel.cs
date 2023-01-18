using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;
using MvvmHelpers;
using RealtApp.Model;
using Xamarin.Forms;

namespace RealtyApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public IList<AdvertViewModel> Adverts   { get; set; }
        private INavigation _navigation;
        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Adverts = AdvertViewModel.ReadAdverts(_navigation);
        }

    }
}
