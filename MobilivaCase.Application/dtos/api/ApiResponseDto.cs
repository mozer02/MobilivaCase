using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Application.dtos.api
{
    public enum Status
    {
        Success = 100,
        Failed = 101
    }
    public class ApiResponseDto<TData>
    {
        //Status (Success,Failed enum) , ResultMessage, ErrorCode, Data (GenericType) 
        public int Status { get; set; }
        public string ResultMessage { get; set; }
        public string ErrorCode { get; set; }
        public List<TData> Data { get; set; }       
    }
}
