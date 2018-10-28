using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePaceDbAccess.Databases.OnePace.Models
{
    [Table("sagas")]
    public class Saga
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
        public Saga Validate()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                throw new ValidationException("Title must be set.");
            }
            return this;
        }
    }
}