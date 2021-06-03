using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class SubtypeAppeal
    {
        [Key]
        public long Key { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        
        [ForeignKey("Type")]
        public long TypesId {get;set;}
        public TypeAppeal Type { get; set; }
    }
}