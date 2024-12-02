using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using System.Diagnostics;
using LingoLift.Services;

namespace LingoLift
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly PdfManager _pdfManager;

        public ICommand SelectPdfCommand { get; }

        public string _preview = "Hello, World!";
        public string Preview
        {
            get => _preview;
            set
            {
                _preview = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            SelectPdfCommand = new RelayCommand(param => SelectPdf());
            _pdfManager = new();
        }

        public void SelectPdf()
        {
            var openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a Pdf File",
                Filter = "Pdf Files|*.pdf",
                RestoreDirectory = true
            };

            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            _pdfManager.LoadPdf(filePath);
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
