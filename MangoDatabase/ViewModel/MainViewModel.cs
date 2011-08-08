using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using MangoDatabase.Messages;
using MangoDatabase.Model;

namespace MangoDatabase.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                MessengerInstance.Register<RefreshDataMessage>(this, (message) => LoadFromDatabase());
            }
        }

        private void LoadFromDatabase()
        {
            var people = from p in App.DataContext.People
                         select p;
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    People.Clear();
                    foreach (var item in people)
                    {
                        People.Add(item);
                    }
                });
        }

        private ObservableCollection<Person> _people = new ObservableCollection<Person>();

        /// <summary>
        /// Gets the People property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event.
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public ObservableCollection<Person> People
        {
            get
            {
                return _people;
            }

            set
            {
                if (_people == value)
                {
                    return;
                }
                _people = value;
                RaisePropertyChanged(() => this.People);
            }
        }

        private Person _selectedPerson = null;

        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }

            set
            {
                if (_selectedPerson == value)
                {
                    return;
                }
                _selectedPerson = value;
                RaisePropertyChanged(() => this.SelectedPerson);
                if (_selectedPerson != null)
                {
                    var message = new PersonSelectedMessage() { SelectedPerson = _selectedPerson };
                    MessengerInstance.Send<PersonSelectedMessage>(message);
                }
            }
        }
    }
}