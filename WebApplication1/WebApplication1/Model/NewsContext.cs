
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.ViewModel;

namespace WebApplication1.Model
{
    public class NewsContext: DbContext
    {
        public DbSet<News> News { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(@"Data Source=SQL8001.site4now.net;Initial Catalog=db_a86349_sportapi;Persist Security Info=True;User ID=db_a86349_sportapi_admin;Password=Omer10Attias");


        //}
        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {

        }

    }
}
