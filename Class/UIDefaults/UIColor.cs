using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine {
    class UIColor {
        public static Color themeColor {
            get {
                return new Color(55, 55, 69, 240);
            }
        }

        public static Color accentColor {
            get {
                return new Color(37, 87, 131, 240);
            }
        }

        public static Color textColor {
            get {
                return new Color(245, 245, 245);
            }
        }

        public static Color clearColor {
            get {
                return new Color(0, 0, 0, 0);
            }
        }

        public static Color whiteBoxColor {
            get {
                return new Color(182, 182, 182, 200);
            }
        }

        public static Color whiteBorderColor {
            get {
                return new Color(182, 182, 182);
            }
        }

        public static Color greenBoxColor {
            get {
                return new Color(225, 125, 225, 100);
            }
        }

        public static Color greenBorderColor {
            get {
                return new Color(1225, 125, 225);
            }
        }

        public static Color redBoxColor {
            get {
                return new Color(225, 125, 125, 120);
            }
        }

        public static Color redBorderColor {
            get {
                return new Color(225, 125, 125);
            }
        }

        public static Color blueBoxColor {
            get {
                return new Color(125, 125, 225, 100);
            }
        }

        public static Color blueBorderColor {
            get {
                return new Color(125, 125, 225);
            }
        }
    }
}
