/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using DxLibDLL;

namespace PhysicsEngine {
    class Input {
        public static Vector2 mousePosition = Vector2.zero;
        static Vector2 prevMousePosition = Vector2.zero;

        static int mouseInput;
        static int prevMouseInput;
        public static void Init() {
            int x;
            int y;
            DX.GetMousePoint(out x, out y);
            mousePosition = new Vector2(x, y);
            prevMousePosition = new Vector2(x, y);

            mouseInput = DX.GetMouseInput();
            prevMouseInput = DX.GetMouseInput();
        }

        public static void Update() {
            prevMousePosition = mousePosition;
            int x;
            int y;
            DX.GetMousePoint(out x, out y);
            mousePosition = new Vector2(x, y);

            prevMouseInput = mouseInput;
            mouseInput = DX.GetMouseInput();
        }

        public static bool GetMouseButton(int button) {
            int buttonCode;
            switch(button) {
                case 0:
                    buttonCode = DX.MOUSE_INPUT_LEFT;
                    break;
                case 1:
                    buttonCode = DX.MOUSE_INPUT_RIGHT;
                    break;
                case 2:
                    buttonCode = DX.MOUSE_INPUT_MIDDLE;
                    break;
                default:
                    return false;
            }

            if ((mouseInput & buttonCode) != 0) {
                return true;
            }

            return false;
        }

        public static bool GetMouseButtonDown(int button) {
            int buttonCode;
            switch (button) {
                case 0:
                    buttonCode = DX.MOUSE_INPUT_LEFT;
                    break;
                case 1:
                    buttonCode = DX.MOUSE_INPUT_RIGHT;
                    break;
                case 2:
                    buttonCode = DX.MOUSE_INPUT_MIDDLE;
                    break;
                default:
                    return false;
            }

            if ((mouseInput & buttonCode) != 0 && (prevMouseInput & buttonCode) == 0) {
                return true;
            }

            return false;
        }

        public static bool GetMouseButtonUp(int button) {
            int buttonCode;
            switch (button) {
                case 0:
                    buttonCode = DX.MOUSE_INPUT_LEFT;
                    break;
                case 1:
                    buttonCode = DX.MOUSE_INPUT_RIGHT;
                    break;
                case 2:
                    buttonCode = DX.MOUSE_INPUT_MIDDLE;
                    break;
                default:
                    return false;
            }

            if ((mouseInput & buttonCode) == 0 && (prevMouseInput & buttonCode) != 0) {
                return true;
            }

            return false;
        }
    }
}
