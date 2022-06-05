using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace PhysicsEngine {
    class Label: Node {
        string text = "";
        Color textColor = UIColor.textColor;
        Font font = UIFont.FontOfSize16;
        TextAlignmentType textAlignment = TextAlignmentType.Center;

        public Label(): base() {}
        
        public string Text {
            get {
                return this.text;
            }
            set {
                this.text = value;
            }
        }
        
        public Color TextColor {
            get {
                return this.textColor;
            }
            set {
                this.textColor = value;
            }
        }
        
        public Font Font {
            get {
                return this.font;
            }
            set {
                this.font = value;
            }
        }
        
        public TextAlignmentType TextAlignment {
            get {
                return this.textAlignment;
            }
            set {
                this.textAlignment = value;
            }
        }

        public override void Update() {
            base.Update();
        }

        public override void Draw() {
            Draw(Position);
        }

        public override void Draw(Vector2 drawPosition) {
            if(Hidden) {
                return;
            }
            base.Draw(drawPosition);

            //テキストの描画
            int textWidth = DX.GetDrawStringWidthToHandle(this.Text, this.Text.Length, this.Font.Handle);
            Vector2 textDrawPosition = new Vector2(0, (drawPosition.y + this.Size.y / 2) - this.Font.Size / 2);
            switch(TextAlignment) {
                case TextAlignmentType.Left:
                    textDrawPosition.x = drawPosition.x;
                    break;
                case TextAlignmentType.Right:
                    textDrawPosition.x = (drawPosition.x + this.Size.x) - textWidth;
                    break;
                case TextAlignmentType.Center:
                    textDrawPosition.x = (drawPosition.x + this.Size.x / 2) - textWidth / 2;
                    break;
                default:
                    textDrawPosition.x = (drawPosition.x + this.Size.x / 2) - textWidth / 2;
                    break;
            }

            //完全に透明の場合は描画しない
            if (this.textColor.alpha == 255) {
                //アルファ値が255(完全不透明の場合)
                DX.DrawStringToHandle((int)textDrawPosition.x, (int)textDrawPosition.y, this.Text, this.TextColor.colorCode, this.Font.Handle);
            } else if (textColor.alpha != 0) {
                //アルファ値が0より大きく255未満(半透明の場合)
                DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, this.textColor.alpha);
                DX.DrawStringToHandle((int)textDrawPosition.x, (int)textDrawPosition.y, this.Text, this.TextColor.colorCode, this.Font.Handle);
                DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 0);
            }
            
        }
    }
}
