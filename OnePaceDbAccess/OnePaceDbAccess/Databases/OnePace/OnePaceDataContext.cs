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
        public DbSet<QCSubmission> QCSubmissions { get; set; }

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

        public IQueryable<QCSubmissionArcEpisode> FetchQCSubmissions()
        {
            return (
                from qcSubmission in QCSubmissions
                join episode in Episodes on qcSubmission.EpisodeId equals episode.Id
                join arc in Arcs on episode.ArcId equals arc.Id into arc_j
                from arc in arc_j.DefaultIfEmpty()
                select new QCSubmissionArcEpisode { QCSubmission = qcSubmission, Episode = episode, Arc = arc }
            ).AsQueryable();
        }
    }
}
