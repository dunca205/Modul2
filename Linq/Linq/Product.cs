namespace Linq
{
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
          => products.Where(product => FeatureMatch(product.Features, features) > 0);

        public static IEnumerable<Product> ProductsThatContainAllFeatures(IEnumerable<Product> products, IEnumerable<Feature> features)
          => products.Where(product => FeatureMatch(product.Features, features) == features.Count());

        public static IEnumerable<Product> ProductsThatDontContainAnyFeature(IEnumerable<Product> products, IEnumerable<Feature> features)
         => products.Where(product => FeatureMatch(product.Features, features) == 0);

        private static int FeatureMatch(IEnumerable<Feature> features, IEnumerable<Feature> features2)
            => features.Select(f => f.Id).Intersect(features2.Select(f => f.Id)).Count();
    }
}
