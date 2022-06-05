using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine {
    class PhysicsWorld {
        public Node node = new Node();

        Vector2 gravity = Vector2.zero;

        bool useUpdate = true; 

        public PhysicsWorld() {}

        public Vector2 Gravity {
            get {
                return this.gravity;
            }
            set {
                this.gravity = value;
            }
        }

        public bool UseUpdate {
            get {
                return this.useUpdate;
            }
            set {
                this.useUpdate = value;
            }
        }

        public void Update() {
            if (!this.UseUpdate) {
                return;
            }

            foreach(Node child in this.node.children) {
                PhysicsBody physicsBody = child.PhysicsBody;
                if(physicsBody == null) {
                    continue;
                }

                //重力の影響を受けるノードの場合、重力を与える
                if (physicsBody.AffectedByGravity) {
                    physicsBody.AddForce(Gravity * Time.deltaTime);
                }



                //接触しているノードを検索する
                foreach (Node another in this.node.children) {
                    if (another == child || another.PhysicsBody == null) {
                        //同じノードの場合、またはPhysicsBodyを持っていない場合スキップ
                        continue;
                    }

                    if (child.ContainsNode(another)) {
                        //接触していた場合
                        physicsBody.Velocity.y = -0.9 * physicsBody.Velocity.y;
                        Console.WriteLine("衝突しました");
                    }
                }


                //座標と座標を更新
                if (physicsBody.Dynamic) {
                    child.Position += child.PhysicsBody.Velocity * Time.deltaTime;
                }
                
            }
        }
    }
}
