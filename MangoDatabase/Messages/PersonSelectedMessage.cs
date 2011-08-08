using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MangoDatabase.Model;

namespace MangoDatabase.Messages
{
    public class PersonSelectedMessage
    {
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
            }
        }
    }
}