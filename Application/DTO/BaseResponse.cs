using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Application.DTO
{
    public class BaseResponse : IBaseResponse
    {
        public bool Success { get; set; } = true;

        [JsonProperty]
        public List<string> Errors { get; set; }

        public BaseResponse CreateFailResponse()
        {
            return new BaseResponse { Success = false, Errors = this.Errors };
        }
    }

    public interface IBaseResponse
    {
        bool Success { get; set; }
        List<string> Errors { get; set; }
        BaseResponse CreateFailResponse();
    }
}