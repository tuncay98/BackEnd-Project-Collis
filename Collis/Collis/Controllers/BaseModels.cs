using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Collis.Models;

namespace Collis.Controllers
{
    public class BaseModels
    {
        public List<HomePage> hm { get; set; }
        public List<HomeSlideText> ht { get; set; }
        public List<SocialSite> ss { get; set; }
        public About about { get; set; }
        public List<Service> services { get; set; }
        public List<Counter> cou { get; set; }
        public List<Protofilio> pro { get; set; }
        public List<Collis.Models.Filter> fil { get; set; }
        public List<Testimonial> testi { get; set; }
        public List<News> news { get; set; }
    }
}