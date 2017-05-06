using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldAttractions.DAL.Models.Showplace
{
    public class Picture
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? MonumentID { get; set; }
        public virtual Monument Monument { get; set; }
        public Picture()
        { }
        public Picture(string Path, Monument Monument)
        {
            this.Path = Path;
            this.Monument = Monument;
            MonumentID = Monument.Id;
        }
    }
}
