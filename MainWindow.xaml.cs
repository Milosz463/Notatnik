using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string NazwaPliku { get; set; } = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Nowy(object sender, RoutedEventArgs e)
        {
            WpisanyText.Text = "";
        }

        private void Otworz(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "plik tekstowy | *.txt";
            if (ofd.ShowDialog() == true) { 
            NazwaPliku = ofd.FileName;
                Title= NazwaPliku;
                WpisanyText.Text= File.ReadAllText(NazwaPliku);
            }
        }

        private void Zapisz(object sender, RoutedEventArgs e)
        {
            if (NazwaPliku == "")
            {
                ZapiszJako(sender, e);
            }
            else
            {
                File.WriteAllText(NazwaPliku, WpisanyText.Text);
            }
        }

        private void ZapiszJako(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter= "plik tekstowy | *.txt";
            if(saveFileDialog.ShowDialog() == true)
            {
                NazwaPliku=saveFileDialog.FileName;
                Title = NazwaPliku;
                File.WriteAllText(NazwaPliku, WpisanyText.Text);

            }
        }

        private void Zamknij(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy chcesz zapisac zmiany przed zamknieciem", "Pytanie", MessageBoxButton.YesNoCancel);
            if (messageBoxResult == MessageBoxResult.Cancel)
            {
                return;
            }
            if(messageBoxResult == MessageBoxResult.No) {
                Close();
            }
            else
            {
                Zapisz(sender, e);
            }
            
        }

        private void OAplikacji(object sender, RoutedEventArgs e)
        {
            Window Apka=new Window();
            Apka.ShowDialog();
        }

        private void OAutorze(object sender, RoutedEventArgs e)
        {
            Window Autor=new Window();
            Autor.ShowDialog();
        }
    }
}
