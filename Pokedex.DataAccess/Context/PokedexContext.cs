using Microsoft.EntityFrameworkCore;
using Pokedex.DataAccess.Entities;

namespace Pokedex.DataAccess.Context
{
    public class PokedexContext : DbContext
    {
        public PokedexContext() { }
        
        public PokedexContext(DbContextOptions<PokedexContext> options)
            : base(options) { }
        
        public virtual DbSet<Entities.Pokemon> Pokemon { get; set; }
        public virtual DbSet<Entities.Species> Species { get; set; }
        public virtual DbSet<Entities.Move> Move { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();

                entity.HasOne(e => e.Species)
                    .WithMany(s => s.Pokemon)
                    .HasForeignKey(e => e.SpeciesId)
                    .HasConstraintName("FK_Pokemon_Species");
                
                entity.HasOne(e => e.Move1)
                    .WithMany(m => m.Pokemon)
                    .HasForeignKey(e => e.Move1Id)
                    .HasConstraintName("FK_Pokemon_Move1");
                
                entity.HasOne(e => e.Move2)
                    .WithMany(m => m.Pokemon)
                    .HasForeignKey(e => e.Move2Id)
                    .HasConstraintName("FK_Pokemon_Move2");
                
                entity.HasOne(e => e.Move3)
                    .WithMany(m => m.Pokemon)
                    .HasForeignKey(e => e.Move3Id)
                    .HasConstraintName("FK_Pokemon_Move3");
                
                entity.HasOne(e => e.Move4)
                    .WithMany(m => m.Pokemon)
                    .HasForeignKey(e => e.Move4Id)
                    .HasConstraintName("FK_Pokemon_Move4");

                entity.Property(e => e.Level).IsRequired();
                entity.Property(e => e.Nature).IsRequired();
                entity.Property(e => e.SpeciesId).IsRequired();
                entity.Property(e => e.Move1Id).IsRequired();
                entity.Property(e => e.IV).IsRequired();
                entity.Property(e => e.EV).IsRequired();
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.PrimaryType).IsRequired();
                entity.Property(e => e.Weight).IsRequired();
                entity.Property(e => e.Height).IsRequired();
                entity.Property(e => e.BaseStats).IsRequired();

                entity.HasMany(e => e.MovePool)
                    .WithMany(e => e.Species);
                
            });

            modelBuilder.Entity<Move>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Power).IsRequired();
            });
        }
    }
}