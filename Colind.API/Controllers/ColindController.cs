using System.Collections.Generic;
using Colind.API.DtoModels;
using Colind.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Colind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColindController: ControllerBase
    {
        private readonly IColindService colindService;
        private readonly ILogger logger;

        public ColindController(IColindService colindService, ILogger<ColindController> logger)
        {
            this.colindService = colindService;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<ColindDto> GetColinds()
        {
            logger.LogInformation("Getting Colinds list");
            return colindService.GetColinds();
        }
    }
}
