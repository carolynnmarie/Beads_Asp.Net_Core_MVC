using System;
using Microsoft.EntityFrameworkCore;
using BeadsInventory.Models;

namespace BeadsInventory.Models {

    public class StringingMaterialContext: DbContext {

        public StringingMaterialContext(DbContextOptions<StringingMaterialContext> options): base(options) {
        }

        public DbSet<StringingMaterial> StringingMaterials;

        public DbSet<BeadsInventory.Models.StringingMaterial> StringingMaterial { get; set; }
    }
}
