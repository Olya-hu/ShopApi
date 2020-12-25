﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Services.Catalog;
using Services.Catalog.Requests;

namespace ShopApi.Controllers
{
    [Route("catalog")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly ICatalog _catalog;

        public CatalogController(ICatalog catalog)
        {
            _catalog = catalog;
        }

        [HttpGet]
        public async Task<List<Product>> Index([FromQuery] CatalogFilters filters)
        {
            return await _catalog.GetWithFilters(filters);
        }

        [HttpGet]
        [Route("{productId:int}/sizes")]
        public async Task<Dictionary<string, short>> GetSizesFor(int productId)
        {
            return await _catalog.GetSizesFor(productId);
        }

        [HttpPost]
        [Route("addItem")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> AddItem([FromForm] AddItem request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                await _catalog.AddProduct(request);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }

            return new EmptyResult();
        }
    }
}
