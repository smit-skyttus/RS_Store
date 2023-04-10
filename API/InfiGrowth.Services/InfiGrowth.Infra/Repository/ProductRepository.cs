using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Context;
using InfiGrowth.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly InfiGrowthContext _context;

        public ProductRepository(InfiGrowthContext context)
        {
                _context = context;
        }
        public async Task<Products> CreateProduct(Products product)
        {
            var result = _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> DeleteProducts(int productId)
        {
            var result = await GetProductById(productId);
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Products>> GetAllProducts()
        {

            /*Adding Data in Product Table*/
            //var fileName = @"C:\Users\SMIT\Desktop\skyttus\thapareactecom\products.json";
            //var products = File.ReadAllText(fileName);
            //var data = JsonConvert.DeserializeObject<List<pro>>(products);
            //Console.WriteLine(data);



            //foreach (var item in data)
            //{
            //    var prod = new Products();
            //    prod.ProductName = item.name;
            //    prod.ProductPrice = item.price;
            //    prod.ProductImage = item.image;
            //    prod.ProductDescription = item.description;
            //    prod.CategoryId = 2;
            //    _context.Products.Add(prod);
            //    await _context.SaveChangesAsync();
            //}

            /*Adding data to Image Table*/
            //string url = "https://api.pujakaitem.com/api/products?id=thapaserialnol";



            //var textFromFile = (new WebClient()).DownloadString(url);
            //dynamic data = JsonConvert.DeserializeObject(textFromFile);



            //foreach (var item in data.image)
            //{
            //    var img = new Images();
            //    Console.WriteLine(item);
            //    if (item != null)
            //    {
            //        img.Name = item.id;
            //        img.Width = item.width;
            //        img.Height = item.height;
            //        img.Size = item.size;
            //        img.Link = item.url;
            //        img.Type = item.type;
            //        _context.Images.Add(img);
            //        _context.SaveChanges();
            //    }
            //    Console.WriteLine(item);
            //}

            //var result = _context.Products.FirstOrDefault(x => x.ProductId == 1);
            //var imgList = _context.Images.ToList();
            //result.Images = imgList;
            //_context.Products.Update(result);
            //_context.SaveChanges();

            /*Inserting foreignkey in images table*/

            //for (int i = 2; i <= 12; i++)
            //{
            //    var result = _context.Products.FirstOrDefault(x => x.ProductId == i);
            //    var imglist = _context.Images.Where(x => x.ImageId >= (i - 1) * 4 + 1 && x.ImageId <= i * 4).ToList();
            //    foreach (var img in imglist)
            //    {
            //        Console.WriteLine(img.ImageId);
            //    }
            //    result.Images = imglist;
            //    _context.Products.Update(result);
            //    _context.SaveChanges();
            //}
            return await _context.Products.Include(x=>x.Category).ToListAsync();
        }

        public async Task<Products> GetProductById(int productId)
        {
           return await _context.Products.Include(y=>y.Category).Include(x=>x.Images).FirstAsync(p => p.ProductId == productId);
        }

        public async Task<Products> UpdateProduct(Products product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
