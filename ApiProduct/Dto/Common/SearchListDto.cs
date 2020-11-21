using System.Collections.Generic;

namespace ApiProduct.Dto.Common
{
    public class SearchListDto<T>
    {
        public List<T> Data { get; set; }

        public bool Success { get; set; }

        public PageData Pagedata { get; set; }

        public SearchListDto()
        {
        }
        
        public SearchListDto(List<T> list)
        {
            Data = list;
            Success = true;
        }
        
        public SearchListDto(List<T> list, PageData pagedata)
        {
            Data = list;
            Pagedata = pagedata;
            Success = true;
        }
    }

    public class PageData
    {
        public int Currentpage { get; set; }
        public int Pagesize { get; set; }
        public int Totalpage { get; set; }
        public int Totaldata { get; set; }
        
        public PageData()
        {
            
        }

        public PageData(int currentpage, int pagesize, int totalpage, int totaldata)
        {
            Currentpage = currentpage;
            Pagesize = pagesize;
            Totalpage = totalpage;
            Totaldata = totaldata;
        }

       
    }
}