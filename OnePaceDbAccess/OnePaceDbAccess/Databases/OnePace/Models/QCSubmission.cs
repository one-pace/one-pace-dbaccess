using OnePaceDbAccess.Databases.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePaceDbAccess.Databases.OnePace.Models
{
    [Table("qc_submissions")]
    public class QCSubmission
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("episode_id")]
        public int EpisodeId { get; set; }
        [Column("status")]
        public QCStatus Status { get; set; }
        [Column("link")]
        public string Link { get; set; }
        [Column("created_date")]
        public long CreatedDate { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("version")]
        public string Version { get; set; }
    }
}
