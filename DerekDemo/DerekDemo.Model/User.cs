using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerekDemo.Model
{
    public class User : BaseEntity
    {
        public User()
        {
            Invoices = new List<Invoice>();
        }
        public string UserName { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
