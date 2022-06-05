using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
namespace PhysicsEngine {
    class Sprite: Node {
        Image image;

        public Sprite() {}

        public Image Image {
            get {
                return this.image;
            }
            set {
                this.image = value;
            }
        }

        public override void Draw() {
            this.Draw(Position);
        }

        public override void Draw(Vector2 startPosition) {
            if(this.Hidden) {
                return;
            }

            base.Draw(startPosition);

            Vector2 endPosition = startPosition + this.Size;
            DX.DrawExtendGraph((int)startPosition.x, (int)startPosition.y, (int)endPosition.x, (int)endPosition.y, this.Image.Handle, DX.TRUE);
        }
    }
}
