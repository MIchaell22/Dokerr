using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStreamServiceApp.DAL.Entities;

namespace MusicStreamServiceApp.DAL.Configuration
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.HasData(
                new Catalog[] {
                    new Catalog { Id = 1, Name = "Голий король", Author = "Бумбокс", Year = 2017, PhotoPath = "Images/NakedKing.jpg"  },
                    new Catalog { Id = 2, Name = "Музасфера", Author = "Сергій Бабкін", Year = 2018, PhotoPath = "Images/Muzasfera.jpg" },
                    new Catalog { Id = 3, Name = "Один в каное", Author = "Один в каное", Year = 2016, PhotoPath = "Images/OdinVKanoe.jpg" },
                    new Catalog { Id = 4, Name = "III", Author = "Бумбокс", Year = 2008, PhotoPath = "Images/III.jpg" }
                });
        }
    }
}
