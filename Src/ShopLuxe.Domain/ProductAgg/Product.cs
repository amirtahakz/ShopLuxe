﻿using ShopLuxe.Common.Domain;
using ShopLuxe.Common.Domain.Exceptions;
using ShopLuxe.Common.Domain.Utils;
using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.ProductAgg
{
    public class Product : BaseAggregateRoot
    {
        private Product()
        {

        }
        public Product(string title, string imageName, string description, Guid categoryId,
           Guid subCategoryId, Guid? secondarySubCategoryId, IProductDomainService domainService,
           string slug, SeoData seoData)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            Guard(title, slug, description, domainService);

            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid? SubCategoryId { get; private set; }
        public Guid? SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }


        public void Edit(string title, string description, Guid categoryId,
            Guid subCategoryId, Guid secondarySubCategoryId, string slug, IProductDomainService domainService
            , SeoData seoData)
        {
            Guard(title, slug, description, domainService);
            Title = title;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void SetProductImage(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
        }

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }
        public string RemoveImage(Guid id)
        {
            var image = Images.FirstOrDefault(f => f.Id == id);
            if (image == null)
                throw new NullOrEmptyDomainDataException("عکس یافت نشد");

            Images.Remove(image);
            return image.ImageName;
        }

        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(s => s.ProductId = Id);
            Specifications = specifications;
        }

        private void Guard(string title, string slug, string description,
            IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != Slug)
                if (domainService.SlugIsExist(slug.ToSlug()))
                    throw new SlugIsDuplicateDomainException();
        }
    }
}
