using System.Collections.Generic;
using Colind.API.DtoModels;

namespace Colind.API.Services
{
    public interface IColindService
    {
        IEnumerable<ColindDto> GetColinds();
    }
}
