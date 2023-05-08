using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Nop.Plugin.Payments.Book.Models
{
    [Table("Book")]
    public partial class Book
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string BookName { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string BookDescription { get; set; }
    }
}
