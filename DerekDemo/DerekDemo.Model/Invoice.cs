using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerekDemo.Model
{
    public class Invoice : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public User User { get; set; }
    }
}
