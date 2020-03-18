using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF_Prism_MarvelCards.Model;

namespace MarvelCardsWebAPI.Data
{
    public class MarvelCardsWebAPIContext : DbContext
    {
        public MarvelCardsWebAPIContext(DbContextOptions<MarvelCardsWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Hero> Hero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().HasData(
                new Hero()
                {
                    Id = 1,
                    HeroName = "spider man",
                    RealName = "peter parker",
                    HeroColor = "#C51925",
                    Image = "spiderman.png"
                },
                new Hero()
                {
                    Id = 2,
                    HeroName = "iron man",
                    RealName = "tony stark",
                    HeroColor = "#DF8E04",
                    Image = "ironman.png"
                },
                new Hero()
                {
                    Id = 3,
                    HeroName = "This is Test Data",
                    RealName = "tony stark",
                    HeroColor = "#5DDF04",
                    Image = "ironman.png"
                },
                new Hero()
                {
                    Id = 4,
                    HeroName = "This is Test Data2",
                    RealName = "tony stark",
                    HeroColor = "#040DDF",
                    Image = "ironman.png"
                }
                 );
        }
    }
}
