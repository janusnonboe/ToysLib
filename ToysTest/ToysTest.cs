using ToysLib;
namespace ToysTest
{
    [TestClass]
    public class ToysTest
    {


        private readonly Toy wrongPrice = new Toy { Id = 1, brand = "asd", model = "qwe", price = -12.95 };
        private readonly Toy _toy = new Toy { Id = 1, brand = "asd", model = "qwe", price = 1112.95 };
        private readonly Toy wrongbrand = new Toy { Id = 1, brand = "a", model = "qwe", price = 12.95 };
        [TestMethod()]
        public void ValidateBrand()
        {
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>  wrongbrand.ValidateBrand() );
        }
        [TestMethod()]
        public void Validateprice()
        {
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wrongPrice.ValidatePrice());
        }
    }
    [TestClass]
    public class ToysReepoTest
    {
        private const bool useDatabase = true;
        private static ToysRepository _repo;
        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            
                _repo = new ToysRepository();
            
        }
        [TestMethod]
        public void AddTest()
        {
            _repo.Add(new Toy { brand = "qwea", model = "qweb", price= 33.95});
            Toy gamer = _repo.Add(new Toy {brand = "gamersups", model = "Hardcore Gamer", price = 23.23 });
            Assert.IsTrue(gamer.Id >= 0);

            Assert.ThrowsException<NullReferenceException>(
                () => _repo.Add(new Toy { brand = null, model = "du dum", price = 1212 }));
          
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => _repo.Add(new Toy { brand = "B", model = "sad", price = 22222222 }));
        }
        [TestMethod]
        public void GetTest()
        {
             _repo.GetAll();

            
        }
        [TestMethod]
        public void GetByIdTest() 
        {
            Assert.IsNotNull(_repo.GetById(2));
            Assert.IsNull(_repo.GetById(122));
        }
        [TestMethod]
        public void DeleteTest()
        {
            //Assert.IsNull(_repo.Delete(  13));
            Assert.AreEqual(1, _repo.Delete(1)?.Id);
            Assert.AreEqual(5, _repo.GetAll().Count());
        }


    }
}