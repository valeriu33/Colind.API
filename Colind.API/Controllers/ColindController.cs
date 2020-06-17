using System.Collections.Generic;
using Colind.API.DtoModels;
using Colind.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Colind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColindController: ControllerBase
    {
        private readonly IColindService colindService;

        public ColindController(IColindService colindService)
        {
            this.colindService = colindService;
        }

        [HttpGet]
        public IEnumerable<ColindDto> GetCollinds()
        {
            return colindService.GetColinds();
        }
    }
}
