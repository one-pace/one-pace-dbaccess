// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePaceDbAccess.Databases.OnePace.Models
{
    [Table("arcs")]
    public class Arc
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("chapters")]
        public string Chapters { get; set; }
        [Column("episodes")]
        public string Episodes { get; set; }
        [Column("torrent_hash")]
        public string TorrentHash { get; set; }
        [Column("resolution")]
        public string Resolution { get; set; }
        [Column("released")]
        public bool Released { get; set; }

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
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                throw new ValidationException("Title must be set.");
            }
        }
        public string WordpressContent
        {
            get
            {
                return $"<script type=\"text/javascript\">generatePost('{TorrentHash}', '');</script>";
            }
        }

        public static string GetName(string chapters, string title, string resolution)
        {
            return "[One Pace]" + (string.IsNullOrWhiteSpace(chapters) ? "" : "[" + chapters + "]") + " " + title + " [" + resolution + "]";
        }
    }
}