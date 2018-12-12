using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace OnePaceDbAccess.Databases.OnePace.Models
{
    [Table("episodes")]
    public class Episode
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("crc32")]
        public string CRC32 { get; set; }
        [Column("arc_id")]
        public int ArcId { get; set; }
        [Column("resolution")]
        public string Resolution { get; set; }
        [Column("chapters")]
        public string Chapters { get; set; }
        [Column("episodes")]
        public string Episodes { get; set; }
        [Column("torrent_hash")]
        public string TorrentHash { get; set; }
        [Column("released_date")]
        public DateTime? ReleasedDate { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("part")]
        public int? Part { get; set; }
        [Column("hidden")]
        public bool Hidden { get; set; }

        public Episode()
        {
            Status = "";
            Title = "";
        }

        public int ResolutionIndex
        {
            get
            {
                if (Resolution == "720p")
                {
                    return 2;
                }
                else if (Resolution == "480p")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public string WordPressTitle
        {
            get
            {
                return GetWordPressTitle(Chapters, Title);
            }
        }
        public string WordpressContent
        {
            get
            {
                return $"<script type=\"text/javascript\">generatePost('{CRC32}', '');</script>";
            }
        }
        public static string GetWordPressTitle(string chapters, string title)
        {
            if (string.IsNullOrWhiteSpace(chapters))
            {
                return title;
            }
            else
            {
                return $"Chapter {chapters}";
            }
        }
        public static string GetName(string arcTitle, string episodeTitle, int? part, string crc32, string chapters, string resolution, bool includeExtension = false)
        {
            string group = "[One Pace]";
            chapters = string.IsNullOrWhiteSpace(chapters) ? "" : "[" + chapters + "]";
            arcTitle = part.HasValue ? arcTitle + " " + part.ToString().PadLeft(2, '0') : episodeTitle;
            string hash = string.IsNullOrWhiteSpace(crc32) ? "" : "[" + crc32 + "]";
            return group + chapters + " " + arcTitle + " [" + resolution + "]" + hash + (includeExtension ? ".mkv" : "");
        }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Chapters) && string.IsNullOrWhiteSpace(Title))
            {
                throw new ValidationException("Either chapters or title must be set.");
            }
            if (string.IsNullOrWhiteSpace(Title) && Part == null)
            {
                throw new ValidationException("Either title or part must be set.");
            }
            if (string.IsNullOrWhiteSpace(Resolution))
            {
                throw new ValidationException("No resolution selected.");
            }
            if (ArcId == 0)
            {
                throw new ValidationException("No arc selected.");
            }
            if (!string.IsNullOrWhiteSpace(CRC32) && !Regex.IsMatch(CRC32, "^[A-f0-9]{8}$"))
            {
                throw new ValidationException("Incorrect CRC32. Must be eight hexadecimal characters (0-9, A-F).");
            }
        }
    }
}