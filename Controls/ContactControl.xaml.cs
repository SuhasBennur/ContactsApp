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
using ContactsApp.classes;

namespace ContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        //private Contact contact;
        //public Contact Contact
        //{
        //    get { return contact; }
        //    set 
        //    { 
        //        contact = value;
        //        Nameblock.Text=contact.Name;
        //        Emailblock.Text=contact.Email;
        //        PhoneBlock.Text=contact.Phone;
        //    }
        //}

        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(int), typeof(ContactControl), new PropertyMetadata(0, SetText));
        //new Contact() { Name = "Name LastName", Email = "exampel@domain.com", Phone = "7878987877"}
        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;

            if(control != null)
            {
                control.Nameblock.Text = (e.NewValue as Contact).Name;
                control.Emailblock.Text = (e.NewValue as Contact).Email;
                control.PhoneBlock.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
