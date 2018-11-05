using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiQuest.Models
{
    public class BeginInitialize : CreateDatabaseIfNotExists<AppDbContext>
    {
       // AppDbContext context = new AppDbContext();

        protected override void Seed(AppDbContext context)
        {
            if (context.Purchases.Any() && context.Products.Any() && context.SizeTables.Any()) return;
            SizeTable sizeXL = new SizeTable { SizeDescription = "It is big size for dress", SizeGuid = "XL" };
            SizeTable sizeL = new SizeTable { SizeDescription = "It is pre-big size for dress", SizeGuid = "L" };
            SizeTable sizeM = new SizeTable { SizeDescription = "It is middle size for dress", SizeGuid = "M" };
            SizeTable sizeS = new SizeTable { SizeDescription = "It is small size for dress", SizeGuid = "S" };

            Product redDress = new Product() { Description = "It is red dress for women", Price = 150 };
            Product yellowDress = new Product() { Description = "It is yellow dress for women", Price = 200 };
            Product whiteShirt = new Product() { Description = "It is white shirt for men", Price = 500 };
            Product blackShirt = new Product() { Description = "It is black shirt for men", Price = 400 };
            Product jacketMen = new Product() { Description = "It is jacket for men", Price = 1000 };

            context.SizeTables.AddRange(new SizeTable[] { sizeS, sizeM, sizeL, sizeXL });
            context.Products.AddRange(new Product[] { redDress, yellowDress, whiteShirt, blackShirt, jacketMen });
            context.Purchases.AddRange(new Purchase[]
            {
                new Purchase()
                {
                    Product = redDress,
                    SizeTable = sizeXL,
                    Name = "Miley",
                    LastDateOrder = DateTime.Now,

                },
                new Purchase()
                {
                    Product = yellowDress,
                    SizeTable = sizeM,
                    Name = "Kortney",
                    LastDateOrder = DateTime.Now,

                },
                new Purchase()
                {
                Product = whiteShirt,
                SizeTable = sizeL,
                Name = "Jack",
                LastDateOrder = DateTime.Now,

                },
                new Purchase()
                {
                    Product = whiteShirt,
                    SizeTable = sizeM,
                    Name = "Ruben",
                    LastDateOrder = DateTime.Now,

                },
                new Purchase()
                {
                    Product = blackShirt,
                    SizeTable = sizeL,
                    Name = "Kane",
                    LastDateOrder = DateTime.Now,

                },
                new Purchase()
                {
                    Product = whiteShirt,
                    SizeTable = sizeL,
                    Name = "Tobby",
                    LastDateOrder = DateTime.Now,

                },
                new Purchase()
                {
                    Product = redDress,
                    SizeTable = sizeS,
                    Name = "Amanda",
                    LastDateOrder = DateTime.Now,

                }
            });
            context.SaveChanges();

            base.Seed(context);
        }

        public void Initialize() => Seed(new AppDbContext());
    }
}