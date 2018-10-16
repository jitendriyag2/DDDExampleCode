﻿// Copyright (c) 2018 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using DataLayer.EfClasses.PocoOnly;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EfCode.Configurations.PocoOnly
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure
            (EntityTypeBuilder<Book> entity)
        {
            entity.Property(p => p.PublishedOn).HasColumnType("date");        

            entity.Property(p => p.ActualPrice)
                .HasColumnType("decimal(9,2)");

            entity.Property(x => x.ImageUrl)
                .IsUnicode(false);

            entity.HasIndex(x => x.PublishedOn);
            entity.HasIndex(x => x.ActualPrice);

            //----------------------------
            //relationships

            entity.HasMany(p => p.Reviews)  
                .WithOne();

            entity.Metadata
                .FindNavigation(nameof(Book.Reviews))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            entity.Metadata
                .FindNavigation(nameof(Book.AuthorsLink))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}