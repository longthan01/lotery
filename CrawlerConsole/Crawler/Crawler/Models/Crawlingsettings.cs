using System;
using System.Collections.Generic;

namespace Crawler.Models
{
    public partial class Crawlingsettings
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
