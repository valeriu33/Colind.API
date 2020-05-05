using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Colind.API.Persistence.Entities
{
    public class ColindEntity
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; } = null!;

        [StringLength(50)]
        public string? AuthorFullName { get; set; }
        public AuthorEntity? Author { get; set; }

        [Required]
        public string Text { get; set; } = null!;


        public virtual ICollection<ColindTagEntity>? ColindTags { get; set; }
    }
}
