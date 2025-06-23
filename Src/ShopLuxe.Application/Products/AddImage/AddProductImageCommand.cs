using Microsoft.AspNetCore.Http;
using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Products.AddImage
{
    public class AddProductImageCommand : IBaseCommand
    {

        public IFormFile ImageFile { get; set; }
        public Guid ProductId { get; set; }
        public int Sequence { get; set; }
    }
}
