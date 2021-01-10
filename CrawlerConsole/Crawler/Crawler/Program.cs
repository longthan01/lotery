using Crawler.Models;
using System;
using System.Linq;

namespace Crawler
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var context = new LoteryContext(new Microsoft.EntityFrameworkCore.DbContextOptions<LoteryContext>());
            context.Crawlingstate.ToList();
        }
    }
}
