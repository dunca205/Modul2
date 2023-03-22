using Linq;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace LinqExercise
{
    public class ProductFacts
    {
        [Fact]
        public void GropupProductsThatContainAtLeastOnFeauture()
        {
            var featureList = new [] {
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
            var expected = new[] { samsungS21, huawai, iPhone11};

            Assert.Equal(expected, Product.ProductsThatContainAtLeastOneFeature(listOfProducts, featureList));
        }

        [Fact]
        public void ProductsThatContainAllFeatures()
        {
            var featureList = new []{ new Feature(1000),  new Feature(2021) };

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
            var featureList = new []{ new Feature(1000),  new Feature(2021) };

            var samsungS21 = new Product("SamsungS21", new List<Feature> { new Feature(900), new Feature(2021) });
            var huawai = new Product("Huawai", new List<Feature> { new Feature(850), new Feature(5) });
            var iPhone11 = new Product("IPhone11", new List<Feature> { new Feature(1000), new Feature(2020), new Feature(5) });

            var listOfProducts = new[] { samsungS21, huawai, iPhone11 };
            var expected = new[] { huawai };

            Assert.Equal(expected, Product.ProductsThatDontContainAnyFeature(listOfProducts, featureList));
        }

    }
}
