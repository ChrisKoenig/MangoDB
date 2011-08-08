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
using Microsoft.Phone.Controls;

namespace MangoDatabase
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        public DetailsPage()
        {
            InitializeComponent();

            Messenger.Default.Register<SaveCompleteMessage>(this,
                (message) =>
                {
                    if (NavigationService.CanGoBack)
                        NavigationService.GoBack();
                });
        }
    }
}