using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Common.Application;

namespace ShopLuxe.Application.Products.Create
{
    public class CreateProductCommand : IBaseCommand
    {
        //public CreateProductCommand(string title, IFormFile imageFile, string description, Guid categoryId, Guid subCategoryId, Guid secondarySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specifications)
        //{
        //    Title = title;
        //    ImageFile = imageFile;
        //    Description = description;
        //    CategoryId = categoryId;
        //    SubCategoryId = subCategoryId;
        //    SecondarySubCategoryId = secondarySubCategoryId;
        //    Slug = slug;
        //    SeoData = seoData;
        //    Specifications = specifications;
        //}

        public string Title { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid SecondarySubCategoryId { get; set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
        public Dictionary<string, string> Specifications { get; set; }
    }
}
