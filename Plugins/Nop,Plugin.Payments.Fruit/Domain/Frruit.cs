using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Payments.Fruit.Domain
{
    public class Frruit : BaseEntity
    {
        public int ID { get; set; }
        public string FruitName { get; set; }
        public string FruitColor { get; set; }
    }
}
