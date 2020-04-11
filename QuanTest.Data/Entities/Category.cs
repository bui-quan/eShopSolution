using QuanTest.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanTest.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Order { get; set; }

        public Status Status { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
