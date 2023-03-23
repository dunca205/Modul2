using Linq;

namespace LinqExercise
{
    public class ProductFacts
    {
        [Fact]
        public void GropupProductsThatContainAtLeastOnFeauture()
        {
            var featureList = new[] {
                new Feature(900),  // pret 
                new Feature(1000), // pret 
                new Feature(2021), // an Fabricatie
                new Feature(5)     // raiting
            };

            var samsungS21 = new Product("SamsungS21", new List<Feature> { new Feature(900), new Feature(2021) });
            var huawai = new Product("Huawai", new List<Feature> { new Feature(850), new Feature(5) });
            var iPhone11 = new Product("IPhone11", new List<Feature> { new Feature(1000), new Feature(2022), new Feature(5) });
            var samsungS21Ultra = new Product("SamsungS21Ultra", new List<Feature> { new Feature(2500), new Feature(2023) });

            var listOfProducts = new[] { samsungS21, huawai, iPhone11, samsungS21Ultra };
            var expected = new[] { samsungS21, huawai, iPhone11 };

            Assert.Equal(expected, Product.ProductsThatContainAtLeastOneFeature(listOfProducts, featureList));
        }

        [Fact]
        public void ProductsThatContainAllFeatures()
        {
            var featureList = new[] { new Feature(1000), new Feature(2021) };

            var samsungS21 = new Product("SamsungS21", new List<Feature> { new Feature(900), new Feature(2021) });
            var huawai = new Product("Huawai", new List<Feature> { new Feature(850), new Feature(5) });
            var iPhone11 = new Product("IPhone11", new List<Feature> { new Feature(1000), new Feature(2021), new Feature(5) });

            var listOfProducts = new[] { samsungS21, huawai, iPhone11 };
            var expected = new[] { iPhone11 };

            Assert.Equal(expected, Product.ProductsThatContainAllFeatures(listOfProducts, featureList));
        }

        [Fact]
        public void ProductsThatDontContainAnyFeature()
        {
            var featureList = new[] { new Feature(1000), new Feature(2021) };

            var samsungS21 = new Product("SamsungS21", new List<Feature> { new Feature(900), new Feature(2021) });
            var huawai = new Product("Huawai", new List<Feature> { new Feature(850), new Feature(5) });
            var iPhone11 = new Product("IPhone11", new List<Feature> { new Feature(1000), new Feature(2020), new Feature(5) });

            var listOfProducts = new[] { samsungS21, huawai, iPhone11 };
            var expected = new[] { huawai };

            Assert.Equal(expected, Product.ProductsThatDontContainAnyFeature(listOfProducts, featureList));
        }

        [Fact]
        public void ProductStructMergesTwoListBasedOnProductName()
        {
            var stock1 = new[] {
                new ProductStruct{Name  = "Samsung", Quantity  = 1 },
                new ProductStruct{Name  = "IPhone", Quantity  = 4 },
                new ProductStruct{Name  = "Huawei", Quantity  = 2 },
                new ProductStruct{Name  = "Nokia", Quantity  = 0 } };
            var stock2 = new[] {
                new ProductStruct{Name  = "IPhone", Quantity  = 1 },
                new ProductStruct{Name  = "Samsung", Quantity  = 4 },
                new ProductStruct{Name  = "Nokia", Quantity  = 5 },
                new ProductStruct{Name  = "Huawei", Quantity  = 3 },
                new ProductStruct{Name =  "AllView", Quantity = 1}
            };
            var rezult = new[] {
                new ProductStruct{Name = "Samsung", Quantity  = 5 },
                new ProductStruct{Name = "IPhone", Quantity  = 5 },
                new ProductStruct{Name = "Huawei", Quantity  = 5 },
                new ProductStruct{Name = "Nokia", Quantity  = 5 },
                new ProductStruct{Name = "AllView", Quantity = 1} };
            Assert.Equal(rezult, ProductStruct.GroupProductsByName(stock1, stock2));
        }
    }
}
