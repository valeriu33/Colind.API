using System.Collections.Generic;

namespace Colind.API.DtoModels
{
    public class ColindDto
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Author { get; set; }
        public IEnumerable<string>? Tags { get; set; }
    }
}
