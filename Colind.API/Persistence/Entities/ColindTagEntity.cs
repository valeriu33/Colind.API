using System;
using System.ComponentModel.DataAnnotations;

namespace Colind.API.Persistence.Entities
{
    public class ColindTagEntity
    {
        public int ColindId { get; set; }
        public ColindEntity Colind { get; set; } = null!;

        [StringLength(40)]
        public string TagName { get; set; } = null!;
        public TagEntity Tag { get; set; } = null!;
    }
}
