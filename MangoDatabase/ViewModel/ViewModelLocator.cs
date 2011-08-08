/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MangoDatabase"
                           x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MangoDatabase.Messages;
using MangoDatabase.Model;
using Microsoft.Practices.ServiceLocation;

namespace MangoDatabase.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<PeopleDataContext>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DetailsViewModel>();

            // initialize the database
            var dc = ServiceLocator.Current.GetInstance<PeopleDataContext>();
            if (!dc.DatabaseExists())
                dc.CreateDatabase();

            // register for messages between VMs
            Messenger.Default.Register<PersonSelectedMessage>(
                this,
                (message) =>
                {
                    var details = ServiceLocator.Current.GetInstance<DetailsViewModel>();
                    details.SelectedPerson = message.SelectedPerson;
                });
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public DetailsViewModel Details
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DetailsViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}