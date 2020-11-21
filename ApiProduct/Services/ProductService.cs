using System.Collections.Generic;
using ApiProduct.Dto;
using ApiProduct.Dto.Common;

namespace ApiProduct.Services
{
    public class ProductService : IProductService
    {
        public SearchListDto<ProductDto> Search(ProductParamSearchDto param)
        {
            var list = new List<ProductDto>();
            var product = new ProductDto {Productcode = "MIE", Productname = param.Keyword};
            list.Add(product);

            var pageData = new PageData(param.Page, param.Size, 3, 4);
            return new SearchListDto<ProductDto>(list, pageData);
        }
    }
}