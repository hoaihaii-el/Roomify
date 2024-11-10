using Microsoft.EntityFrameworkCore;
using RoomifyAR.Entities;
using RoomifyAR.StaticServices;

namespace RoomifyAR.Repositories
{
    public class Seeder
    {
        public static async Task InitializeData(DataContext context)
        {
            await context.Database.MigrateAsync();

            var admin = await context.Users.Where(u => u.Username == "admin").FirstOrDefaultAsync();
            if (admin == null)
            {
                context.Users.Add(new User
                {
                    Username = "admin",
                    Email = "admin@gmail.com",
                    PasswordHash = PasswordHasher.Hash("admin@123"),
                    Role = "Admin",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                });

                await context.SaveChangesAsync();
            }

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category
                {
                    Name = "Sofa",
                    Description = "Sofa"
                });
                context.Categories.Add(new Category
                {
                    Name = "Bed",
                    Description = "Bed"
                });
                context.Categories.Add(new Category
                {
                    Name = "Desk",
                    Description = "Desk"
                });
                context.Categories.Add(new Category
                {
                    Name = "Chair",
                    Description = "Chair"
                });

                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Cozy Sofa", Description = "A comfortable sofa", Price = 1500, Stock = 10, CategoryId = 1 },
                    new Product { Name = "Elegant Bed", Description = "A luxury bed", Price = 2500, Stock = 5, CategoryId = 2 },
                    new Product { Name = "Office Desk", Description = "A modern office desk", Price = 1200, Stock = 8, CategoryId = 3 },
                    new Product { Name = "Simple Chair", Description = "A stylish chair", Price = 600, Stock = 15, CategoryId = 4 },

                    new Product { Name = "Lounge Sofa", Description = "A sofa for lounge", Price = 1800, Stock = 7, CategoryId = 1 },
                    new Product { Name = "King Size Bed", Description = "A spacious king size bed", Price = 2800, Stock = 3, CategoryId = 2 },
                    new Product { Name = "Study Desk", Description = "Perfect for studying", Price = 1100, Stock = 12, CategoryId = 3 },
                    new Product { Name = "Dining Chair", Description = "Comfortable dining chair", Price = 550, Stock = 20, CategoryId = 4 },

                    new Product { Name = "Classic Sofa", Description = "Classic design sofa", Price = 1700, Stock = 6, CategoryId = 1 },
                    new Product { Name = "Queen Bed", Description = "Queen size bed", Price = 2300, Stock = 4, CategoryId = 2 },
                    new Product { Name = "Gaming Desk", Description = "Designed for gaming", Price = 1300, Stock = 10, CategoryId = 3 },
                    new Product { Name = "Recliner Chair", Description = "A relaxing recliner chair", Price = 750, Stock = 8, CategoryId = 4 },

                    new Product { Name = "Modern Sofa", Description = "Modern styled sofa", Price = 2000, Stock = 9, CategoryId = 1 },
                    new Product { Name = "Bunk Bed", Description = "Perfect for kids", Price = 1900, Stock = 5, CategoryId = 2 },
                    new Product { Name = "Executive Desk", Description = "Large executive desk", Price = 1600, Stock = 6, CategoryId = 3 },
                    new Product { Name = "Office Chair", Description = "Ergonomic office chair", Price = 800, Stock = 18, CategoryId = 4 }
                };

                context.Products.AddRange(products);
                await context.SaveChangesAsync();

                #region SOFA
                var mediaSofa1 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 1, Order = 1, Url = "https://www.ikea.com/us/en/images/products/morabo-sleeper-sofa-grann-bomstad-black-metal__1170130_pe892673_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 1, Order = 2, Url = "https://www.ikea.com/us/en/images/products/morabo-sleeper-sofa-grann-bomstad-black-metal__0813412_ph166311_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 1, Order = 3, Url = "https://www.ikea.com/us/en/images/products/morabo-sleeper-sofa-grann-bomstad-black-metal__1170128_pe892695_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 1, Order = 4, Url = "https://www.ikea.com/us/en/images/products/morabo-sleeper-sofa-grann-bomstad-black-metal__1170128_pe892695_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaSofa1);

                var mediaSofa2 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 5, Order = 1, Url = "https://www.ikea.com/us/en/images/products/viskafors-loveseat-hoegalid-brown-brown__1088061_pe861036_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 5, Order = 2, Url = "https://www.ikea.com/us/en/images/products/viskafors-loveseat-hoegalid-brown-brown__1096079_pe864196_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 5, Order = 3, Url = "https://www.ikea.com/us/en/images/products/viskafors-loveseat-hoegalid-brown-brown__1096082_pe864198_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 5, Order = 4, Url = "https://www.ikea.com/us/en/images/products/viskafors-loveseat-hoegalid-brown-brown__1096082_pe864198_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaSofa2);

                var mediaSofa3 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 9, Order = 1, Url = "https://www.ikea.com/us/en/images/products/morabo-sleeper-sofa-grann-bomstad-black-metal__1170130_pe892673_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 9, Order = 2, Url = "https://www.ikea.com/us/en/images/products/morabo-sleeper-sofa-grann-bomstad-black-metal__0813412_ph166311_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 9, Order = 3, Url = "https://www.ikea.com/us/en/images/products/morabo-sleeper-sofa-grann-bomstad-black-metal__1170128_pe892695_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 9, Order = 4, Url = "https://www.ikea.com/us/en/images/products/morabo-sleeper-sofa-grann-bomstad-black-metal__1170128_pe892695_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaSofa3);

                var mediaSofa4 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 13, Order = 1, Url = "https://www.ikea.com/us/en/images/products/viskafors-loveseat-hoegalid-brown-brown__1088061_pe861036_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 13, Order = 2, Url = "https://www.ikea.com/us/en/images/products/viskafors-loveseat-hoegalid-brown-brown__1096079_pe864196_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 13, Order = 3, Url = "https://www.ikea.com/us/en/images/products/viskafors-loveseat-hoegalid-brown-brown__1096082_pe864198_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 13, Order = 4, Url = "https://www.ikea.com/us/en/images/products/viskafors-loveseat-hoegalid-brown-brown__1096082_pe864198_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaSofa4);
                #endregion

                #region BED
                var mediaBed1 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 2, Order = 1, Url = "https://www.ikea.com/us/en/images/products/ramnefjaell-upholstered-bed-frame-kilanda-light-beige-luroey__1258172_pe927371_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 2, Order = 2, Url = "https://www.ikea.com/us/en/images/products/ramnefjaell-upholstered-bed-frame-kilanda-light-beige-luroey__1258175_pe927363_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 2, Order = 3, Url = "https://www.ikea.com/us/en/images/products/ramnefjaell-upholstered-bed-frame-kilanda-light-beige-luroey__1258195_pe927382_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 2, Order = 4, Url = "https://www.ikea.com/us/en/images/products/ramnefjaell-upholstered-bed-frame-kilanda-light-beige-luroey__1258194_pe927381_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaBed1);

                var mediaBed2 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 6, Order = 1, Url = "https://www.ikea.com/us/en/images/products/tarva-bed-frame-pine-luroey__0637611_pe698421_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 6, Order = 2, Url = "https://www.ikea.com/us/en/images/products/tarva-bed-frame-pine-luroey__1102036_pe866857_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 6, Order = 3, Url = "https://www.ikea.com/us/en/images/products/tarva-bed-frame-pine-luroey__0284838_pe362962_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 6, Order = 4, Url = "https://www.ikea.com/us/en/images/products/tarva-bed-frame-pine-luroey__1102038_pe866859_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaBed2);

                var mediaBed3 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 10, Order = 1, Url = "https://www.ikea.com/us/en/images/products/ramnefjaell-upholstered-bed-frame-kilanda-light-beige-luroey__1258172_pe927371_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 10, Order = 2, Url = "https://www.ikea.com/us/en/images/products/ramnefjaell-upholstered-bed-frame-kilanda-light-beige-luroey__1258175_pe927363_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 10, Order = 3, Url = "https://www.ikea.com/us/en/images/products/ramnefjaell-upholstered-bed-frame-kilanda-light-beige-luroey__1258195_pe927382_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 10, Order = 4, Url = "https://www.ikea.com/us/en/images/products/ramnefjaell-upholstered-bed-frame-kilanda-light-beige-luroey__1258194_pe927381_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaBed3);

                var mediaBed4 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 14, Order = 1, Url = "https://www.ikea.com/us/en/images/products/tarva-bed-frame-pine-luroey__0637611_pe698421_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 14, Order = 2, Url = "https://www.ikea.com/us/en/images/products/tarva-bed-frame-pine-luroey__1102036_pe866857_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 14, Order = 3, Url = "https://www.ikea.com/us/en/images/products/tarva-bed-frame-pine-luroey__0284838_pe362962_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 14, Order = 4, Url = "https://www.ikea.com/us/en/images/products/tarva-bed-frame-pine-luroey__1102038_pe866859_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaBed4);
                #endregion

                #region DESK
                var mediaDesk1 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 3, Order = 1, Url = "https://www.ikea.com/us/en/images/products/moerbylanga-table-oak-veneer-brown-stained__0737110_pe740888_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 3, Order = 2, Url = "https://www.ikea.com/us/en/images/products/moerbylanga-table-oak-veneer-brown-stained__1360001_pe954330_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 3, Order = 3, Url = "https://www.ikea.com/us/en/images/products/moerbylanga-table-oak-veneer-brown-stained__1143384_pe881487_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 3, Order = 4, Url = "https://www.ikea.com/us/en/images/products/moerbylanga-table-oak-veneer-brown-stained__1016079_ph174029_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaDesk1);

                var mediaDesk2 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 7, Order = 1, Url = "https://www.ikea.com/us/en/images/products/ingo-table-pine__0737092_pe740877_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 7, Order = 2, Url = "https://www.ikea.com/us/en/images/products/ingo-table-pine__0383084_pe292394_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 7, Order = 3, Url = "https://www.ikea.com/us/en/images/products/ingo-table-pine__0871833_pe594936_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 7, Order = 4, Url = "https://www.ikea.com/us/en/images/products/ingo-table-pine__0949575_pe799868_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaDesk2);

                var mediaDesk3 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 11, Order = 1, Url = "https://www.ikea.com/us/en/images/products/moerbylanga-table-oak-veneer-brown-stained__0737110_pe740888_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 11, Order = 2, Url = "https://www.ikea.com/us/en/images/products/moerbylanga-table-oak-veneer-brown-stained__1360001_pe954330_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 11, Order = 3, Url = "https://www.ikea.com/us/en/images/products/moerbylanga-table-oak-veneer-brown-stained__1143384_pe881487_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 11, Order = 4, Url = "https://www.ikea.com/us/en/images/products/moerbylanga-table-oak-veneer-brown-stained__1016079_ph174029_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaDesk3);

                var mediaDesk4 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 15, Order = 1, Url = "https://www.ikea.com/us/en/images/products/ingo-table-pine__0737092_pe740877_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 15, Order = 2, Url = "https://www.ikea.com/us/en/images/products/ingo-table-pine__0383084_pe292394_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 15, Order = 3, Url = "https://www.ikea.com/us/en/images/products/ingo-table-pine__0871833_pe594936_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 15, Order = 4, Url = "https://www.ikea.com/us/en/images/products/ingo-table-pine__0949575_pe799868_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaDesk4);
                #endregion

                #region CHAIR
                var mediaChair1 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 4, Order = 1, Url = "https://www.ikea.com/us/en/images/products/ekenaeset-armchair-kilanda-light-beige__1109687_pe870153_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 4, Order = 2, Url = "https://www.ikea.com/us/en/images/products/ekenaeset-armchair-kilanda-light-beige__1179060_pe895831_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 4, Order = 3, Url = "https://www.ikea.com/us/en/images/products/ekenaeset-armchair-kilanda-light-beige__1110707_pe870568_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 4, Order = 4, Url = "https://www.ikea.com/us/en/images/products/ekenaeset-armchair-kilanda-light-beige__0940909_pe795235_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaChair1);

                var mediaChair2 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 8, Order = 1, Url = "https://www.ikea.com/us/en/images/products/sotenaes-armchair-hakebo-yellow__1262234_pe926999_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 8, Order = 2, Url = "https://www.ikea.com/us/en/images/products/sotenaes-armchair-hakebo-yellow__1272609_ph195671_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 8, Order = 3, Url = "https://www.ikea.com/us/en/images/products/sotenaes-armchair-hakebo-yellow__1262233_pe927000_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 8, Order = 4, Url = "https://www.ikea.com/us/en/images/products/sotenaes-armchair-hakebo-yellow__1333966_pe946622_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaChair2);

                var mediaChair3 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 12, Order = 1, Url = "https://www.ikea.com/us/en/images/products/ekenaeset-armchair-kilanda-light-beige__1109687_pe870153_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 12, Order = 2, Url = "https://www.ikea.com/us/en/images/products/ekenaeset-armchair-kilanda-light-beige__1179060_pe895831_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 12, Order = 3, Url = "https://www.ikea.com/us/en/images/products/ekenaeset-armchair-kilanda-light-beige__1110707_pe870568_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 12, Order = 4, Url = "https://www.ikea.com/us/en/images/products/ekenaeset-armchair-kilanda-light-beige__0940909_pe795235_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaChair3);

                var mediaChair4 = new List<ProductMedia>
                {
                    new ProductMedia{ ProductId = 16, Order = 1, Url = "https://www.ikea.com/us/en/images/products/sotenaes-armchair-hakebo-yellow__1262234_pe926999_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 16, Order = 2, Url = "https://www.ikea.com/us/en/images/products/sotenaes-armchair-hakebo-yellow__1272609_ph195671_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 16, Order = 3, Url = "https://www.ikea.com/us/en/images/products/sotenaes-armchair-hakebo-yellow__1262233_pe927000_s5.jpg?f=xl" },
                    new ProductMedia{ ProductId = 16, Order = 4, Url = "https://www.ikea.com/us/en/images/products/sotenaes-armchair-hakebo-yellow__1333966_pe946622_s5.jpg?f=xl" },
                };
                context.ProductMedias.AddRange(mediaChair4);
                #endregion

                await context.SaveChangesAsync();
            }
        }
    }
}
