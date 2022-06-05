using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace PhysicsEngine {
    class Engine {
        public static Scene scene;

        public Engine() {
            scene = new Scene();
        }

        public static void Draw() {
            scene.Update();
            scene.Draw();
        }

        public static Vector2 windowSize {
            get {
                return new Vector2(800, 600);
            }
        }
    }
}
