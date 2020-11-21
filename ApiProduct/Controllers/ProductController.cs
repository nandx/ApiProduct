
using System;
using System.Collections;
using System.Collections.Generic;
using ApiProduct.Dto;
using ApiProduct.Dto.Common;
using ApiProduct.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduct.Controllers
{
    
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _iProductService;

        public ProductController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }

        // GET
        [HttpGet("search")]
        public SearchListDto<ProductDto> Search()
        {
            return _iProductService.search();
        }
    }
}