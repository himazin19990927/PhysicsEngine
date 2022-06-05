using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine {
    class MainScene: Scene {
        public MainScene(): base() {
            BackgroundColor = new Color(250, 250, 250);

            PhysicsWorld = new PhysicsWorld();
            PhysicsWorld.Gravity = new Vector2(0, 490);

            //仮置きのボタン
            Button button1 = new Button();
            button1.Tag = 0;
            button1.TextLabel.Text = "自由落下";
            button1.Position = new Vector2(5, 30 - 5);
            button1.Size = new Vector2(150, 30);
            button1.setEvent(buttonClick);
            //UI.AddChild(button1);

            Button button2 = new Button();
            button2.Tag = 1;
            button2.TextLabel.Text = "鉛直投射";
            button2.Position = new Vector2(5, 60 - 5);
            button2.Size = new Vector2(150, 30);
            button2.setEvent(buttonClick);
            //UI.AddChild(button2);

            Button button3 = new Button();
            button3.Tag = 2;
            button3.TextLabel.Text = "水平投射";
            button3.Position = new Vector2(5, 90 - 5);
            button3.Size = new Vector2(150, 30);
            button3.setEvent(buttonClick);
            //UI.AddChild(button3);

            Button button4 = new Button();
            button4.Tag = 3;
            button4.TextLabel.Text = "斜方投射";
            button4.Position = new Vector2(5, 120 - 5);
            button4.Size = new Vector2(150, 30);
            button4.setEvent(buttonClick);
            //UI.AddChild(button4);
            
            //床
            Box floor = new Box();
            floor.Size = new Vector2(800, 60);
            floor.Position = new Vector2(0, 540);
            floor.BackgroundColor = UIColor.redBoxColor;
            floor.BorderColor = UIColor.redBorderColor;
            floor.PhysicsBody = new PhysicsBody();
            floor.PhysicsBody.Dynamic = false;
            Layer.AddChild(floor);
        }

        void buttonClick(Button button) {
            Box node = new Box();
            node.Size = Vector2.one * 60;
            node.BackgroundColor = UIColor.blueBoxColor;
            node.BorderColor = UIColor.blueBorderColor;
            node.PhysicsBody = new PhysicsBody();
            node.PhysicsBody.AffectedByGravity = true;
            switch(button.Tag) {
                case 0:
                    //自由落下
                    node.Position = new Vector2(400 - 15, 30);
                    break;
                case 1:
                    //鉛直投射
                    node.Position = new Vector2(400 - 15, 400);
                    node.PhysicsBody.AddForce(new Vector2(0, -450));
                    break;
                case 2:
                    //水平投射
                    node.Position = new Vector2(150, 100);
                    node.PhysicsBody.AddForce(new Vector2(300, 0));
                    break;
                case 3:
                    //斜方投射
                    node.Position = new Vector2(20, 400);
                    node.PhysicsBody.AddForce(new Vector2(300, -350));
                    break;
            }
            Layer.AddChild(node);
        }

        public override void Update() {
            base.Update();

            if (Input.GetMouseButtonDown(0)) {
                Vector2 position = Input.mousePosition;
                Box node = new Box();
                node.Size = Vector2.one * 50;
                node.BackgroundColor = UIColor.greenBoxColor;
                node.BorderColor = UIColor.greenBorderColor;
                node.PhysicsBody = new PhysicsBody();
                node.PhysicsBody.AffectedByGravity = true;
                node.Position = position - Vector2.one * 25;
                node.PhysicsBody.AddForce(new Vector2(300, -300));
                Layer.AddChild(node);
            }

            if (Input.GetMouseButtonDown(1)) {
                Vector2 position = Input.mousePosition;
                Box node = new Box();
                node.Size = Vector2.one * 50;
                node.BackgroundColor = UIColor.blueBoxColor;
                node.BorderColor = UIColor.blueBorderColor;
                node.PhysicsBody = new PhysicsBody();
                node.PhysicsBody.AffectedByGravity = true;
                node.Position = position - Vector2.one * 25;
                Layer.AddChild(node);
            }
        }
    }
}


