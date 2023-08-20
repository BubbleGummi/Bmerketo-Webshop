using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApp.Models.Contexts;
using WebApp.Models.Dtos;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class ProductService
    {
        private readonly DataContext _context;
        private readonly ProductRepository _productRepository;
        private readonly ProductTagRepository _productTagRepository;

        public ProductService(DataContext context, ProductRepository productRepository, ProductTagRepository productTagRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
        }

        public async Task<bool> CreateProductAsync(CreateProductViewModel createProductViewModel)
        {
            try
            {
                ProductEntity productEntity = (ProductEntity)createProductViewModel;

                _context.Products.Add(productEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = new List<ProductModel>();
            var items = await _context.Products.ToListAsync();
            foreach (var item in items)
            {
                ProductModel productModel = item;
                products.Add(productModel);
            }

            return products;
        }

        public async Task<IEnumerable<ProductModel>> GetByNewCollectionTagAsync()
        {
            var products = new List<ProductModel>();
            var items = await _context.ProductTags.Where(x => x.TagId == 1).Select(x => x.Product).ToListAsync();
            foreach (var item in items)
            {
                ProductModel productModel = item;
                products.Add(productModel);
            }

            return products;
        }

        public async Task<IEnumerable<ProductModel>> GetByPopularCollectionTagAsync()
        {
            var products = new List<ProductModel>();
            var items = await _context.ProductTags.Where(x => x.TagId == 2).Select(x => x.Product).ToListAsync();
            foreach (var item in items)
            {
                ProductModel productModel = item;
                products.Add(productModel);
            }

            return products;
        }

        public async Task<IEnumerable<ProductModel>> GetByFeaturedCollectionTagAsync()
        {
            var products = new List<ProductModel>();
            var items = await _context.ProductTags.Where(x => x.TagId == 3).Select(x => x.Product).ToListAsync();
            foreach (var item in items)
            {
                ProductModel productModel = item;
                products.Add(productModel);
            }

            return products;
        }

        public async Task<IEnumerable<ProductModel>> GetByCategoryAsync()
        {
            var products = new List<ProductModel>();
            var items = await _context.Products.Include(x => x.Category).ToListAsync();
            foreach (var item in items)
            {
                ProductModel productModel = item;
                products.Add(productModel);
            }

            return products;
        }

        public async Task<ProductModel> GetProductAsync(string productName)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductName == productName);
            return product;
        }

        public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
        {
            var productEntity = await _productRepository.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
            foreach (var tag in tags)
            {
                await _productTagRepository.AddAsync(new ProductTagEntity
                {
                    ProductId = productEntity.Id,
                    TagId = int.Parse(tag)
                });
            }
        }

        internal Task<string?> GetProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
