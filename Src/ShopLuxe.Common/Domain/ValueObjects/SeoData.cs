﻿using ShopLuxe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Common.Domain.ValueObjects
{
    public class SeoData : BaseValueObject
    {
        private SeoData()
        {
        }

        public static SeoData CreateEmpty()
        {
            return new SeoData();
        }

        public SeoData(string? metaKeyWords, string? metaDescription, string? metaTitle, bool indexPage, string? canonical,
            string schema)
        {
            MetaKeyWords = metaKeyWords;
            MetaDescription = metaDescription;
            MetaTitle = metaTitle;
            IndexPage = indexPage;
            Canonical = canonical;
            Schema = schema;
        }

        public string? MetaTitle { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? MetaKeyWords { get; private set; }
        public bool IndexPage { get; private set; }
        public string? Canonical { get; private set; }
        public string? Schema { get; private set; }
    }
}
