using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LingoLift
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand SelectPdfCommand { get; }

        public string hello = "Hello, World!";
        public string Hello
        {
            get => hello;
            set
            {
                hello = value; 
                OnPropertyChanged();

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            SelectPdfCommand = new RelayCommand(param => SelectPdf() );
        }

        public void SelectPdf()
        {
            Hello = "Hello, World! from SelectPdf";
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
