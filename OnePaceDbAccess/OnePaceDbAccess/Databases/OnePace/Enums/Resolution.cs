using System.ComponentModel;

namespace OnePaceDbAccess.Databases.OnePace.Enums
{
    public enum Resolution
    {
        [Description("480p")]
        SD = 1,
        [Description("720p")]
        HD = 2,
        [Description("1080p")]
        FHD = 3
    }
}
