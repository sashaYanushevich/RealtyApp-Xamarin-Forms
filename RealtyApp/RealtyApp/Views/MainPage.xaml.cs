using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealtApp.Model;
using RealtyApp.ViewModels;
using RealtyApp.Views;
using Xamarin.Forms;

namespace RealtyApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        enum States
        {
            SearchExpanded,
            SearchHidden
        }

        public Advert advert { get; set; }

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            SizeChanged += MainPage_SizeChanged;
            BindingContext = new MainViewModel(this.Navigation);
        }

        Storyboard _storyboard = new Storyboard();

        const int margin = 20;
        const int animationSpeed = 250;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ScrollContainer.Scrolled += ScrollContainer_Scrolled;
        }


        private async void ScrollContainer_Scrolled(object sender, ScrolledEventArgs e)
        {
            if ((e.ScrollY > 0) && (CurrentState != States.SearchHidden))
            {
                _storyboard.Go(States.SearchHidden);
                CurrentState = States.SearchHidden;
                ScrollContainer.IsEnabled = false;
                await Task.Delay(animationSpeed);
                ScrollContainer.IsEnabled = true;
            }
            else if ((e.ScrollY == 0) && (CurrentState != States.SearchExpanded))
            {
                _storyboard.Go(States.SearchExpanded);
                CurrentState = States.SearchExpanded;
                ScrollContainer.IsEnabled = false;
                await Task.Delay(animationSpeed);
                ScrollContainer.IsEnabled = true;
            }


        }

        private void MainPage_SizeChanged(object sender, EventArgs e)
        {

            _storyboard = new Storyboard();
            var width = this.Width;
            var height = this.Height;

            // shopping cart
            Rectangle basketRect = new Rectangle(
                x: width - (FavoriteIcon.Width + margin),
                y: margin,
                width: FavoriteIcon.Width,
                height: FavoriteIcon.Height
                );
            AbsoluteLayout.SetLayoutBounds(FavoriteIcon, basketRect);

            // search icon
            Rectangle searchRect = new Rectangle(
                x: margin,
                y: 200,
                width: 250,
                height: SearchIcon.Height
                );
            AbsoluteLayout.SetLayoutBounds(SearchIcon, searchRect);

            Rectangle searchRectCollapsed = new Rectangle(
                x: FavoriteIcon.Bounds.Left - (margin + SettingsIcon.Width + margin + SearchIcon.Width) + 200,
                y: margin,
                width: 48,
                height: 48
            );

            // settings icon
            Rectangle settingsRect = new Rectangle(
                x: width - (SettingsIcon.Width + margin),
                y: 200,
                width: SettingsIcon.Width,
                height: SettingsIcon.Height
                );
            AbsoluteLayout.SetLayoutBounds(SettingsIcon, settingsRect);

            Rectangle settingsRectCollapsed = new Rectangle(
                x: FavoriteIcon.Bounds.Left - (margin + SettingsIcon.Width + ProfileIcon.Width + margin),
                y: margin,
                width: SettingsIcon.Width,
                height: SettingsIcon.Height
                );



            Rectangle searchBackgroundRect = new Rectangle(
                x: width - (SettingsIcon.Width + margin),
                y: 200,
                width: SettingsIcon.Width,
                height: SearchBackground.Height
                );
            AbsoluteLayout.SetLayoutBounds(SearchBackground, searchBackgroundRect);

            Rectangle searchBackgroundCollapsedRect = new Rectangle(
                x: FavoriteIcon.Bounds.Left - (ProfileIcon.Width + margin +margin + SettingsIcon.Width + margin + SearchIcon.Width),
                y: margin,
                width: SettingsIcon.Width,
                height: SettingsIcon.Height
            );


            // ScrollContainer
            Rectangle scrollContainerRect = new Rectangle(
                x: margin,
                y: SearchIcon.Bounds.Bottom + margin,
                width: width - (2 * margin),
                height: height - (SearchIcon.Bounds.Bottom + margin)
                );
            AbsoluteLayout.SetLayoutBounds(ScrollContainer, scrollContainerRect);

            Rectangle scrollContainerRectCollapsed = new Rectangle(
                x: margin,
                y: margin + FavoriteIcon.Height + margin,
                width: width - (2 * margin),
                height: height - (margin + FavoriteIcon.Height + margin)
                );

            // add the positions to the state machine
            _storyboard.Add(States.SearchExpanded, new[]
            {
                new ViewTransition(Header, AnimationType.Opacity, 1, animationSpeed),
                //new ViewTransition(SearchEntry, AnimationType.Opacity, 1, animationSpeed),
                new ViewTransition(SettingsIcon, AnimationType.Layout, settingsRect, animationSpeed),
                new ViewTransition(SearchIcon, AnimationType.Opacity, 1, animationSpeed),
                new ViewTransition(SearchBackground, AnimationType.Layout, searchRect, animationSpeed),
                new ViewTransition(ScrollContainer, AnimationType.Layout, scrollContainerRect, animationSpeed)
            });

            _storyboard.Add(States.SearchHidden, new[]
            {
                new ViewTransition(Header, AnimationType.Opacity, 0.01, animationSpeed),
                //new ViewTransition(SearchEntry, AnimationType.Opacity, 0.01),
                new ViewTransition(SettingsIcon, AnimationType.Layout, settingsRectCollapsed, animationSpeed),
                new ViewTransition(SearchIcon, AnimationType.Opacity, 0.01, animationSpeed),
                new ViewTransition(SearchBackground, AnimationType.Layout, searchRectCollapsed, animationSpeed),
                new ViewTransition(ScrollContainer, AnimationType.Layout, scrollContainerRectCollapsed, animationSpeed)
            });



        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SizeChanged -= MainPage_SizeChanged;
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

        }

        States CurrentState = States.SearchExpanded;

        private void HamburgerButton_Clicked(object sender, EventArgs e)
        {
            States newState;
            if (CurrentState == States.SearchExpanded)
                newState = States.SearchHidden;
            else
                newState = States.SearchExpanded;

            _storyboard.Go(newState);
            CurrentState = newState;
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {

        }

        async void ProfileIcon_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        //private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    // the user has tapped on an element
        //    ProductDisplay element = sender as ProductDisplay;

        //    // set the binding context to the selected cell
        //    FakeProductCell.BindingContext = element.BindingContext;
        //    FakeProductCell.ImageOffsetX = element.ImageOffsetX;
        //    FakeProductCell.ImageOffsetY = element.ImageOffsetY;
        //    FakeProductCell.Opacity = 1;
        //    FakeProductCell.IsVisible = true;

        //    // set the selected item
        //    ((MainViewModel)this.BindingContext).SelectedProduct = element.BindingContext as ProductViewModel;

        //    // set the layout to the same postion
        //    var yScroll = ScrollContainer.ScrollY;
        //    Rectangle rect = new Rectangle(
        //        x: ScrollContainer.X + element.X,
        //        y: ScrollContainer.Y + element.Y - yScroll,
        //        width: element.Width,
        //    height: element.Height);
        //    AbsoluteLayout.SetLayoutBounds(FakeProductCell, rect);

        //    // hide the cell we clicked on
        //    element.Opacity = 0.01;
        //    await FakeProductCell.ExpandToFill(this.Bounds);
        //    element.Opacity = 1;

        //    // display the page popover
        //    PagePopover.Opacity = 0;
        //    PagePopover.IsVisible = true;
        //    await PagePopover.Expand();

        //}

        //internal async Task HidePopover()
        //{

        //    // fade out the elements
        //    await Task.WhenAll(
        //        new Task[]
        //        {
        //            FakeProductCell.FadeTo(0),
        //            PagePopover.FadeTo(0)
        //        });

        //    // hide our fake product cell
        //    FakeProductCell.IsVisible = false;

        //    // hide our Page poper
        //    PagePopover.IsVisible = false;

        //}



        //private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        //{
        //    ((View)sender).IsVisible = false;
        //}

        //private void ProductDisplay_AddToCartClicked(object sender, EventArgs e)
        //{
        //    // selected product
        //    ProductDisplay element = sender as ProductDisplay;
        //    ProductViewModel item = element.BindingContext as ProductViewModel;

        //    // add a shopping card item
        //    ((MainViewModel)this.BindingContext).ShoppingCart.IncrementOrder(item);

        //}

        //private void FavoriteIcon_Clicked(object sender, EventArgs e)
        //{
        //    CartPopover.IsVisible = true;
        //}
    }
}

