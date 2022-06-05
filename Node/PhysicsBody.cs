using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine {
    class PhysicsBody {
        public Node node = new Node();
        Vector2 velocity = Vector2.zero;

        bool affectedByGravity = false;
        bool dynamic = true;

        public PhysicsBody() {}

        public Vector2 Velocity {
            get {
                return this.velocity;
            }
            set {
                this.velocity = value;
            }
        }

        public bool AffectedByGravity {
            get {
                return this.affectedByGravity;
            }
            set {
                this.affectedByGravity = value;
            }
        }

        public bool Dynamic {
            get {
                return this.dynamic;
            }
            set {
                this.dynamic = value;
            }
        }

        public void AddForce(Vector2 force) {
            this.Velocity += force;
        }
    }
}
