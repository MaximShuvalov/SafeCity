using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Appeal
    {
        [Key]
        public long Key { get; set; }
        
        [ForeignKey("AppealSubtype")]
        public long SubtypeId { get; set; }
        public AppealSubtype AppealSubtype { get; set; }
        
        [ForeignKey("AppealType")]
        public long AppealTypeId { get; set; }
        public AppealType AppealType { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        [ForeignKey("GeoPoint")]
        public long GeoPointId { get; set; }
        public GeoPoint GeoPoint { get; set; }
        public string Attachment { get; set; }
    }
}