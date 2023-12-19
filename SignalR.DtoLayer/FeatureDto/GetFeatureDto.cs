using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.FeatureDto
{
    public class GetFeatureDto
    {
        public int FeatureID { get; set; }
        public int Title1 { get; set; }
        public int Description1 { get; set; }
        public int Title2 { get; set; }
        public int Description2 { get; set; }
        public int Title3 { get; set; }
        public int Description3 { get; set; }
    }
}
