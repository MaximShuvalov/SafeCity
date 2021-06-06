using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class AppealSubtype
    {
        [Key]
        public long Key { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        
        [ForeignKey("AppealType")]
        public long TypesId {get;set;}
        public AppealType AppealType { get; set; }
    }
}