using System;
using System.Collections.Generic;
using System.Linq;
using Colind.API.DtoModels;
using Colind.API.Persistence;
using Colind.API.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Colind.API.Services
{
    public class ColindService: IColindService
    {
        private readonly ColindContext db;
        private readonly ColindMapper mapper;

        public ColindService(ColindContext db, ColindMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IEnumerable<ColindDto> GetColinds()
        {
            var result = new List<ColindDto> { new ColindDto { Title = "test while no db", Text = "test text" } };
            try
            {
                result = db.Colinds.Include(c => c.ColindTags)
                    .Select(c => mapper.ToDto(c)).ToList();
            }
            catch (SqlException e)
            {
                // TODO: Proper error handling
            }
            return result;//db.Colinds.Include(c => c.ColindTags)
                     //        .Select(c => mapper.ToDto(c));
        }
     }
}
