using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsISeaYouAt.Models
{
    public class Zoekertje
    {
        public int Id { get; set; }
        public String Titel { get; set; }
        public int AanbiederID { get; set; }
        public virtual ApplicationUser Aanbieder { get; set; }
        public FunctieTitel FunctieTitel { get; set; }
        public DateTime Datum { get; set; }
        public String Beschrijving { get; set; }
    }
}