/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using DxLibDLL;
namespace PhysicsEngine {
    class Box: Node {
        Color borderColor = UIColor.clearColor;
        int borderWidth = 1;

        
        public Box() : base() {}

        public Color BorderColor {
            get {
                return this.borderColor;
            }
            set {
                this.borderColor = value;
            }
        }

        public int BorderWidth {
            get {
                return this.borderWidth;
            }
            set {
                this.borderWidth = value;
            }
        }

        public override void Draw() {
            base.Draw();
        }

        public override void Draw(Vector2 drawPosition) {
            if (this.Hidden) {
                return;
            }
            base.Draw(drawPosition);

            //枠線の描画
            if (BorderWidth > 0) {
                Vector2 position2 = drawPosition + this.Size;
                //完全に透明の場合は描画しない
                if (this.BorderColor.alpha == 255) {
                    //アルファ値が255(完全不透明の場合)
                    DX.DrawBox((int)drawPosition.x, (int)drawPosition.y, (int)position2.x, (int)position2.y, this.BorderColor.colorCode, DX.FALSE);
                } else if (this.BorderColor.alpha != 0) {
                    //アルファ値が0より大きく255未満(半透明の場合)
                    DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, BackgroundColor.alpha);
                    DX.DrawBox((int)drawPosition.x, (int)drawPosition.y, (int)position2.x, (int)position2.y, this.BorderColor.colorCode, DX.FALSE);
                    DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 0);
                }
            }
        }

    }
}
