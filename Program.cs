using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DxLibDLL;

namespace PhysicsEngine {
    static class PhysicsEngine {
        static void Main() {
            DX.ChangeWindowMode(DX.TRUE);
            DX.SetMainWindowText("物理シミュレーション");
            Vector2 windowSize = Engine.windowSize;
            DX.SetGraphMode((int)windowSize.x, (int)windowSize.y, 32);
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.ChangeFontType(DX.DX_FONTTYPE_ANTIALIASING_8X8);

            Engine.scene = new MainScene();

            Time.Init();

            while (DX.ScreenFlip() == 0 && DX.ProcessMessage() == 0 && DX.ClearDrawScreen() == 0) {
                Time.Update();
                Input.Update();
                Engine.Draw();
            }
            DX.DxLib_End();
        }
    }
}