using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace PhysicsEngine {
    class Font {
        int handle;
        string fontName;
        int size;
        int thick;
        int fontType;

        public Font(string _fontName, int _size, int _thick, int _fontType) {
            this.fontName = _fontName;
            this.size = _size;
            this.thick = _thick;
            this.fontType = _fontType;

            this.handle = DX.CreateFontToHandle(_fontName, _size, _thick, _fontType);
        }

        ~Font() {
            DX.DeleteFontToHandle(this.Handle);
        }

        public int Handle {
            get {
                return handle;
            }
        }

        public int Size {
            get {
                return size;
            }
            set {
                DX.DeleteFontToHandle(handle);
                this.handle = DX.CreateFontToHandle(fontName, value, Thick, FontType);
            }
        }

        public int Thick {
            get {
                return thick;
            }
            set {
                DX.DeleteFontToHandle(handle);
                this.handle = DX.CreateFontToHandle(fontName, Size, value, FontType);
            }
        }

        public int FontType {
            get {
                return fontType;
            }
            set {
                DX.DeleteFontToHandle(handle);
                this.handle = DX.CreateFontToHandle(fontName, Size, Thick, value);
            }
        }
    }
}
