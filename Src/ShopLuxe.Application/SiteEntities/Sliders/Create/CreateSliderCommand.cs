using Microsoft.AspNetCore.Http;
using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommand : IBaseCommand
    {
        //private CreateSliderCommand()
        //{
            
        //}
        //public CreateSliderCommand(string link, IFormFile imageFile, string title)
        //{
        //    Link = link;
        //    ImageFile = imageFile;
        //    Title = title;
        //}

        public string Link { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Title { get; set; }
    }
}
