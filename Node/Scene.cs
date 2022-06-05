using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine {
    class Scene: Node {
        public Node Layer = new Node();
        public Node UI = new Node();
        PhysicsWorld physicsWorld;

        public Scene() : base() {
            this.Layer.Position = Vector2.zero;
            this.Layer.Size = Engine.windowSize;
            this.AddChild(Layer);

            this.UI.Position = Vector2.zero ;
            this.UI.Size = Engine.windowSize;
            this.AddChild(UI);

            this.Position = Vector2.zero;
            this.Size = Engine.windowSize;
        }

        public override Vector2 Size {
            get {
                return base.Size;
            }
            set {
                base.Size = value;
                this.UI.Size = value;
            }
        }

        public PhysicsWorld PhysicsWorld {
            set {
                this.physicsWorld = value;
                this.physicsWorld.node = Layer;
            }
            get {
                return this.physicsWorld;
            }
        }

        public override void Update() {
            base.Update();
            if (this.physicsWorld != null) {
                this.physicsWorld.Update();
            }
        }
    }
}
