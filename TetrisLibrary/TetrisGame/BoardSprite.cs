using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisLibrary;

namespace TetrisGame
{
    public class BoardSprite : DrawableGameComponent
    {
        private IBoard board;

        private Game game;
        private SpriteBatch spriteBatch;

        private Texture2D emptyBlock;
        private Texture2D filledBlock;


        public BoardSprite(Game game, IBoard board) : base(game)
        {
            this.game = game;
            this.board = board;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            filledBlock = game.Content.Load<Texture2D>("FilledBlock");
            emptyBlock = game.Content.Load<Texture2D>("EmptyBlock");


            base.LoadContent();
        }

        public override void  Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    spriteBatch.Draw(emptyBlock, new Vector2(200+j*20,i*20), Color.DarkGray);
                    if(!board[i,j].Equals(Color.Black))
                        spriteBatch.Draw(filledBlock, new Vector2(200 + j * 20, i * 20), board[i, j]);
                }
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
