using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ContactsApp.classes;
using SQLite;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactsWindow.xaml
    /// </summary>
    public partial class NewContactsWindow : Window
    {
        public NewContactsWindow()
        {
            InitializeComponent();
            //to start/place the window at center
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = NameBox.Text,
                Email = EmailBox.Text,
                Phone = PhoneBox.Text,
            };
           

            using (SQLiteConnection con = new SQLiteConnection(App.dbPath))
            {
                con.CreateTable<Contact>();
                con.Insert(contact);
            }

            Close();
        }
    }
}
