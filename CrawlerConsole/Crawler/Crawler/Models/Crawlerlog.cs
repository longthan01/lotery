using System;
using System.Collections.Generic;

namespace Crawler.Models
{
    public partial class Crawlerlog
    {
        public Guid Id { get; set; }
        public DateTime Lastrun { get; set; }
        public string Sourceurl { get; set; }
    }
}
