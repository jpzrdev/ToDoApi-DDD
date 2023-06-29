using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult CreateResponse(IBaseResponse result)
        {
            if (result.Errors is not null && result.Errors.Any())
            {
                return BadRequest(result.CreateFailResponse());
            }

            return Ok(result);
        }
    }
}