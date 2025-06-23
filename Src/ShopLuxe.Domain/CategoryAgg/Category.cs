using ShopLuxe.Common.Domain;
using ShopLuxe.Common.Domain.Exceptions;
using ShopLuxe.Common.Domain.Utils;
using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Domain.CategoryAgg.Services;

namespace ShopLuxe.Domain.CategoryAgg
{
    public class Category : BaseAggregateRoot
    {
        private Category()
        {
            Childs = new List<Category>();
        }
        public Category(string slug, string title, SeoData seoData, ICategoryDomainService service)
        {
            Slug = slug?.ToSlug();
            Guard(title, slug, service);
            Title = title;
            SeoData = seoData;
            Childs = new List<Category>();
        }

        public Guid? ParentId { get; private set; }
        public string Slug { get;private set; }
        public string Title { get;private set; }
        public SeoData SeoData { get;private set; }
        public List<Category> Childs { get; private set; }

        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService service)
        {
            slug = slug?.ToSlug();
            Guard(title, slug, service);
            Title = title;
            SeoData = seoData;
        }
        public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService service)
        {
            Childs.Add(new Category(title, slug, seoData, service)
            {
                ParentId = Id
            });
        }
        public void Guard(string title, string slug, ICategoryDomainService service)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != Slug)
                if (service.IsSlugExist(slug))
                    throw new SlugIsDuplicateDomainException();
        }
    }
}
