using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DxLibDLL;

namespace PhysicsEngine {
    class Node {
        int tag = 0;
        Vector2 position = Vector2.zero;
        Vector2 size = Vector2.zero;
        Color backgroundColor = new Color(0, 0, 0, 0);
        bool hidden = false;

        public List<Node>children = new List<Node>();
        Node parent;
        List<Node> addList = new List<Node>();

        PhysicsBody physicsBody;

        public Node() {}

        public virtual int Tag {
            get {
                return this.tag;
            }
            set {
                this.tag = value;
            }
        }

        public virtual Vector2 Position {
            get {
                return this.position;
            }
            set {
                this.position = value;
            }
        }

        
        public virtual Vector2 Size {
            get {
                return this.size;
            }
            set {
                this.size = value;
            }
        }

        
        public virtual Color BackgroundColor {
            get {
                return this.backgroundColor;
            }
            set {
                this.backgroundColor = value;
            }
        }
        
        public virtual bool Hidden {
            get {
                return this.hidden;
            }
            set {
                this.hidden = value;
            }
        }
        
        public PhysicsBody PhysicsBody {
            set {
                this.physicsBody = value ;
                this.physicsBody.node = this;
            }
            get {
                return this.physicsBody;
            }
        } 

        public virtual void Update() {
            //子ノードのアップデート
            foreach (Node child in this.children) {
                child.Update();
            }
            
            //追加リストに追加されているノードを子ノード化する
            foreach(Node child in this.addList) {
                this.children.Add(child);
            }
            this.addList.Clear();

        }

        public virtual void Draw() {
            this.Draw(Position);
        }

        public virtual void Draw(Vector2 drawPosition) {
            //hiddenがtrueの場合は描画しない
            if(this.Hidden) {
                return;
            }

            Vector2 position2 = drawPosition + this.Size;
            //完全に透明の場合は描画しない
            if (this.BackgroundColor.alpha == 255) {
                //アルファ値が255(完全不透明の場合)
                DX.DrawBox((int)drawPosition.x, (int)drawPosition.y, (int)position2.x, (int)position2.y, this.BackgroundColor.colorCode, DX.TRUE);
            } else if(this.BackgroundColor.alpha != 0) {
                //アルファ値が0より大きく255未満(半透明の場合)
                DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, BackgroundColor.alpha);
                DX.DrawBox((int)drawPosition.x, (int)drawPosition.y, (int)position2.x, (int)position2.y, this.BackgroundColor.colorCode, DX.TRUE);
                DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 0);
            }

            foreach(Node child in this.children) {
                Vector2 originPosition = child.position;
                child.Draw(drawPosition + originPosition);
            }
        }

        public void AddChild(Node child) {
            child.parent = this;
            this.addList.Add(child);
        }

        public bool ContainsPoint(Vector2 point) {
            if(this.Position.x <= point.x && point.x <= this.Position.x + this.Size.x - 1) {
                if(this.Position.y <= point.y && point.y <= this.Position.y + this.Size.y - 1) {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsNode(Node node) {
            Vector2 pos1 = this.Position;
            Vector2 size1 = this.Size;

            Vector2 pos2 = node.Position;
            Vector2 size2 = node.Size;

            if (pos1.x < pos2.x + size2.x && pos2.x < pos1.x + size1.x ) {
                if (pos1.y < pos2.y + size2.y && pos2.y < pos1.y + size1.y) {
                    return true;
                }
            }

            return false;
        }
    }
}
