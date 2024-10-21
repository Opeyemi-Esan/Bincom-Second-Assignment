using System.ComponentModel.DataAnnotations;

namespace BincomSecondAssignment.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }

        [Required]
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
