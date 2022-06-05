using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DxLibDLL;

namespace PhysicsEngine {
    class Color {
        public int r;
        public int g;
        public int b;
        public int alpha;
        
        public uint colorCode {
            get {
                return DX.GetColor(r, g, b);
            }
        }

        public Color(int _r, int _g, int _b, int _alpha) {
            this.r = _r;
            this.g = _g;
            this.b = _b;
            alpha = _alpha;
        }

        public Color(): this(0, 0, 0, 0) {}

        public Color(int _r, int _g, int _b): this(_r, _g, _b, 255) {}

        //デフォルト色の定義
        public static Color white{
            get {
                return new Color(255, 255, 255);
            }
        }

        public static Color black {
            get {
                return new Color(0, 0, 0);
            }
        }

        public static Color red {
            get {
                return new Color(255, 0, 0);
            }
        }

        public static Color green {
            get {
                return new Color(0, 255, 0);
            }
        }

        public static Color blue {
            get {
                return new Color(0, 0, 255);
            }
        }

        
    }
}
