namespace Linq
{
    public struct ProductStruct
    {
        public string Name;
        public int Quantity;

        public static IEnumerable<ProductStruct> GroupProductsByName(IEnumerable<ProductStruct> list1, IEnumerable<ProductStruct> list2)
           => list1.Concat(list2).
              GroupBy(product => product.Name, (name, quantity) => new ProductStruct { Name = name, Quantity = quantity.Sum(eachProduct => eachProduct.Quantity) });

    }

    public class Product
    {
        public Product(string name, ICollection<Feature> features)
        {
            this.Name = name;
            this.Features = features;
        }

        public string Name { get; set; }

        public ICollection<Feature> Features { get; }

        public static IEnumerable<Product> ProductsThatContainAtLeastOneFeature(IEnumerable<Product> products, IEnumerable<Feature> features)
          => products.Where(product => FeatureMatches(product.Features, features) > 0);

        public static IEnumerable<Product> ProductsThatContainAllFeatures(IEnumerable<Product> products, IEnumerable<Feature> features)
          => products.Where(product => FeatureMatches(product.Features, features) == features.Count());

        public static IEnumerable<Product> ProductsThatDontContainAnyFeature(IEnumerable<Product> products, IEnumerable<Feature> features)
         => products.Where(product => FeatureMatches(product.Features, features) == 0);

        private static int FeatureMatches(IEnumerable<Feature> features, IEnumerable<Feature> features2)
            => features.Select(f => f.Id).Intersect(features2.Select(f => f.Id)).Count();
    }
}
