using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace EasyMVVM
{
    internal class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        private ObservableCollection<string> _BackingProperty;

        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set { _BackingProperty = value; PropChanged("BoundProperty"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }
    }
}
