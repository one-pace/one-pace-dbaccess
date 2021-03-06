﻿using System.ComponentModel.DataAnnotations;
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
        [Column("link")]
        public string Link { get; set; }
        [Column("ftp_path")]
        public string FTPPath { get; set; }
        [Column("created_date")]
        public long CreatedDate { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; }
    }
}
