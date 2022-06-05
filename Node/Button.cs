/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace PhysicsEngine {
    delegate void ButtonEvent(Button button);

    class Button: Node {
        event ButtonEvent buttonEvent;

        Color highlightColor = UIColor.accentColor;
        Node highlightNode = new Node();
        Label textLabel = new Label();
        Sprite sprite = new Sprite();
        int highlightMargin = 3;

        public Button() : base() {
            this.BackgroundColor = UIColor.themeColor;

            this.HighlightNode.Position = Vector2.one * HighlightMargin;
            this.HighlightNode.Size = Size - (Vector2.one * HighlightMargin) * 2;
            this.HighlightNode.BackgroundColor = highlightColor;
            this.AddChild(highlightNode);

            this.TextLabel.Position = Vector2.zero;
            this.TextLabel.Size = Size;
            this.AddChild(TextLabel);
        }

        public Color HighlightColor {
            get {
                return this.highlightColor;
            }
            set {
                this.highlightColor = value;
                this.highlightNode.BackgroundColor = value;
            }
        }

        public Node HighlightNode {
            get {
                return this.highlightNode;
            }
            set {
                this.highlightNode = value;
            }
        }

        public Label TextLabel {
            get {
                return this.textLabel;
            }
            set {
                this.textLabel = value;
            }
        }

        public int HighlightMargin {
            get {
                return this.highlightMargin;
            }
            set {
                this.highlightMargin = value;
                this.HighlightNode.Position = new Vector2(value, value);
            }
        }

        public override Vector2 Size {
            get {
                return base.Size;
            }
            set {
                base.Size = value;
                this.HighlightNode.Size = Size - (Vector2.one * HighlightMargin) * 2;
                this.TextLabel.Size = value;
            }
        }

        public override void Update() {
            base.Update();
            //マウスが重なっているときハイライトする
            this.HighlightNode.Hidden = !this.ContainsPoint(Input.mousePosition);

            //ボタンが押し上げられたときイベントを実行
            if (ContainsPoint(Input.mousePosition) && Input.GetMouseButtonUp(0)) {
                this.buttonEvent?.Invoke(this);
            }
        }

        public void setEvent(ButtonEvent _buttonEvent) {
            buttonEvent = _buttonEvent;
        }
    }
}