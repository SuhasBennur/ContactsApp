using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.classes
{
    public class Contact
    {
        [PrimaryKey,AutoIncrement,Unique]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} -  {Email} - {Phone}";
        }
    }
}
