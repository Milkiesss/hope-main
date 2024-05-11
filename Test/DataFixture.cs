﻿using Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Test
{
    public class DataFixture
    {
        public DataFixture()
        {
            Context = new DataContext(
                new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(@"User ID=postgres;Password=mysecretpassword;Host=localhost;Port=5432;Database=NewSherif;").Options);
        }
        public DataContext Context { get; set; }

    }
}