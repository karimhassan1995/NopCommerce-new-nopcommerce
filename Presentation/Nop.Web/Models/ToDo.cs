﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nop.Web.Models
{
    [Table("ToDo")]
    public partial class ToDo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string ToDoName { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string ToDoDescription { get; set; }
    }
}