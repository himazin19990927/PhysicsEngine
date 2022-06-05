/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using DxLibDLL;

namespace PhysicsEngine {
    class Time {
        public static int time = 0;
        public static int timePrev = 0;
        public static double deltaTime = 0;
        
        public static void Init() {
            time = DX.GetNowCount();
            timePrev = DX.GetNowCount();
        }

        public static void Update() {
            timePrev = time;
            time = DX.GetNowCount();

            deltaTime = (double)(time - timePrev) / 1000f;
        }
    }
}
