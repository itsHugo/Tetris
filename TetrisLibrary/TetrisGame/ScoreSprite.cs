using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisLibrary;

namespace TetrisGame
{
    public class ScoreSprite : DrawableGameComponent
    {
        private Score score;

        private Game game;
        private SpriteBatch spriteBatch;

        private SpriteFont font;

        public ScoreSprite(Game game, Score score) : base(game)
        {
            this.game = game;
            this.score = score;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("scoreFont");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Score: " + score.Points, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(font, "Level: " + score.Level, new Vector2(0, 20), Color.White);
            spriteBatch.DrawString(font, "Lines cleared: " + score.Lines, new Vector2(0, 40), Color.White);
            spriteBatch.DrawString(font, "Time: " + gameTime.TotalGameTime.Minutes
                + ":" + gameTime.TotalGameTime.Seconds 
                + ":" + gameTime.TotalGameTime.Milliseconds,
                new Vector2(0, 60), Color.White);
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
