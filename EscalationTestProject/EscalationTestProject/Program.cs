using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EscalationTestProject
{
    class Program
    {
        public enum GameState { MainMenu = 0, Inspector, Collision, View, };

        static MapLoader loader = new MapLoader();
        static GameState state = GameState.MainMenu;

        static void Main(string[] args)
        {

            loader.Load("../../res/EscalationProgrammerTest.bin");

            bool shouldClose = false;

            int parse;

            while (!shouldClose)
            {
                Console.WriteLine(state);
                string playerInput = Console.ReadLine();
                if (playerInput == "x")
                {
                    if (state != GameState.MainMenu)
                    {
                        state = GameState.MainMenu;
                    }
                    else
                    {
                        shouldClose = true;
                    }
                }

                switch (state)
                {
                    case GameState.MainMenu:
                        if (int.TryParse(playerInput, out parse))
                        {
                            if (parse == 0)
                            {
                                state = GameState.Inspector;
                            }
                            if (parse == 1)
                            {
                                state = GameState.Collision;
                            }
                            if (parse == 2)
                            {
                                state = GameState.View;
                            }
                        }
                        break;

                    case GameState.Inspector:
                        if (int.TryParse(playerInput, out parse))
                        {
                            loader.entities[parse].Write(true);
                        }
                        break;

                    case GameState.Collision:
                        if (int.TryParse(playerInput, out parse))
                        {
                            Entity[] hits = loader.entities[parse].TestCollision(loader.entities);
                            Console.WriteLine("Entity " + parse + " is touching entities:");
                            foreach (Entity i in hits)
                            {
                                Console.WriteLine("\tEntity " + i.id);
                            }
                        }
                        break;

                    case GameState.View:
                        if (int.TryParse(playerInput, out parse))
                        {
                            Entity[] hits = loader.entities[parse].TestView(loader.entities);
                            Console.WriteLine("Entity " + parse + " can see entities:");
                            foreach (Entity i in hits)
                            {
                                Console.WriteLine("\tEntity " + i.id);
                            }
                        }
                        break;
                }
                
            }
        }
    }
}
