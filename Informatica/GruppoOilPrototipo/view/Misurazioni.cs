using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppoOilPrototipo.view
{
    public class Misurazioni
    {
        List<string> misurazioni { get; set; }
        public void Agg_mis(string mis)
        {
            misurazioni.Add(mis); 
        }
    }
}
