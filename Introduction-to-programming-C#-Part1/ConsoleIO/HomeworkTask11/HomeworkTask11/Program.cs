using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace HomeworkTask11 {
    class FallingRocks {

        static void PlayStressingMusic() {

            int note1 = 400;
            int subnote = 360;
            int note2 = 380;

            int s1 = 75;
            int ss1 = 50;
            int d1 = 175;
            int sd1 = 125;

            Console.Beep(note1, d1);  // 1
            Thread.Sleep(s1);
            Console.Beep(note1, d1); // 2
            Thread.Sleep(s1);
            Console.Beep(note1, d1); // 3
            Thread.Sleep(200);
            Console.Beep(note1, d1); // 1
            Thread.Sleep(s1);
            Console.Beep(note1, d1); //2
            Thread.Sleep(s1);

            Console.Beep(subnote, sd1); //SUBNOTE
            Thread.Sleep(ss1);
            Console.Beep(note1, sd1);
            Thread.Sleep(ss1);
            Console.Beep(subnote, sd1); //SUBNOTE
            Thread.Sleep(ss1);
            Console.Beep(note1, sd1);
            Thread.Sleep(190);

            Console.Beep(note2, d1);  // 1
            Thread.Sleep(s1);
            Console.Beep(note2, d1); // 2
            Thread.Sleep(s1);
            Console.Beep(note2, d1); // 3
            Thread.Sleep(200);
            Console.Beep(note2, d1); // 1
            Thread.Sleep(s1);
            Console.Beep(note2, d1); //2
            Thread.Sleep(s1);

            Console.Beep(subnote, sd1); //SUBNOTE
            Thread.Sleep(ss1);
            Console.Beep(note2, sd1);
            Thread.Sleep(ss1);
            Console.Beep(subnote, sd1); //SUBNOTE
            Thread.Sleep(ss1);
            Console.Beep(note2, sd1);
            Thread.Sleep(190);
        }

        #region GameConstants
        const int FallingRocksWidth = 15;
        const int FallingRocksHeight = 15;
        const int InfoPanelWidth = 10;
        const int GameWidth = FallingRocksWidth + InfoPanelWidth + 3;
        const int GameHeight = FallingRocksHeight + 2;
        const char BorderCharacter = (char)219;
        const char HeartCharacter = (char)3;
        const string DwarfSymbols = "(O)";
        const ConsoleColor DwarfColor = ConsoleColor.DarkRed;
        #endregion

        #region GameStateVariables
        static int Score = 0;
        static int Level = 1; // Max level: 9
        static int DwarfPosition = FallingRocksWidth / 2;
        static int DwarfLives = 5;
        static int MaximumNumberOfRocks = 5;
        static int MaxRocksPerFrame = 2;
        static int GameSpeed = 250;
        static Random random = new Random();
        #endregion

        #region rocksAndColorsArrays
        static char[] rockSymbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
        static List<Rock> rocks = new List<Rock>();     //List of the generated rock Symbols;

        static ConsoleColor[] colors = 
            { 
                ConsoleColor.Yellow,
                ConsoleColor.White,
                ConsoleColor.Green,
                ConsoleColor.DarkYellow
            };

        #endregion

        public class Rock {
        
            public bool visible = true;    //After going under FallingRocksHeight, rock will get invisible, later removed
 
            //Top of the window, random from left to right
            public int x = random.Next(0, FallingRocksWidth);
            public int y = 1;
 
            //Color and Symbol are random
            public char symbol = rockSymbols[random.Next(0, rockSymbols.Length)];
            public ConsoleColor color = colors[random.Next(0, colors.Length)];
        }

        static void Print(int row, int col, object data, ConsoleColor color = ConsoleColor.Green) {

            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(data);
        }

        static void PrintInfoPanel() {

            Print(2, FallingRocksWidth + 4, "Lives:");
            int livesStartPosition = InfoPanelWidth / 2 - (DwarfLives - 1) / 2;
            livesStartPosition += FallingRocksWidth + 1;
            for (int i = 0; i < DwarfLives; i++) {
                Print(3, livesStartPosition + i, HeartCharacter, ConsoleColor.Red);
            }

            Print(6, FallingRocksWidth + 4, "Score:");
            int scoreStartposition = InfoPanelWidth / 2 - (Score.ToString().Length - 1) / 2;
            scoreStartposition = scoreStartposition + FallingRocksWidth + 2;
            Print(7, FallingRocksWidth + 2, "          ");
            Print(7, scoreStartposition - 1, Score, ConsoleColor.Blue);

            Print(9, FallingRocksWidth + 4, "Level:");
            Print(10, FallingRocksWidth + 6, Level, ConsoleColor.Blue);

            Print(12, FallingRocksWidth + 3, "Controls");
            Print(14, FallingRocksWidth + 2, "   < >    ", ConsoleColor.Yellow);
        }

        static void UpdateScore() {

            Score += 1 * Level;

            //Update Score
            int scoreStartposition = InfoPanelWidth / 2 - (Score.ToString().Length - 1) / 2;
            scoreStartposition = scoreStartposition + FallingRocksWidth + 2;
            Print(7, scoreStartposition - 5, ' ');
            Print(7, scoreStartposition - 1, Score, ConsoleColor.Blue);

            if (Level != 9) {
                if (Score >= 5 && Score < 30 && Level != 2) {

                    UpdateLevel(2);
                }
                else if (Score >= 30 && Score < 50 && Level != 3) {

                    UpdateLevel(3);
                }
                else if (Score >= 50 && Score < 100 && Level != 4) {

                    UpdateLevel(4);
                }
                else if (Score >= 100 && Score < 300 & Level != 5) {

                    UpdateLevel(5);
                }
                else if (Score >= 300 && Score < 1000 && Level != 6) {

                    UpdateLevel(6);
                }
                else if (Score >= 1000 && Score < 2000 && Level != 7) {

                    UpdateLevel(7);
                }
                else if (Score >= 2000 && Score < 5000 && Level != 8) {

                    UpdateLevel(8);
                }
                else if (Score >= 5000 && Level != 9) {

                    UpdateLevel(9);
                }
            }

        }

        static void UpdateLevel(int level) {

            Level = level;
            Print(10, FallingRocksWidth + 6, Level, ConsoleColor.Blue);
            MaxRocksPerFrame = 1 + Level/2;
            MaximumNumberOfRocks += Level/4;

            switch (Level) {

                case 1: GameSpeed = 250; break;
                case 2: GameSpeed = 200; break;
                case 3: GameSpeed = 150; break;
                case 4: GameSpeed = 100; break;
                case 5: GameSpeed = 70; break;
                case 6: GameSpeed = 50; break;
                case 7: GameSpeed = 40; break;
                case 8: GameSpeed = 30; break;
                case 9: GameSpeed = 20; break;
                default: GameSpeed = 150; break;
            }
        }

        static void LoseALife () {

            int deleteStartPosition = InfoPanelWidth / 2 - (DwarfLives - 1) / 2;
            deleteStartPosition += FallingRocksWidth + 1;
            
            --DwarfLives;
            
            int livesStartPosition = InfoPanelWidth / 2 - (DwarfLives - 1) / 2;
            livesStartPosition += FallingRocksWidth + 1;

            for (int j = 0; j < DwarfLives + 1; j++)
			{
			    Print(3, deleteStartPosition + j, ' ');
			}

            for (int i = 0; i < DwarfLives; i++) {
                Print(3, livesStartPosition + i, HeartCharacter, ConsoleColor.Red);
            }
        }

        static void PrintBorders() {
            for (int col = 0; col < GameWidth; col++) {
                Print(0, col, BorderCharacter);
                Print(GameHeight - 1, col, BorderCharacter);
            }

            for (int row = 0; row < GameHeight; row++) {
                Print(row, 0, BorderCharacter);
                Print(row, FallingRocksWidth + 1, BorderCharacter);
                Print(row, FallingRocksWidth + 1 + InfoPanelWidth + 1, BorderCharacter);
            }
        }

        static void PrintProblematicBorders() {

            for (int row = GameHeight/2; row < GameHeight; row++) {

                Print(row, FallingRocksWidth + 1, BorderCharacter);
            }

            for (int col = GameWidth/2; col < GameWidth; col++) {

                Print(GameHeight - 1, col, BorderCharacter);
            }
        }

        static void PrintGameField() {
            for (int row = 1; row <= FallingRocksHeight; row++) {
                for (int col = 1; col <= FallingRocksWidth; col++) {

                    bool exists = false;

                    foreach (Rock rock in rocks) {

                        if(rock.y == row && rock.x == col && rock.visible) {

                            exists = true;
                            Print(row, col, rock.symbol, rock.color);
                        }

                        if (!rock.visible) {

                            Print(row, col, ' ');
                        }
                        
                    }

                    if (!exists) {
                        Print(row, col, ' ');
                    }
                }
            }
        }

        static void PrintDwarf() {

            Print(FallingRocksHeight, DwarfPosition, DwarfSymbols, DwarfColor);
        }

        static void Repaint() {

            PrintGameField();
            PrintProblematicBorders();
            PrintDwarf();
        }

        static void PrintNewGameQuestion() {

            Print(FallingRocksHeight/2, FallingRocksWidth/2, "GAME OVER!\n Start over? ('yes'/ 'no')\n", ConsoleColor.DarkMagenta);
        }

        static void MoveDwarfLeft() {

            if (DwarfPosition > 1) {

                int lastPos = DwarfPosition;
                --DwarfPosition;
                Print(FallingRocksHeight, lastPos + DwarfSymbols.Length - 1, ' ', DwarfColor);

            }
        }

        static void MoveDwarfRight() {

            if (DwarfPosition < FallingRocksWidth - DwarfSymbols.Length + 1) {

                int lastPos = DwarfPosition;
                ++DwarfPosition;
                Print(FallingRocksHeight, lastPos, ' ', DwarfColor);
            }
        }

        static void GenerateNewRocks() {

            if (random.Next(0, 4) != 0) { //75% chance for new rocks
                int countOfNewRocks = random.Next(0, MaxRocksPerFrame);

                for (int newrock = 0; newrock < countOfNewRocks; newrock++) {

                    if (rocks.Count < MaximumNumberOfRocks) {
                        rocks.Add(new Rock());
                    }
                }
            }

        }

        static void DropRocks() {

            foreach (Rock rock in rocks) {

                if (rock.y < GameHeight) {

                    ++rock.y;
                }
                else {

                    UpdateScore();
                    rock.visible = false;
                }
            }

            rocks.RemoveAll(x => !x.visible);

        }

        static void checkForCollision() {

            foreach (Rock rock in rocks) {

                if (rock.y == GameHeight && (rock.x >= DwarfPosition && rock.x <= DwarfPosition + DwarfSymbols.Length - 1)) {

                    LoseALife();
                    rock.visible = false;
                }
            }

            rocks.RemoveAll(x => !x.visible);
        }

        static void Play() {

            bool broken = false;
            PrintInfoPanel();
            PrintBorders();
            PrintDwarf();
            while (true) {

                DropRocks();
                checkForCollision();

                if (DwarfLives <= 0) {

                    broken = true;
                    break;
                }

                GenerateNewRocks();
                if (Console.KeyAvailable) {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow) {
                        MoveDwarfLeft();
                    }
                    else if (key.Key == ConsoleKey.RightArrow) {
                        MoveDwarfRight();
                    }
                }
                Repaint();
                Thread.Sleep(GameSpeed);
            }

            if (broken) {

                using (SpeechSynthesizer synth = new SpeechSynthesizer()) {
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak("Game, over");
                }

                PrintNewGameQuestion();

                if (Console.ReadLine() == "yes") {

                    using (SpeechSynthesizer synth = new SpeechSynthesizer()) {
                        synth.SetOutputToDefaultAudioDevice();
                        synth.Speak("Ready, steady, go");
                    }

                    ResetStateVariables();
                    Print(8, FallingRocksWidth + 2, "             "); //end of reset question gets stuck
                    Play();
                }
            }
        }

        static void ResetStateVariables() {
        
            Score = 0;
            Level = 1; // Max level: 9
            DwarfPosition = FallingRocksWidth / 2;
            DwarfLives = 5;
            MaximumNumberOfRocks = 5;
            MaxRocksPerFrame = 2;
            GameSpeed = 250;
            rocks.RemoveAll(x => x.visible);
            rocks.RemoveAll(x => !x.visible);
        }

        static void Main() {

            Console.OutputEncoding = Encoding.GetEncoding(1252);
            Console.CursorVisible = false;
            Console.Title = "Falling Rocks";
            Console.WindowWidth = GameWidth;
            Console.BufferWidth = GameWidth;
            Console.WindowHeight = GameHeight + 1;
            Console.BufferHeight = GameHeight + 1;

            Task.Run(() => {
                  while (true) {
                      PlayStressingMusic();
                  }
              });

            Play();

        }
    }
}
