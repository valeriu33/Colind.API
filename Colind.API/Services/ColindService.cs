using System;
using System.Collections.Generic;
using System.Linq;
using Colind.API.DtoModels;
using Colind.API.Persistence;
using Colind.API.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Colind.API.Services
{
    public class ColindService: IColindService
    {
        private readonly ColindContext db;
        private readonly ColindMapper mapper;
        private readonly ILogger logger;

        public ColindService(ColindContext db, ColindMapper mapper, ILogger<ColindService> logger)
        {
            this.db = db;
            this.mapper = mapper;
            this.logger = logger;
        }

        public IEnumerable<ColindDto> GetColinds()
        {
            var result = new List<ColindDto> { new ColindDto { Title = "test while no db", Text = "test text" } };
            try
            {
                logger.LogInformation("Getting Colinds from database");
                result = db.Colinds.Include(c => c.ColindTags)
                    .Select(c => mapper.ToDto(c)).ToList();
            }
            catch (SqlException e)
            {
                logger.LogError(e, "An ERROR occured while getting colinds from database");
                // TODO: Proper error handling
            }
            return result;//db.Colinds.Include(c => c.ColindTags)
                     //        .Select(c => mapper.ToDto(c));
        }
     }
}
