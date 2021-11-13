using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class ScoreHolder : Actor
    {
        private Player _player;
        private UIText _counter;

        public ScoreHolder(int x, int y, string name, string path, Player player, UIText counter) : 
            base(x,y,name,path)
        {
            _player = player;
            _counter = counter;
        }

        public override void Start()
        {
            base.Start();
            _counter.Start();
        }

        public override void Update(float deltaTime)
        {
            _counter.Text = "Chick's caught: " + _player.CurrChildren.ToString();
        }

        public override void Draw()
        {
            _counter.Draw();
        }
    }
}
