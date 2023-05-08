using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Customers;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Payments.Fruit.Domain;

namespace Nop.Plugin.Payments.Fruit.Data
{
    public class FruitRecordBuilder : NopEntityBuilder<Frruit>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //map the primary key (not necessary if it is Id field)
            table.WithColumn(nameof(Frruit.Id)).AsInt32().PrimaryKey()
            //avoiding truncation/failure
            //so we set the same max length used in the product name
            .WithColumn(nameof(Frruit.FruitName)).AsString(400)
            //not necessary if we don't specify any rules
          .WithColumn(nameof(Frruit.FruitColor)).AsString(400);
        }
    }
}
