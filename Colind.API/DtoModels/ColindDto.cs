using System.Collections.Generic;

namespace Colind.API.DtoModels
{
    public class ColindDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; }
        public string? Author { get; set; }
        public IEnumerable<string>? Tags { get; set; }
    }
}
