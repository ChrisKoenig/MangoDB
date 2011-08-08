using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight;

namespace MangoDatabase.Model
{
    [Table]
    public class Person : ObservableObject
    {
        // Fields...
        private DateTime _BirthDate;
        private string _LastName;
        private string _FirstName;

        [Column(
            AutoSync = AutoSync.OnInsert,
            DbType = "Int NOT NULL IDENTITY",
            IsPrimaryKey = true,
            IsDbGenerated = true)]
        public Int32 Id { get; set; }

        [Column]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName == value)
                    return;
                _FirstName = value;
                RaisePropertyChanged(() => this.FirstName);
            }
        }

        [Column]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName == value)
                    return;
                _LastName = value;
                RaisePropertyChanged(() => this.LastName);
            }
        }

        [Column]
        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set
            {
                if (_BirthDate == value)
                    return;
                _BirthDate = value;
                RaisePropertyChanged(() => this.BirthDate);
            }
        }
    }
}