using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Colind.API.Persistence.Entities
{
    public class AuthorEntity
    {
        [Key]
        [StringLength(50)]
        public string FullName { get; set; } = null!;

        public ICollection<ColindEntity>? Colinds { get; set; }
    }
}
