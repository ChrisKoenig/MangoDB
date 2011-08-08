using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MangoDatabase.Messages;
using MangoDatabase.Model;

namespace MangoDatabase.ViewModel
{
    public class DetailsViewModel : ViewModelBase
    {
        public DetailsViewModel()
        {
            SaveChangesCommand = new RelayCommand(() => SaveChanges());
            DeletePersonCommand = new RelayCommand(() => DeletePerson());
        }

        public RelayCommand SaveChangesCommand { get; set; }

        public RelayCommand DeletePersonCommand { get; set; }

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
            }
        }

        private void SaveChanges()
        {
            if (SelectedPerson.Id == 0)
                App.DataContext.People.InsertOnSubmit(SelectedPerson);
            App.DataContext.SubmitChanges();
            MessengerInstance.Send<SaveCompleteMessage>(new SaveCompleteMessage());
        }

        private void DeletePerson()
        {
            if (SelectedPerson.Id != 0)
            {
                App.DataContext.People.DeleteOnSubmit(this.SelectedPerson);
                App.DataContext.SubmitChanges();
            }
            MessengerInstance.Send<SaveCompleteMessage>(new SaveCompleteMessage());
        }
    }
}