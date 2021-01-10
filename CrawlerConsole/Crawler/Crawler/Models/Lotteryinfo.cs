using System;
using System.Collections.Generic;

namespace Crawler.Models
{
    public partial class Lotteryinfo
    {
        public Guid Id { get; set; }
        public DateTime? Date { get; set; }
        public string Province { get; set; }
        public string Number { get; set; }
        public short? Matchtype { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public LoteryTypes LoteryType { get; set; }
    }
}
