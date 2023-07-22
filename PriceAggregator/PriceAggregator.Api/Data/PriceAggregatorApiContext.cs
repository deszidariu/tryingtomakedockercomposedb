using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriceAggregator.Api.Models;

namespace PriceAggregator.Api.Data
{
    public class PriceAggregatorApiContext : DbContext
    {
        public PriceAggregatorApiContext (DbContextOptions<PriceAggregatorApiContext> options)
            : base(options)
        {
        }

        public DbSet<Price> Price { get; set; } = default!;
    }
}
