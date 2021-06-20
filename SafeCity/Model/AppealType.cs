using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class AppealType
    {
        [Key]
        public long Key { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }
}