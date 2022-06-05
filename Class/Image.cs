using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace PhysicsEngine {
    class Image {
        int handle;
        Vector2 size;

        public Image(string fileName) {
            handle = DX.LoadGraph(fileName);

            Console.WriteLine("Handle: "  + handle.ToString());

            int sizeX;
            int sizeY;
            DX.GetGraphSize(this.Handle, out sizeX, out sizeY);
            this.size = new Vector2(sizeX, sizeY);
        }

        ~Image() {
            DX.DeleteGraph(this.Handle);
        }

        public int Handle {
            get {
                return this.handle;
            }
        }

        public Vector2 Size {
            get {
                return this.size;
            }
        }
    }
}
