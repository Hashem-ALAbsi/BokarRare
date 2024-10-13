using BokarRare.Models;
using Microsoft.EntityFrameworkCore;

namespace BokarRare.Data
{
    public class ApplicetionDbContext :DbContext
    {
        public ApplicetionDbContext(DbContextOptions<ApplicetionDbContext> options) : base(options)
        {
            
        }
        //public DbSet<cls_Studenty>Students { get; set; }
        public DbSet<cls_curse>Curses { get; set; }
        public DbSet<cls_Tectar>Tectars { get; set; }
        public DbSet<cls_User>Users { get; set; }
        //public DbSet<cls_dagrees>Dagrees { get; set; }
        public DbSet<cls_TypeUser>TypeUsers { get; set; }
        public DbSet<cls_Type>Types { get; set; }
        public DbSet<BokarRare.Models.cls_Studenty>? cls_Studenty { get; set; }
        public DbSet<BokarRare.Models.cls_Students>? cls_Students { get; set; }
        public DbSet<cls_tbgad> Tbgads { get; set; }

    }
}
