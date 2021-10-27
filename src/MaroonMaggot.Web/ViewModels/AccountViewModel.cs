using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaroonMaggot.Web.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRootAccount { get; set; }
    }
}
