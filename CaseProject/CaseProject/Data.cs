using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject
{
    class Data
    {
    }
}

public class Rootobject
{
    public Valutakurser[] valutaKurser { get; set; }
    public DateTime updatedAt { get; set; }
}

public class Valutakurser
{
    public string fromCurrency { get; set; }
    public string toCurrency { get; set; }
    public float rate { get; set; }
}
