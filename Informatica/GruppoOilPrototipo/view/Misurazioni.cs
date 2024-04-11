using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppoOilPrototipo.view
{
    public class Misurazioni
    {
        public Misurazioni()
        {
            misurazioni = new List<string>();
        }
        List<string> misurazioni { get; set; }
        public void Agg_mis(string mis)
        {
            misurazioni.Add(mis); 
        }
    }
}
