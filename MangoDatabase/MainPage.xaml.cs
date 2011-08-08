using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using MangoDatabase.Messages;
using MangoDatabase.Model;
using Microsoft.Phone.Controls;

namespace MangoDatabase
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            Messenger.Default.Send<RefreshDataMessage>(new RefreshDataMessage());
            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Clean this up
            var message = new PersonSelectedMessage() { SelectedPerson = new Person() };
            Messenger.Default.Send<PersonSelectedMessage>(message);
            NavigationService.Navigate(new Uri("/DetailsPage.xaml", UriKind.Relative));
        }

        private void PeopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PeopleListBox.SelectedItem != null)
                NavigationService.Navigate(new Uri("/DetailsPage.xaml", UriKind.Relative));
        }
    }
}