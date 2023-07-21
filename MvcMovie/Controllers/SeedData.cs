using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var provider = serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>();
        using (var context = new MvcMovieContext(provider))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                //foreach (MvcMovie.Models.Movie item in context.Movie)
                //{
                //    int Id = item.Id;
                //    string? Title = item.Title;
                //    DateTime ReleaseDate = item.ReleaseDate;
                //    string? Genre = item.Genre;
                //    decimal Price = item.Price;
                //}
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Rating = "R",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}
