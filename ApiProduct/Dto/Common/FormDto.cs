using System;

namespace ApiProduct.Dto.Common
{
    public class FormDto<T>
    {
        public bool Success { get; set; }
        
        public T Data { get; set; }
        
        public ErrorMessage Errormessage { get; set; }
        
        public FormDto()
        {
        }
        
        public FormDto(T data)
        {
            Data = data;
            Success = true;
        }
        
        public FormDto(string errorcode, string errordescription, T data)
        {
            Data = data;
            Success = false;
            Errormessage = new ErrorMessage {errorcode = errorcode, errordescription = errordescription};
        }
    }
    
    
}