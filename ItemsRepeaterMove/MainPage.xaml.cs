using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ItemsRepeaterMoveExceptionRepro
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Book> _Books;
        public ObservableCollection<Book> Books
        {
            get { return _Books; }
        }

        public MainPage()
        {
            this.InitializeComponent();
            _Books = new ObservableCollection<Book>();
            _Books.Add(new Book("Dune"));
            _Books.Add(new Book("Dune Messiah"));
            _Books.Add(new Book("Children of Dune"));
            _Books.Add(new Book("Bilbo the hobbit"));
            _Books.Add(new Book("Lord of the rings"));
            _Books.Add(new Book("The adventures of Tom Bondabil"));
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            _Books.Move(3, 0);
        }

        private void OnClickWorkaround(object sender, RoutedEventArgs e)
        {
            // Simulate the move works just fine from a UI point of GUI. But it also generates improper collection notifications
            Book b = Books[3];
            Books.RemoveAt(3);
            Books.Insert(0,b);
        }
    }
}
