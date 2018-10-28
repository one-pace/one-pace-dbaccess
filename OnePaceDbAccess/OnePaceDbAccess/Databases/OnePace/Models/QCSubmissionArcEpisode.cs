namespace OnePaceDbAccess.Databases.OnePace.Models
{
    public class QCSubmissionArcEpisode
    {
        public QCSubmission QCSubmission { get; set; }
        public Episode Episode { get; set; }
        public Arc Arc { get; set; }
    }
}
