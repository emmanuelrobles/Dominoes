using System.Collections.Generic;
using System.Linq;

namespace Dominoes.Core
{
    public class Jornada
    {
        public uint Id { get; init; }
        
        public IEnumerable<Player> Players { get; init; } = Enumerable.Empty<Player>();
    }
}