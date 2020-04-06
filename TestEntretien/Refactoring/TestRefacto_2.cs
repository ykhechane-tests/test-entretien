using System;
using System.Collections.Generic;
using System.Text;

namespace TestEntretien.Refactoring
{
    public class TestRefacto_2
    {
        public static void Run()
        {
            Product product1 = new Product() { Id = 1 };
            Product product2 = new Product() { Id = 1 };

            HashSet<Product> list = new HashSet<Product>();
            list.Add(product1);
            list.Add(product2);
            foreach (var item in list)
            {
                Console.WriteLine(item.Id);
            }
        }        
    }
    public class Product
    {
        public int Id { get; set; }  
    }
}
