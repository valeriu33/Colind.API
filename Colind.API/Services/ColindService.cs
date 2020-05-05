using System;
using System.Collections.Generic;
using System.Linq;
using Colind.API.DtoModels;
using Colind.API.Persistence;
using Colind.API.Mappers;
using Microsoft.EntityFrameworkCore;

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
            return db.Colinds.Include(c => c.ColindTags)
                             .Select(c => mapper.ToDto(c));
        }
     }
}
