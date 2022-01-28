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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLite;
using ContactsApp;
using ContactsApp.classes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            
            contacts = new List<Contact>();
            InitializeComponent();
            readdb(); 
        }

        private void OnNewButtonClick(object sender, RoutedEventArgs e)
        {
            NewContactsWindow newcontact = new NewContactsWindow();
            newcontact.ShowDialog();
            readdb();
        }
        void readdb()
        {
            using (SQLiteConnection sqlcon=new SQLiteConnection(App.dbPath))
            {
                sqlcon.CreateTable<Contact>();
                contacts=(sqlcon.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
            }
            if(contacts !=null)
            {
                //foreach (var c in contacts)
                //{
                //    ContactsListView.Items.Add(new ListViewItem()
                //    {
                //        Content =c
                //    });
                //}
                ContactsListView.ItemsSource = contacts;
            }
        }

        private void tb_textchanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchtb = sender as TextBox;
            var filteredlist = contacts.Where(c=>c.Name.ToLower().Contains(searchtb.Text.ToLower())).ToList();

            //var filteredlist2 = (from c in contacts
            //                     where c.Name.ToLower().Contains(searchtb.Text.ToLower())
            //                     orderby c.Name
            //                     select c).ToList();

            ContactsListView.ItemsSource = filteredlist;
        }

        private void ContactsListView_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)ContactsListView.SelectedItem;

            if(selectedContact!=null)
            {
                ContactsDetailsWindow newcontactdetailwindow = new ContactsDetailsWindow(selectedContact);
                newcontactdetailwindow.ShowDialog();

                readdb();
            }
        }
    }
}
