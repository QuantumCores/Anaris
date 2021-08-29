using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Report
{
    [Serializable]
    public class RFont
    {
        public RFont()
        {
            Color = new RColor();
        }
        public float Size { get; set; }
        public string Face { get; set; }
        public RColor Color { get; set; }
        public int Style { get; set; }
    }
}
