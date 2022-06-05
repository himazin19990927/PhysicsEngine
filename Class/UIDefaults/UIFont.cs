using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace PhysicsEngine {
    class UIFont {
        static Font fontOfSize16 = new Font("メイリオ", 16, 3, DX.DX_FONTTYPE_ANTIALIASING_8X8);
        public static Font FontOfSize16 {
            get {
                return fontOfSize16;
            }
        }

        static Font fontOfSize24 = new Font("メイリオ", 24, 3, DX.DX_FONTTYPE_ANTIALIASING_8X8);
        public static Font FontOfSize24 {
            get {
                return fontOfSize24;
            }
        }
    }
}
