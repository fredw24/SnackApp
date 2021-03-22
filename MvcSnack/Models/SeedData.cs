using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcSnack.Data;

namespace MvcSnack.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcSnackContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcSnackContext>>()))
            {
                // Look for any Snacks.
                if (context.Snack.Any())
                {
                    return;   // DB has been seeded
                }

                context.Snack.AddRange(
                    new Snack
                    {
                        Title = "Doritos",
                        ReleaseDate = DateTime.Parse("1964-5-12"),
                        Types = "Salty",
                        Price = 2.99M,
                        Company = "Frito-Lay"
                    },

                    new Snack
                    {
                        Title = "Twixs",
                        ReleaseDate = DateTime.Parse("1967-2-10"),
                        Types = "Sweet",
                        Price = 1.09M,
                        Company = "Mars, Inc."
                    },

                    new Snack
                    {
                        Title = "String Cheese",
                        ReleaseDate = DateTime.Parse("1976-6-23"),
                        Types = "Creamy",
                        Price = 2.49M,
                        Company = "Krafts"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
