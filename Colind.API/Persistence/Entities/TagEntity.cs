using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Colind.API.Persistence.Entities
{
    public class TagEntity
    {
        [Key]
        [StringLength(40)]
        public string Name { get; set; } = null!;

        public virtual ICollection<ColindTagEntity>? ColindTags { get; set; }
    }
}
