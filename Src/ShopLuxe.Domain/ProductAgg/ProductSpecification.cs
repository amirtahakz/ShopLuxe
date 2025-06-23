using ShopLuxe.Common.Domain;

namespace ShopLuxe.Domain.ProductAgg
{
    public class ProductSpecification : BaseEntity
    {
        private ProductSpecification()
        {

        }
        public ProductSpecification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public Guid ProductId { get; internal set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}
