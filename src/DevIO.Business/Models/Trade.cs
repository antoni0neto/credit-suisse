using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public class Trade : Entity
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
    }
}
