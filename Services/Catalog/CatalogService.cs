﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.EntityFrameworkCore;
using Services.Catalog.Requests;

namespace Services.Catalog
{
    internal class CatalogService : ICatalog
    {
        private readonly ShopContext _dbContext;

        public CatalogService(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetWithFilters(CatalogFilters filters)
        {
            var products = filters.SortByPrice
                ? _dbContext.Product.OrderBy(product => product.Price).AsQueryable()
                : _dbContext.Product.OrderByDescending(product => product.Price).AsQueryable();

            if (!string.IsNullOrEmpty(filters.NameContains))
                products = products.Where(product => product.Name.Contains(filters.NameContains));

            if (filters.PriceHigherThan != null)
                products = products.Where(product => product.Price >= filters.PriceHigherThan);

            if (filters.PriceLowerThan != null)
                products = products.Where(product => product.Price <= filters.PriceLowerThan);

            if (filters.Genders != null)
                products = products.Where(product => filters.Genders.Contains(product.Gender));

            if (filters.Categories != null)
                products = products.Where(product => filters.Categories.Contains(product.Category));

            if (filters.Brands != null)
                products = products.Where(product => filters.Brands.Contains(product.Brand));

            if (filters.Colors != null)
                products = products.Where(product => filters.Colors.Contains(product.Color));

            if (filters.Sizes != null)
            {
                var ids = _dbContext.ProductSize.Where(ps => filters.Sizes.Contains(ps.Size))
                    .Select(ps => ps.ProductId);
                products = products.Where(product => ids.Contains(product.Id));
            }

            return await products.ToListAsync();
        }

        public async Task<Dictionary<string, short>> GetSizesFor(int productId)
        {
            return (await _dbContext.ProductSize.Where(ps => ps.ProductId == productId).ToListAsync())
                .ToDictionary(ps => ps.Size, ps => ps.Quantity);
        }

        public async Task AddProduct(AddItem request)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                if (request.Sizes.Length != request.Quantities.Length)
                    throw new Exception("Массивы размеров и их количеств не совпадают!");
                var product = await _dbContext.Product.AddAsync(new Product
                {
                    VendorCode = request.VendorCode,
                    Name = request.Name,
                    Price = request.Price,
                    Description = request.Description,
                    Gender = request.Gender,
                    Category = request.Category,
                    Brand = request.Brand,
                    Color = request.Color
                });
                await _dbContext.SaveChangesAsync();
                for (int i = 0; i < request.Sizes.Length; i++)
                {
                    await _dbContext.ProductSize.AddAsync(new ProductSize
                    {
                        ProductId = product.Entity.Id,
                        Size = request.Sizes[i],
                        Quantity = request.Quantities[i]
                    });
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

            await transaction.CommitAsync();
        }
    }
}