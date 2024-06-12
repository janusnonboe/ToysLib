using System.ComponentModel.DataAnnotations;

namespace ToysLib
{
    public class Toy
    {
       
        [MinLength(2,ErrorMessage ="must be above 2 letters dumbass")]
        public string brand {  get; set; }
        public string model {  get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="fuck you")]
        public double price {  get; set; }
        public int Id { get; set; }




      
        public void ValidateBrand()
        {
        
            if (brand.Length < 2)
            {
                throw new ArgumentOutOfRangeException("title must be atleast to char[ctors long");
            }
        }
        public void ValidatePrice()
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price must be positive");
            }
        }
        public void Validate()
        {
            ValidateBrand();
            ValidatePrice();
        }


    }
}
