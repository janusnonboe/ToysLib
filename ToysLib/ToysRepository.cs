using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ToysLib
{

    public class ToysRepository 
    {
        private int _nextId = 1;
        private readonly List<Toy> _toys;

        public ToysRepository()
        {
            _toys = new List<Toy>()
            {
                new Toy(){Id = _nextId++, brand = "tokens", model = "mystic", price= 23.99},
                new Toy(){Id = _nextId++,brand = "duDum", model = "duEnSpade", price = 432.95},
                new Toy(){Id = _nextId++,brand = "larring", model = "luksus", price = 432.95},
                new Toy(){Id = _nextId++,brand = "tysm", model = "stfu", price = 2.95}
            };
            
        }
        
        public Toy? GetById(int id)
        {
            //var toy = _toys.Find(toy => toy.Id == id);
            //if (toy == null)
            //{
            //    throw new ArgumentNullException("Id not found");
            //}
            //return toy;
            return _toys.Find(toy => toy.Id == id);
        }
        
        public List<Toy> GetAll() 
        {
            return new List<Toy>(_toys);
        }

        public Toy Add(Toy newToy)
        {
            
            newToy.Validate();
            newToy.Id = _nextId++;
            _toys.Add(newToy);
            return newToy;
        }
        public Toy? Delete(int id)
        {
            Toy? toy = GetById(id);
            if(toy == null)
            {
                throw new ArgumentNullException("id does not exsist");
            }
            _toys.Remove(toy);
            return toy;
        }
        
        
    }
}
