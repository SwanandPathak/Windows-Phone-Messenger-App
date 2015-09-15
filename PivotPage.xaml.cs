using MessengerApp.Common;
using MessengerApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.UI.ViewManagement;

using MessengerApp.DataModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI;


// The Pivot Application template is documented at http://go.microsoft.com/fwlink/?LinkID=391641

namespace MessengerApp
{
    public sealed partial class PivotPage : Page
    {
        private const string FirstGroupName = "FirstGroup";
        private const string SecondGroupName = "SecondGroup";
        ViewModel vm;

        private readonly NavigationHelper navigationHelper;
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public PivotPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            vm = ViewModel.returnMyViewModel();
            this.DataContext=vm;
            
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        
        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>.
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            await vm.getUsers(vm.emailThisSession, vm.passwordThisSession, vm.firstNameThisSession, vm.lastNameThisSession);
           await vm.getAllLocations(vm.emailThisSession, vm.passwordThisSession);
             
        }
        

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache. Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/>.</param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }

        /// <summary>
        /// Adds an item to the list when the app bar button is clicked.
        /// </summary>
        private void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Invoked when an item within a section is clicked.
        /// </summary>
        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            Frame.Navigate(typeof(ItemPage));
            User friend = ((sender as ListView).SelectedItem as User);
            System.Diagnostics.Debug.WriteLine("in friend"+friend);

        }

        /// <summary>
        /// Loads the content for the second pivot item when it is scrolled into view.
        /// </summary>
        private async void SecondPivot_Loaded(object sender, RoutedEventArgs e)
        { }
           // var sampleDataGroup = await SampleDataSource.GetGroupAsync("Group-2");
          //  this.DefaultViewModel[SecondGroupName] = sampleDataGroup;
        
    
        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        // map
        public void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            var map = sender as MapControl;
            for (int i = 0; i < location.listLongitude.Count;i++)
            {
                double la = Convert.ToDouble(location.listLatitude.ElementAt(i));       
                double lo = Convert.ToDouble(location.listLongitude.ElementAt(i));
                if(-90.00<la && la<90.00 && -90<lo && lo<90)
                {
                var loc = new Geopoint(new BasicGeoposition()
                {
                    
                    Latitude = la,
                    Longitude =lo
                });

                var mygrid = new Grid();
                var myText = new TextBlock();
                myText.Foreground = new SolidColorBrush(Colors.Black);
                myText.FontSize = 15;
                myText.Text = location.listName.ElementAt(i);
                
                var pushpin = new Image()
                {
                    Name = "pointer",
                    Width = 40,
                    Height = 40,
                    Source = new BitmapImage(new Uri("ms-appx:///Assets/PushPinFinal.png"))

                };
                mygrid.Children.Add(pushpin);
                mygrid.Children.Add(myText);
                MapControl.SetLocation(mygrid, loc);
                MapControl.SetNormalizedAnchorPoint(mygrid, new Point(0.5,1));
                map.Children.Add(mygrid);
            }
            }
            var loc1 = new Geopoint(new BasicGeoposition()
            {
                Latitude = 43.1610,
                Longitude = -77.6109

            });
            map.Center=loc1;
            map.ZoomLevel = 10;
        }
    }
}
