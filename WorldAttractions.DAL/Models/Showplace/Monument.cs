using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldAttractions.DAL.Models.Showplace
{
    public class Monument//это наш памятник архитуектуры.
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("City")]
        public int? IdCity { get; set; }
        public virtual City City { get; set; }
        public virtual IList<Picture> Pictures { get; set; }
    }
}
