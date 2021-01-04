
using System;
using System.Collections;
using System.Collections.Generic;
using ApiProduct.Dto;
using ApiProduct.Dto.Common;
using ApiProduct.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiProduct.Controllers
{
    
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _iProductService;

        // Dependency Injection in Constructor Class
        public ProductController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }

        [HttpGet("search")]
        public SearchListDto<ProductDto> Search([FromQuery] ProductParamSearchDto param)
        {
            return _iProductService.Search(param);
        }
        
        [HttpPost("add")]
        public FormDto<ProductDto> Add(ProductDto productDto)
        {
            return _iProductService.Add(productDto);
        }
    }
}