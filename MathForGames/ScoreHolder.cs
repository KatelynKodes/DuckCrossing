using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class ScoreHolder : Actor
    {
        private Player _player;
        private UIText _counter;

        public ScoreHolder(float x, float y, string name, string path, Player player, UIText counter) : 
            base(x,y,name,path)
        {
            _player = player;
            _counter = counter;
        }

        /// <summary>
        /// Calls the base Start function and the _counter start functuin
        /// </summary>
        public override void Start()
        {
            base.Start();
            _counter.Start();
        }

        /// <summary>
        /// Updates the number of how many chicks were caught
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            _counter.Text = "Chick's caught: " + _player.CurrChildren.ToString();
        }

        /// <summary>
        /// Draws counter onto the screen
        /// </summary>
        public override void Draw()
        {
            _counter.Draw();
        }
    }
}
