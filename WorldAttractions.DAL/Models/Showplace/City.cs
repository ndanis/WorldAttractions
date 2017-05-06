using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldAttractions.DAL.Models.Showplace
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Monument> Monuments { get; set; }
        public int? DistrictId { get; set; }
        public virtual District District { get; set; }

    }
}
