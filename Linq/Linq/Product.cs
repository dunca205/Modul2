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

        public static IEnumerable<Product> ProductsThatContainAtLeastOneFeature(ICollection<Product> products, IEnumerable<Feature> features)
          => products.Where(product => FeatureMatch(product.Features, features).Any());

        public static IEnumerable<Product> ProductsThatContainallFeatures(IEnumerable<Product> products, IEnumerable<Feature> features)
          => products.Where(product => FeatureMatch(product.Features, features).Count() == features.Count());

        public static IEnumerable<int> FeatureMatch(IEnumerable<Feature> features, IEnumerable<Feature> features2)
            => features.Select(f => f.Id).Intersect(features2.Select(f => f.Id));
    }
}
