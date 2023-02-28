using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.ModelsDTO
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Car> cars { get; set; }

        public Person()
        {
            cars = new List<Car>();
        }

    }
}
