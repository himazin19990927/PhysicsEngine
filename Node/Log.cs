/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace PhysicsEngine
{
    class Log: Node {
        int rowHeight = 10;

        public int RowHeight {
            get {
                return rowHeight;
            }
            set {
                this.rowHeight = value;
            }
        }

        public Log(): base() {
            this.BackgroundColor = UIColor.themeColor;
        }
    }
}
