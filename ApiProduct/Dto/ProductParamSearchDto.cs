namespace ApiProduct.Dto
{
    public class ProductParamSearchDto
    {
        public string Keyword { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}