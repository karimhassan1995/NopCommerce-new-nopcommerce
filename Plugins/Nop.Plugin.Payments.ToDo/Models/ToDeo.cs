﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Nop.Core;

namespace Nop.Plugin.Payments.ToDo.Models
{
    [Table("ToDo")]
    public partial class ToDeo : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string ToDoName { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string ToDoDescription { get; set; }
    }
}