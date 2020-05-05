using System;
using Colind.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Colind.API.Persistence
{
    public class ColindContext: DbContext
    {
        public ColindContext(DbContextOptions<ColindContext> options): base(options)
        { }

        public DbSet<ColindEntity> Colinds { get; set; } = null!;
        public DbSet<TagEntity> Tags { get; set; } = null!;
        public DbSet<ColindTagEntity> ColindTag { get; set; } = null!;
        public DbSet<AuthorEntity> Authors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColindTagEntity>()
                .HasKey(ct => new { ct.TagName, ct.ColindId });

            modelBuilder.Entity<ColindTagEntity>()
                .HasOne<ColindEntity>(ct => ct.Colind)
                .WithMany(c => c.ColindTags)
                .HasForeignKey(ct => ct.ColindId);


            modelBuilder.Entity<ColindTagEntity>()
                .HasOne<ColindEntity>(ct => ct.Colind)
                .WithMany(c => c.ColindTags)
                .HasForeignKey(ct => ct.ColindId);

            modelBuilder.Entity<ColindEntity>()
                .HasOne<AuthorEntity>(c => c.Author)
                .WithMany(a => a.Colinds)
                .HasForeignKey(c => c.AuthorFullName);

            modelBuilder.Entity<AuthorEntity>()
                .HasIndex(a => new { a.FullName });

            modelBuilder.Entity<TagEntity>()
                .HasIndex(t => new { t.Name });
        }
    }
}
