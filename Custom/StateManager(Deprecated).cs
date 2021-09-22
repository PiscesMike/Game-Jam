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
    class StateManager
    {
        RenderingObjects Rendering;

        Dictionary<string, iGameState> GameStates = new Dictionary<string, iGameState>();        // Create a dictionary to hold our game states and their names
        string CurrentGameState = "LevelOne";                                                                                  // Create a string name to hold the name of the current state
        int CurrentPlayerLevel = 0;                                                                                                      // Create an int to store the level the player is currently on
        iGameState CurrentState;                                                                                                        // Create an iGameState instance to reference the current game state

        public StateManager(GraphicsDeviceManager graphics, ContentManager content, SpriteBatch spriteBatch)
        {
            Rendering = new RenderingObjects();

            Rendering.Graphics = graphics;
            Rendering.Content = content;
            Rendering.SpriteBatch = spriteBatch;

            GameStates.Add("LevelOne", new LevelOne(Rendering));                                                 // Add a GameState so our dictionary is not empty
            GameStates.Add("LevelTwo", new LevelTwo(Rendering));                                                 // Add Level Two to our Game States
            GameStates.Add("LevelThree", new LevelThree(Rendering));                                              // Add Level Three to our Game States
            GameStates.Add("LevelFour", new LevelOne(Rendering));                                                // Add Level Four to our Game States
            GameStates.Add("BossOne", new BossOne(Rendering));                                                 // Add Level Five to our Game States

            GameStates.Add("LevelTransition", new LevelTransition(Rendering));                              // Add a Level Transition
            GameStates.TryGetValue(CurrentGameState, out CurrentState);                                      // Set the CurrentState to the default state, in this case LevelOne
        }

        public void Update(GameTime gameTime)
        {
            Rendering.GameTime = gameTime;
            CurrentState.Update(gameTime);

            if (CurrentState.StateChange())
            {

                if (CurrentState.GetStateName() != "LevelTransition")
                {
                    GameStates.Remove("LevelTransition");
                    GameStates.Add("LevelTransition", new LevelTransition(Rendering));                              // Add a Level Transition

                    SetState("LevelTransition");
                    return;
                }

                if (CurrentState.GetStateName() == "LevelTransition")
                {
                    CurrentPlayerLevel++;
                    if (CurrentPlayerLevel >= 5)
                    { CurrentPlayerLevel = 1; }

                    switch (CurrentPlayerLevel)
                    {
                        case 1:
                            GameStates.Remove("LevelOne");
                            GameStates.Add("LevelOne", new LevelOne(Rendering));                                                 // Add a GameState so our dictionary is not empty
                            SetState("LevelOne");
                            break;

                        case 2:
                            GameStates.Remove("LevelTwo");
                            GameStates.Add("LevelTwo", new LevelTwo(Rendering));                                                 // Add a GameState so our dictionary is not empty
                            SetState("LevelTwo");
                            break;

                        case 3:
                            GameStates.Remove("LevelThree");
                            GameStates.Add("LevelThree", new LevelThree(Rendering));                                                 // Add a GameState so our dictionary is not empty
                            SetState("LevelThree");
                            break;

                        case 4:
                            GameStates.Remove("BossOne");
                            GameStates.Add("BossOne", new BossOne(Rendering));                                                 // Add a GameState so our dictionary is not empty
                            SetState("BossOne");
                            break;

                    }
                }
            }
        }

        public void Render()
        {
            CurrentState.Render(Rendering.SpriteBatch);
        }

        public void SetState(string state)
        {
            CurrentGameState = state;                                                                                                // Update the name of the current state in CurrentGameState
            GameStates.TryGetValue(CurrentGameState, out CurrentState);                                      // Set the CurrentState to the CurrentGameState state, in this case LevelOne
        }
    }
}
