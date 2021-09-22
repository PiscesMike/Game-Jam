using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Template
{
    class StateManagerII
    {
        RenderingObjects RenderingObjects;

        LevelOne LevelOne;
        LevelTwo LevelTwo;
        LevelThree LevelThree;
        BossOne BossOne;
        LevelTransition Transition;

        int CurrentLevel = 1;
        iGameState CurrentState;                                                                                                        // Create an iGameState instance to reference the current game state

        public StateManagerII(GraphicsDeviceManager graphics, ContentManager content, SpriteBatch spriteBatch)
        {
            RenderingObjects.Graphics = graphics;
            RenderingObjects.Content = content;
            RenderingObjects.SpriteBatch = spriteBatch;

            LevelOne = new LevelOne(RenderingObjects);
            LevelTwo = new LevelTwo(RenderingObjects);
            LevelThree = new LevelThree(RenderingObjects);
            BossOne = new BossOne(RenderingObjects);
            Transition = new LevelTransition(RenderingObjects);

            CurrentState = LevelOne;
        }

        public void Update(GameTime gameTime)
        {
            CurrentState.Update(gameTime);

            if (CurrentState.StateChange())
            {

                if (CurrentState.GetStateName() != "LevelTransition")
                {
                    Transition = new LevelTransition(RenderingObjects);
                    CurrentState = Transition;
                    return;
                }

                if (CurrentState.GetStateName() == "LevelTransition")
                {
                    CurrentLevel++;
                    if (CurrentLevel >= 5)
                    {
                        CurrentLevel = 1;
                    }

                    switch (CurrentLevel)
                    {
                        case 1:
                            LevelOne = new LevelOne(RenderingObjects);
                            CurrentState = LevelOne;
                            break;

                        case 2:
                            LevelTwo = new LevelTwo(RenderingObjects);
                            CurrentState = LevelTwo;
                            break;

                        case 3:
                            LevelThree = new LevelThree(RenderingObjects);
                            CurrentState = LevelThree;
                            break;

                        case 4:
                            BossOne = new BossOne(RenderingObjects);
                            CurrentState = BossOne;
                            break;

                    }
                }
            }
        }

        public void Render()
        {
            CurrentState.Render(RenderingObjects.SpriteBatch);
        }
    }
}
