using OnePaceDbAccess.Databases.OnePace.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnePaceDbAccess.Databases.OnePace
{
    public class OnePaceDataContext : DbContext
    {
        public DbSet<Saga> Sagas { get; set; }
        public DbSet<Arc> Arcs { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public OnePaceDataContext()
        {

        }

        public IQueryable<ArcEpisodes> FetchArcsWithEpisodes()
        {
            var list = new List<Arc>();
            var parents = Arcs.ToList();
            var children = Episodes.ToList();

            return parents.GroupJoin(
                children,
                p => p.Id,
                c => c.ArcId,
                (arc, episodes) => new ArcEpisodes { Arc = arc, Episodes = episodes }
            ).AsQueryable();
        }
    }
}
