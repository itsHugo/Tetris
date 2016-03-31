using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TetrisLibrary;

namespace TetrisGame
{
    public class ShapeSprite : DrawableGameComponent
    {
        //private IShape shape;
        private IBoard board;
        private Score score;

        private int counterMoveDown;

        private KeyboardState oldState;
        private int counterInput;
        private int threshold;

        private Game game;
        private SpriteBatch spriteBatch;

        private Texture2D filledBlock;

        public ShapeSprite(Game game, IBoard board, Score score)
            : base(game)
        {
            this.game = game;
            this.score = score;
            this.board = board;

        }

        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 20;
            counterMoveDown = 0;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            filledBlock = game.Content.Load<Texture2D>("FilledBlock");
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            
            checkInput();
            counterMoveDown++;
            if(counterMoveDown > ((11 - score.Level) * 3))
            {
                board.Shape.MoveDown();
                counterMoveDown = 0;
            }
            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (int i = 0; i < board.Shape.Length; i++)
            {
                spriteBatch.Draw(filledBlock, new Vector2(200 +board.Shape[i].Position.X*20, board.Shape[i].Position.Y*20), board.Shape[i].Color);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Right))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    board.Shape.MoveRight();
                    counterInput = 0; //reset counter with every new keystroke
                }
                else
                {
                    counterInput++;
                    if (counterInput > threshold)
                        board.Shape.MoveRight();
                }
            }

            if (newState.IsKeyDown(Keys.Left))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    board.Shape.MoveLeft();
                    counterInput = 0; //reset counter with every new keystroke
                }
                else
                {
                    counterInput++;
                    if (counterInput > threshold)
                        board.Shape.MoveLeft();
                }
            }

            if (newState.IsKeyDown(Keys.Down))
            {
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    board.Shape.MoveDown();
                    counterInput = 0;
                }
                else
                {
                    counterInput++;
                    if (counterInput > threshold)
                        board.Shape.MoveDown();
                }
            }

            if (newState.IsKeyDown(Keys.Up))
            {
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    board.Shape.Rotate();
                    counterInput = 0;
                }
                else
                {
                    counterInput++;
                    if (counterInput > threshold)
                        board.Shape.Rotate();
                }
            }

            
            if (newState.IsKeyUp(Keys.Space))
            {
                if(oldState.IsKeyDown(Keys.Space))
                {
                    board.Shape.Drop();
                }
                    
            }
                
            
            oldState = newState;
        }
    }
}
