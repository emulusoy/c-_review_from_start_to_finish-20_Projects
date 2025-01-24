using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Different20Project_5_Dapper_Northwind.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public SqlMoney UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }
    }
}
