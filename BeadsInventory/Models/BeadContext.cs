using System;
using Microsoft.EntityFrameworkCore;
using BeadsInventory.Models;

namespace BeadsInventory.Models {

    public class BeadContext: DbContext {

        public BeadContext(DbContextOptions<BeadContext> options) : base(options){
        }

        public DbSet<Bead> Beads;

        public DbSet<BeadsInventory.Models.Bead> Bead { get; set; }
    }
}
