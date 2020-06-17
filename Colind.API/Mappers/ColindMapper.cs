using System;
using System.Collections.Generic;
using Colind.API.DtoModels;
using Colind.API.Persistence.Entities;

namespace Colind.API.Mappers
{
    public class ColindMapper
    {
        public ColindDto ToDto(ColindEntity colindEntity)
        {
            List<string>? tags = null;
            if (colindEntity.ColindTags != null)
            {
                tags = new List<string>();
                foreach (var colindTags in colindEntity.ColindTags)
                {
                    tags.Add(colindTags.TagName);
                }
            }
            return new ColindDto
            {
                Id = colindEntity.Id,
                Title = colindEntity.Title,
                Text = colindEntity.Text,
                Tags = tags,
                Author = colindEntity.AuthorFullName
            };
        }
    }
}
