using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using WesthoughtonWorldOfWicker.Data;

namespace WesthoughtonWorldOfWicker.Models
{
    public static class SeedData
    {
        public static void Initialize(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<ApplicationDbContext>();
            if (!context.Category.Any())
            {
                var categories = new List<Category>
                {
                    new Category() { CategoryName = "Dining Room" },
                    new Category() { CategoryName = "Living Room" },
                    new Category() { CategoryName = "Conservatory"},
                    new Category() { CategoryName = "Garden" }
                };
                context.AddRange(categories);
                context.SaveChanges();
            }
            else
            {
            }

            if (!context.Product.Any())
            {
                var products = new List<Product>
                {
                   new Product() { CategoryId = 1, ModelNumber = 34896547, ModelName = "Kubu Rattan/Wicker Chair", productImageUrl = "http://i.ebayimg.com/images/g/VcYAAOSwzJ5XdC5F/s-l1600.jpg", UnitCost = 60, Description = "Kubu Grey Rattan/Wicker Dining Chair - Light leg" },
                   new Product() { CategoryId = 1, ModelNumber = 34896548, ModelName = "Wicker Dining Chairs (set of 2)", productImageUrl = "http://i.ebayimg.com/images/g/enAAAOSwNRdYANw4/s-l1600.jpg", UnitCost = 218, Description = "Wicker Merchant Dining Chairs-PAIR- Fully Assembled-Cushions Included-RRP" },
                   new Product() { CategoryId = 1, ModelNumber = 34896549, ModelName = "Rattan Dining table", productImageUrl = "http://i.ebayimg.com/images/g/GIcAAOSwJ4hY-h4R/s-l500.png", UnitCost = 80, Description = "Dining Table Rattan Wicker Patio Dining Room Furniture" },
                   new Product() { CategoryId = 1, ModelNumber = 34896550, ModelName = "Wicker Dining Table", productImageUrl = "http://i.ebayimg.com/images/g/rcYAAOSwWTRW064X/s-l1600.jpg", UnitCost = 100, Description = "Outsunny 9pc Rattan Dining Table Wicker Patio Table Weave" },
                   new Product() { CategoryId = 1, ModelNumber = 34896551, ModelName = "Rattan Furniture Dining Set", productImageUrl = "http://i.ebayimg.com/images/g/AS8AAOSwGIRXX5vV/s-l1600.jpg", UnitCost = 305, Description = "6 Seater Rattan Furniture Dining Set Chairs + Table Outdoor Wicker brown" },
                   new Product() { CategoryId = 1, ModelNumber = 34896552, ModelName = "Wicker Rattan Wooden Chair", productImageUrl = "http://i.ebayimg.com/images/g/1K4AAOSwrddY7OZW/s-l500.jpg", UnitCost =20, Description = "Wicker rattan wooden chair harola bamboo dressing table dining garden" },
                   new Product() { CategoryId = 1, ModelNumber = 34896553, ModelName = "3-Piece Dining Set", productImageUrl = "http://i.ebayimg.com/images/g/bNsAAOSwvKtY9jST/s-l1600.jpg", UnitCost = 169, Description = "Marseille 3 Piece Dining Set With Table 2x Chairs Wicker Rattan Furniture" },
                   new Product() { CategoryId = 1, ModelNumber = 34896554, ModelName = "Havana Rattan Wicker Dining Set", productImageUrl = "http://i.ebayimg.com/images/g/B4UAAOSwll1W1XQA/s-l1600.jpg", UnitCost = 399, Description = "Havana Rattan Wicker Dining 4-Seat Patio Furniture Table & Chairs Set" },
                   new Product() { CategoryId = 1, ModelNumber = 34896555, ModelName = "Bistro Dining Rattan Set", productImageUrl = "http://i.ebayimg.com/images/g/vp0AAOSwrklVecsF/s-l1600.jpg", UnitCost = 159, Description = "Bistro Rattan Wicker Dining Furniture Set Table Chairs" },
                   new Product() { CategoryId = 1, ModelNumber = 34896556, ModelName = "Ravenna Dining Set", productImageUrl = "http://i.ebayimg.com/images/g/KvAAAOSwIWVY9jMm/s-l1600.jpg", UnitCost = 150, Description = "Ravenna Dining Table 4 Chairs Brown Rattan Wicker Aluminium Garden Patio Outdoor" },
                   new Product() { CategoryId = 1, ModelNumber = 34896557, ModelName = "Wicker Dining Room Chairs (set of 4)", productImageUrl = "http://i.ebayimg.com/images/g/j3IAAOSw4GVYPKZf/s-l1600.jpg", UnitCost = 120, Description = "Kubu Rattan Dining Chair - Natural Wicker Furniture" },
                   new Product() { CategoryId = 1, ModelNumber = 34896558, ModelName = "Dark Brown Wicker Table", productImageUrl = "http://i.ebayimg.com/images/g/jXoAAOSwvKtY-MzA/s-l1600.jpg", UnitCost = 199, Description = "Rattan Modern Table Furniture Home Dinning Living Room Tables" },
                   new Product() { CategoryId = 2, ModelNumber = 43895777, ModelName = "Living Room Full Wicker Chair", productImageUrl = "http://i.ebayimg.com/00/s/MTE3N1gxMDAw/z/IDIAAOSwr81UREoS/$_35.JPG?set_id=2", UnitCost = 20, Description = "Living room chair" },
                   new Product() { CategoryId = 2, ModelNumber = 43895778, ModelName = "Decorative Round Sitting Murha", productImageUrl = "http://i.ebayimg.com/images/g/Qr4AAOSwzgBY3eWK/s-l1600.jpg", UnitCost = 44, Description = "Hand Woven Decorative Round Sitting Murha Handcrafted Wooden Wicker Murhas" },
                   new Product() { CategoryId = 2, ModelNumber = 43895779, ModelName = "Round Living Room Coffee Table", productImageUrl = "http://i.ebayimg.com/images/g/K1QAAOSwTM5YuUYa/s-l1600.jpg", UnitCost = 70, Description = "Elegant wicker glass table side end living room bed room coffe tea garden patio" },
                   new Product() { CategoryId = 2, ModelNumber = 43895780, ModelName = "Wicker Living Room Coffee Table", productImageUrl = "http://i.ebayimg.com/images/g/OBIAAOSw~OVWu0Pp/s-l1600.jpg", UnitCost = 270, Description = "Rattan Coffee Table Weave Rectangle Wicker Glass Wood Grey Patio. Size: 45 x 85cm." },
                   new Product() { CategoryId = 2, ModelNumber = 43895781, ModelName = "Glass Coffee Table", productImageUrl = "http://i.ebayimg.com/images/g/GS4AAOSwXYtY05xF/s-l500.jpg", UnitCost = 64, Description = "Rattan Glass Coffee Table Rectangular Patio Furniture Grey" },
                   new Product() { CategoryId = 2, ModelNumber = 43895782, ModelName = "Wicker Living Room Side Table", productImageUrl = "http://i.ebayimg.com/images/g/KfUAAOSw~CFY69uL/s-l1600.jpg", UnitCost = 65, Description = "Rectangle Coffee Table Hand Woven Rattan Living Room Side Table" },
                   new Product() { CategoryId = 2, ModelNumber = 43895783, ModelName = "Wicker Coffee Table With a Drawer", productImageUrl = "http://i.ebayimg.com/images/g/9HAAAOSwsTxXiMND/s-l1600.jpg", UnitCost = 75, Description = "Rattan Coffee Table Living Room Banana Leaf Glass Top Storage Drawer" },
                   new Product() { CategoryId = 2, ModelNumber = 43895784, ModelName = "Round Wicker Coffee Table", productImageUrl = "https://s-media-cache-ak0.pinimg.com/736x/13/ba/c3/13bac3f81953392c477648b02624319d.jpg", UnitCost = 30, Description = "Round Wcker Coffee Table. Diameter: 25cm" },
                   new Product() { CategoryId = 2, ModelNumber = 43895785, ModelName = "Set of 4 Furnhouse Larissa Side Chairs", productImageUrl = "http://i.ebayimg.com/images/g/N9AAAOSwo4pYVM8m/s-l500.jpg", UnitCost = 300, Description = "Furnhouse Larissa Side Chair Brown wash with cushion in Ivory" },
                   new Product() { CategoryId = 2, ModelNumber = 43895786, ModelName = "Wicker Chair Modern White Seat Cushion Wicker Armchair Indoor Arms.", productImageUrl = "http://i.ebayimg.com/images/g/vyQAAOSw4CFYoPA0/s-l1600.jpg", UnitCost = 190, Description = "This Rattan Chair is a beautiful natural rattan chair in white, complete with blue seat pad and scatter cushion which brings comfort and class to any room." },
                   new Product() { CategoryId = 2, ModelNumber = 43895787, ModelName = "Wicker Floor Seat", productImageUrl = "http://i.ebayimg.com/images/g/JwsAAOSwYXVY0mzd/s-l1600.jpg", UnitCost = 26, Description = "Natural outer with hidden internal black metal frame,very solid and firm, used mainly as a decoration piece and a great occasional additional seat. Diameter of seat 23 x 6 depth." },
                   new Product() { CategoryId = 2, ModelNumber = 43895788, ModelName = "Living Room Wicker Chair", productImageUrl = "http://i.ebayimg.com/images/g/Dv8AAOSw3ydVr7OJ/s-l1600.jpg", UnitCost = 50, Description = "Grey wash rattan wicker armchair conservatory furniture wicker chair" },
                   new Product() { CategoryId = 3, ModelNumber = 76876457, ModelName = "Provence Rattan Footstool", productImageUrl = "http://www.candleandblue.co.uk/WebRoot/Store3/Shops/es114052_es121978079119/5556/102D/DCA2/9887/1388/0A0F/110C/54CC/Provence-Rattan-Conservatory-Footstool.jpg", UnitCost = 195, Description = "Provence Rattan Conservatory Footstool Pearl Wash. Approx. size: 65cm x 50cm x H: 38cm" },
                   new Product() { CategoryId = 3, ModelNumber = 76876458, ModelName = "Rattan Side Table", productImageUrl = "http://www.candleandblue.co.uk/WebRoot/Store3/Shops/es114052_es121978079119/5575/ACB3/7DF4/FACC/E895/0A0F/111B/CFDA/Rattan-Conservatory-Side-Table-Michigan-with-Glass-Top.jpg", UnitCost = 125, Description = "Rattan Side Table Glass Top Michigan" },
                   new Product() { CategoryId = 3, ModelNumber = 76876459, ModelName = "Calais Coffee Table", productImageUrl = "http://www.gardenfurniturecentre.co.uk/media/catalog/product/cache/1/small_image/220x240/9df78eab33525d08d6e5fb8d27136e95/c/a/calais-coffee-table-L.jpg", UnitCost = 80, Description = "coffee table with a double thickness cane frame and decorative rattan side panels" },
                   new Product() { CategoryId = 3, ModelNumber = 76876460, ModelName = "Conservatory Coffee Table", productImageUrl = "http://www.candleandblue.co.uk/WebRoot/Store3/Shops/es114052_es121978079119/517F/E521/7C70/9D2F/8CE4/0A0F/1119/9E78/17-793-TOKW.jpg", UnitCost = 165, Description = "Salzburg Oak Wash Rattan Conservatory Coffee Table With Shelf" },
                   new Product() { CategoryId = 3, ModelNumber = 76876461, ModelName = "Conservatory Bistro Table ", productImageUrl = "https://www.alfresia.co.uk/media/catalog/product/cache/2/thumbnail/115x/9df78eab33525d08d6e5fb8d27136e95/t/a/table.jpg", UnitCost = 70, Description = "Atlanta Cane and Wicker Conservatory Bistro Table" },
                   new Product() { CategoryId = 3, ModelNumber = 76876462, ModelName = "Cane and Wicker Conservatory Table", productImageUrl = "http://i.ebayimg.com/images/g/JHAAAOSwyjBW4bhH/s-l1600.jpg", UnitCost = 124, Description = "Country Cane Conservatory Furniture Rattan Wicker Coffee Table With Shelf" },
                   new Product() { CategoryId = 3, ModelNumber = 76876463, ModelName = "Cream Wicker Conservatory Chair", productImageUrl = "http://i.ebayimg.com/images/g/GEoAAOSwV0RXrvar/s-l500.jpg", UnitCost = 30, Description = "Wicker Chair Cream Shabby Chic Decoupage Conservatory Bedroom" },
                   new Product() { CategoryId = 3, ModelNumber = 76876464, ModelName = "Wicker Conservatory Chair", productImageUrl = "http://i.ebayimg.com/images/g/kXQAAOSw44BYLcXL/s-l1600.jpg", UnitCost = 225, Description = "Lloyd Loom Wicker Conservatory Chair / Burghley Chair With Upholstered Seat" },
                   new Product() { CategoryId = 3, ModelNumber = 76876465, ModelName = "Rattan Wicker Armchair", productImageUrl = "http://i.ebayimg.com/images/g/2nEAAOSw44BYdYvL/s-l500.jpg", UnitCost = 78, Description = "Wicker Armchair Furniture Rattan Conservatory Chair Room Patio Seat Wooden Frame" },
                   new Product() { CategoryId = 3, ModelNumber = 76876466, ModelName = "Wicker Conservatory Armchair", productImageUrl = "http://i.ebayimg.com/images/g/y5oAAOSww3tY3lSm/s-l1600.jpg", UnitCost = 18, Description = "Wicker Armchair Furniture Rattan Conservatory Chair Room Patio Seat" },
                   new Product() { CategoryId = 3, ModelNumber = 76876467, ModelName = "Cane Wicker Chair", productImageUrl = "http://i.ebayimg.com/images/g/gXAAAOSw7XBY8P3V/s-l1600.jpg", UnitCost = 13, Description = "Cane wicker conservatory chair" },
                   new Product() { CategoryId = 3, ModelNumber = 76876468, ModelName = "Wicker Convservatory Table", productImageUrl = "http://www.antiquehelper.com/auctionimages/31131t.jpg", UnitCost = 60, Description = "Conservatory wicker table" },
                   new Product() { CategoryId = 4, ModelNumber = 76876876, ModelName = "Garden While and Blue Wicker Chair", productImageUrl = "http://www.maisonsdumonde.com/img/wicker-garden-armchair-in-white-blue-kafe-1000-8-28-155541_1.jpg", UnitCost = 25, Description = "Garden Wicker Chair with white and blue pattern" },
                   new Product() { CategoryId = 4, ModelNumber = 76876877, ModelName = "Garden Outdoor Patio Chair", productImageUrl = "http://www.kdjay.co.uk/ebay/products/BISTRO-CHAIR_1.jpg", UnitCost = 18, Description = "Garden Outdoor patio chairs with black metal frame and wicker rattan woven seat" },
                   new Product() { CategoryId = 4, ModelNumber = 76876878, ModelName = "Garden Patio chair", productImageUrl = "http://tuinmeubelslo.nl/contents/media/l_zaragozzazwart-66.jpg", UnitCost = 20, Description = "Stainless steel garden patio chair with armrests" },
                   new Product() { CategoryId = 4, ModelNumber = 76876879, ModelName = "Aluminium and brown rattan garden patio chair", productImageUrl = "http://www.amatop10.com/wp-content/uploads/2015/12/Flash-Furniture-Rattan-Indoor-Outdoor-Patio-Chair-300x300.jpg", UnitCost = 25, Description = "Flash Furniture Wicker Rattan Indoor-Outdoor Patio Chair" },
                   new Product() { CategoryId = 4, ModelNumber = 76876880, ModelName = "Garden Rattan Coffee table", productImageUrl = "http://i.ebayimg.com/00/s/NTAwWDUwMA==/z/1msAAOSwGIRXZPzd/$_35.JPG?set_id=8800005007", UnitCost = 35, Description = "Rattan Side Table Outdoor Garden Furniture Rattan Coffee End Table Glass Plate" },
                   new Product() { CategoryId = 4, ModelNumber = 76876881, ModelName = "Garden Rattan Side table", productImageUrl = "http://i.ebayimg.com/images/g/4WIAAOSwNSxVYo9s/s-l1600.jpg", UnitCost = 75, Description = "Rattan Side Table Garden Furniture Patio Tempered Glass Brown New" },
                   new Product() { CategoryId = 4, ModelNumber = 76876882, ModelName = "Garden/Balcony Black Rattan Coffee Table", productImageUrl = "http://i.ebayimg.com/images/g/1msAAOSwGIRXZPzd/s-l500.jpg", UnitCost = 44, Description = "Coffee Tea Table Rattan Black Small Side Table Terrace Patio Garden Balcony" },
                   new Product() { CategoryId = 4, ModelNumber = 76876883, ModelName = "Luxury Garden Coffee Table", productImageUrl = "http://i.ebayimg.com/images/g/5xkAAOSw~CFY6hZm/s-l1600.jpg", UnitCost = 40, Description = "Luxury Outdoor Garden Square End Coffee Table Black Rattan Clear Glass" },
                   new Product() { CategoryId = 4, ModelNumber = 76876884, ModelName = "Black Rattan Ice Cooler Table Bucket", productImageUrl = "http://i.ebayimg.com/images/g/GWMAAOSwc-tY75N0/s-l1600.jpg", UnitCost = 60, Description = "Ice Cooler Table Bucket Box Garden Patio Rattan Side ExtraSeat Outdoor Furniture" },
                   new Product() { CategoryId = 4, ModelNumber = 76876885, ModelName = "Rattan Wicker Garden Side Table", productImageUrl = "http://i.ebayimg.com/images/g/4lYAAOSwV0RXqkd0/s-l1600.jpg", UnitCost = 80, Description = "Eden/Hampton Rattan Wicker Outdoor Furniture Side Table" },
                   new Product() { CategoryId = 4, ModelNumber = 76876886, ModelName = "Rattan Side Table", productImageUrl = "http://i.ebayimg.com/images/g/MqMAAOSw4A5Y19BE/s-l1600.jpg", UnitCost = 50, Description = "Outsunny Rattan Side Table Brand New" },
                   new Product() { CategoryId = 4, ModelNumber = 76876886, ModelName = "Small Garden Wicker Table", productImageUrl = "http://i.ebayimg.com/images/g/KwcAAOSwTM5Y3OIt/s-l500.jpg", UnitCost = 85, Description = "Small Garden Table Coffee Bistro Pu Rattan Patio Balcony Side Table" },
                };
                context.AddRange(products);
                context.SaveChanges();
            }
            else
            {
            }

        }
        }
}