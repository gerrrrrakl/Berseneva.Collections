using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berseneva.Collections
{
    public class Orders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public string Tag { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"{Id} Name: {Name}  Email: {Email} Age : {Age } City: {City} Street: {Street }Phone: {Phone }  CustomerId: { CustomerId}  ProductId: {ProductId}  Tag:{Tag} Price: {Price}";
        }
    }
}
