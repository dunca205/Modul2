using Linq;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace LinqExercise
{
    public class ProductFacts
    {
        [Fact]
        public void GropupProductsThatContainAtLeastOnFeauture()
        {
            var featureList = new List<Feature> {
                new Feature(900),  // pret 
                new Feature(1000), // pret 
                new Feature(2021), // an Fabricatie
                new Feature(5)     // raiting
            };

            var samsungS21 = new Product("SamsungS21", new List<Feature> { new Feature(900), new Feature(2021) });
            var huawai = new Product("Huawai", new List<Feature> { new Feature(850), new Feature(5) });
            var iPhone11 = new Product("IPhone11", new List<Feature> { new Feature(1000), new Feature(2022), new Feature(5) });
            var samsungS21Ultra = new Product("SamsungS21Ultra", new List<Feature> { new Feature(2500), new Feature(2023) });

            var listOfProducts = new List<Product>();
            listOfProducts.Add(samsungS21);
            listOfProducts.Add(huawai);
            listOfProducts.Add(iPhone11);
            listOfProducts.Add(samsungS21Ultra);

            var expected = new List<Product>();
            expected.Add(samsungS21);
            expected.Add(huawai);
            expected.Add(iPhone11);
            Assert.Equal(expected, Product.ProductsThatContainAtLeastOneFeature(listOfProducts, featureList));
        }

        [Fact]
        public void ProductsThatContainAllFeatures()
        {
            var featureList = new List<Feature> {
                new Feature(1000), // pret 
                new Feature(2021) // an Fabricatie
            };

            var samsungS21 = new Product("SamsungS21", new List<Feature> { new Feature(900), new Feature(2021) });
            var huawai = new Product("Huawai", new List<Feature> { new Feature(850), new Feature(5) });
            var iPhone11 = new Product("IPhone11", new List<Feature> { new Feature(1000), new Feature(2021), new Feature(5) });

            var listOfProducts = new List<Product>();
            listOfProducts.Add(samsungS21);
            listOfProducts.Add(huawai);
            listOfProducts.Add(iPhone11);
            var expected = new List<Product>();
            expected.Add(iPhone11);

            Assert.Equal(expected, Product.ProductsThatContainallFeatures(listOfProducts, featureList));
        }

        [Fact]
        public void CompareFeatureListWhenAtLeastOneFeatureIsMatching()
        {
            var featureList = new List<Feature> {
                new Feature(900),  // pret 
                new Feature(1000), // pret 
                new Feature(2021), // an Fabricatie
                new Feature(5)     // raiting
            };

            var featureList2 = new List<Feature> {
                new Feature(900),  // pret 
                new Feature(1000), // pret 
                new Feature(2023), // an Fabricatie
                new Feature(4)     // raiting
            };
            var a = Product.FeatureMatch(featureList, featureList2);
            Assert.True(a.Count() > 0);
        }

        [Fact]
        public void CompareFeatureListsWhenNoFeatureIsMatching()
        {
            var featureList = new List<Feature> {
                new Feature(1),
                new Feature(2),
                new Feature(3),
                new Feature(5)
            };

            var featureList2 = new List<Feature> {
                new Feature(900),
                new Feature(1000),
                new Feature(2023),
                new Feature(4)
            };

            var a = Product.FeatureMatch(featureList, featureList2);
            Assert.True(a.Count() == 0);
        }
    }
}
