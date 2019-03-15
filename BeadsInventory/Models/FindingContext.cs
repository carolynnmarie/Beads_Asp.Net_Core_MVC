using System;
using Microsoft.EntityFrameworkCore;
using BeadsInventory.Models;

namespace BeadsInventory.Models {

    public class FindingContext: DbContext {

        public FindingContext(DbContextOptions<FindingContext> options) : base(options) {
        }

        public DbSet<Finding> Findings;

        public DbSet<BeadsInventory.Models.Finding> Finding { get; set; }
    }
}
