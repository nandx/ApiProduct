using ApiProduct.Dto;
using ApiProduct.Dto.Common;

namespace ApiProduct.Services
{
    public interface IProductService
    {
        public SearchListDto<ProductDto> Search(ProductParamSearchDto param);
    }
}