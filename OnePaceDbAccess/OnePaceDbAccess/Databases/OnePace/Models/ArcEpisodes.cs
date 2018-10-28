using System.Collections.Generic;

namespace OnePaceDbAccess.Databases.OnePace.Models
{
    public class ArcEpisodes
    {
        public Arc Arc { get; set; }
        public IEnumerable<Episode> Episodes { get; set; }
    }
}
