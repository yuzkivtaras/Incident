using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DbSet
{
    public class Account
    {
        [Key]
        public string AccountName { get; set; }
    }
}
