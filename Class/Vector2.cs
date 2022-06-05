using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine {
    class Vector2 {
        public double x;
        public double y;

        public Vector2(double _x, double _y) {
            this.x = _x;
            this.y = _y;
        }

        //演算子の定義
        public static Vector2 operator +(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2) {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2 operator *(Vector2 v, double n) {
            return new Vector2(v.x * n, v.y * n);
        }

        public static Vector2 operator /(Vector2 v, double n) {
            return new Vector2(v.x / n, v.y / n);
        }

        //メソッド
        public override string ToString() {
            return "(x: " + this.x.ToString() + ", y: " + this.x + ")";
        }

        //getterプロパティ
        public static Vector2 zero {
            get {
                return new Vector2(0, 0);
            }
        }

        public static Vector2 one {
            get {
                return new Vector2(1, 1);
            }
        }

        public static Vector2 up {
            get {
                return new Vector2(0, 1);
            }
        }

        public static Vector2 down {
            get {
                return new Vector2(0, -1);
            }
        }

        public static Vector2 left {
            get {
                return new Vector2(-1, 0);
            }
        }

        public static Vector2 right {
            get {
                return new Vector2(1, 0);
            }
        }
    }
}
