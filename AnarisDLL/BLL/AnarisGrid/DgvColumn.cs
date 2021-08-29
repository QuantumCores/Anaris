using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.AnarisGrid
{
    [Serializable]
    public class DgvColumn
    {
        public string name { get; set; }
        public string headerText { get; set; }
        public int index { get; set; }
        public string type { get; set; }
        public bool visible { get; set; }
        private int _width { get; set; }
        public int width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public bool sortable { get; set; }
        public string cellStyle { get; set; }
        public string valueType { get; set; } //?
        public string valueFormat { get; set; }
        public bool isDBcol { get; set; }
        public bool isARcol { get; set; }


        internal void Clone(DgvColumn column)
        {
            name = column.name;
            headerText = column.headerText;
            index = column.index;
            type = column.type;
            visible = column.visible;
            width = column.width;
            sortable = column.sortable;
            cellStyle = column.cellStyle;
            valueType = column.valueType;
            valueFormat = column.valueFormat;
            isDBcol = column.isDBcol;
            isARcol = column.isARcol;
        }
    }

}
