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
    /// Interaction logic for ContactsDetailsWindow.xaml
    /// </summary>
    //suhas
    public partial class ContactsDetailsWindow : Window
    {
        Contact contact;
        public ContactsDetailsWindow(Contact contact)
        {
            InitializeComponent();

            //to start/place the window at center
            Owner = Application.Current.MainWindow;
            WindowStartupLocation=WindowStartupLocation.CenterScreen;

            this.contact = contact;
            NameBox.Text = contact.Name;
            EmailBox.Text=contact.Email;
            PhoneBox.Text=contact.Phone;
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            contact.Name= NameBox.Text;
            contact.Email= EmailBox.Text;
            contact.Phone= PhoneBox.Text;
            using (SQLiteConnection con = new SQLiteConnection(App.dbPath))
            {
                con.CreateTable<Contact>();
                con.Update(contact);
            }
            Close();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.dbPath))
            {
                con.CreateTable<Contact>();
                con.Delete(contact);
            }
            Close();
        }
    }
}
