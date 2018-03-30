using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;

namespace Morabaraba_2
{
    /// <summary>
    /// Constraints class runs the whole game, doing all sorts of rules checking and validations, making sure no invalid move/actions slips by
    /// </summary>
    class Constraints
    {
        public Player Player1;
        public Player Player2;
        public GUI player1GUI;
        public GUI player2GUI;

        private List<Point> validPos;               // List of all valid position in the borad
        public string currentPlayer;                // who is currently playing
        private Canvas brd;             

        private List<List<Point>> possibleMills;    //List of possible mill formations that exist in the game
        private List<List<Point>> neighbourPos;     //List of each position's neighbours, each index represent a location and within that index is a list of all his neighbours

        public bool mill;                           // Mill formed?
        public bool draw;                           // Draw game?
        private int magicNumber;                    // A number to use to estimate a valid point, which is a cow's actual width
        public Constraints(Canvas brd)
        {
            this.brd = brd;
            Player1 = new Player("Red",brd);
            Player2 = new Player("Yellow",brd);

            player1GUI = new GUI(Player1);
            player2GUI = new GUI(Player2);
            
            currentPlayer = "Red";
            validPos = validPositions();
            possibleMills = mill_Possibilities();
            neighbourPos = neighbours();
            mill = false;
            draw = false;
            magicNumber = (int)Player1.pieces[0].Width;

            player2GUI.playerTurn.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Given a divider, return a X-coordinate in the Canvas
        /// </summary>
        /// <param name="divider"> Magic Number</param>
        /// <returns></returns>
        private int xCordinate (double divider)
        {
            return Convert.ToInt32((brd.ActualWidth / divider));
        }

        /// <summary>
        /// Given a divider, return a Y-coordinate in the Canvas
        /// </summary>
        /// <param name="divider"> Magic Number</param>
        /// <returns></returns>
        private int yCordinate(double divider)
        {
            return Convert.ToInt32((brd.ActualHeight / divider));
        }

        /// <summary>
        /// Given a point in a canvas, if it's distance from 'A valid POINT' is within the length of a pieces' width, validate the point, to avoid multiple misses
        /// </summary>
        /// <param name="p"> Input point from Canvas</param>
        /// <returns></returns>
        public Point pointValidation(Point p)
        {
            foreach (Point point in validPos)
            {
                if (Math.Abs(p.X - point.X) <= magicNumber && Math.Abs(p.Y - point.Y) <= magicNumber)
                {
                    p = point;
                    break;
                }
            }
            return p;
        }

        //Create valid Positions, manually
        private List<Point> validPositions()
        {
            List<Point> result = new List<Point>();
            // A---
            result.Add(new Point(xCordinate(4.03), yCordinate(9.05)));            //A1
            result.Add(new Point(xCordinate(2.007), yCordinate(9.05)));           //A4
            result.Add(new Point(xCordinate(1.335), yCordinate(9.05)));           //A7
            // B--
            result.Add(new Point(xCordinate(3.01), yCordinate(3.94)));            //B2
            result.Add(new Point(xCordinate(2.007), yCordinate(3.94)));           //B4
            result.Add(new Point(xCordinate(1.505), yCordinate(3.94)));           //B7
            // C--
            result.Add(new Point(xCordinate(2.415), yCordinate(2.54)));           //C3
            result.Add(new Point(xCordinate(2.007), yCordinate(2.54)));           //C4
            result.Add(new Point(xCordinate(1.716), yCordinate(2.54)));           //C5
            // D---
            result.Add(new Point(xCordinate(4.03), yCordinate(1.868)));           //D1
            result.Add(new Point(xCordinate(3.01), yCordinate(1.868)));           //D2
            result.Add(new Point(xCordinate(2.415), yCordinate(1.868)));          //D3
            result.Add(new Point(xCordinate(1.716), yCordinate(1.868)));          //D5
            result.Add(new Point(xCordinate(1.505), yCordinate(1.868)));          //D6
            result.Add(new Point(xCordinate(1.335), yCordinate(1.868)));          //D7
            // E--
            result.Add(new Point(xCordinate(2.415), yCordinate(1.475)));          //E3
            result.Add(new Point(xCordinate(2.007), yCordinate(1.475)));          //E4  
            result.Add(new Point(xCordinate(1.716), yCordinate(1.475)));          //E5
            // F--
            result.Add(new Point(xCordinate(3.01), yCordinate(1.222)));           //F2
            result.Add(new Point(xCordinate(2.007), yCordinate(1.222)));          //F4
            result.Add(new Point(xCordinate(1.505), yCordinate(1.222)));          //F6
            // G--
            result.Add(new Point(xCordinate(4.03), yCordinate(1.042)));           //G1
            result.Add(new Point(xCordinate(2.007), yCordinate(1.042)));          //G4
            result.Add(new Point(xCordinate(1.335), yCordinate(1.042)));          //G7
            return result;
        }

        //Create valid mill formations, manually
        private List<List<Point>> mill_Possibilities()
        {
            List<List<Point>> result = new List<List<Point>>();
            Point a1 = new Point(xCordinate(4.03), yCordinate(9.05));
            Point a4 = new Point(xCordinate(2.007), yCordinate(9.05));
            Point a7 = new Point(xCordinate(1.335), yCordinate(9.05));

            List<Point> mill = new List<Point>{ a1, a4, a7 };
            result.Add(mill);

            Point b2 = new Point(xCordinate(3.01), yCordinate(3.94));
            Point b4 = new Point(xCordinate(2.007), yCordinate(3.94));
            Point b6 = new Point(xCordinate(1.505), yCordinate(3.94));

            mill = new List<Point> { b2, b4, b6 };
            result.Add(mill);

            Point c3 = new Point(xCordinate(2.415), yCordinate(2.54));
            Point c4 = new Point(xCordinate(2.007), yCordinate(2.54));
            Point c5 = new Point(xCordinate(1.716), yCordinate(2.54));

            mill = new List<Point> { c3, c4, c5 };
            result.Add(mill);

            Point d1 = new Point(xCordinate(4.03), yCordinate(1.868));
            Point d2 = new Point(xCordinate(3.01), yCordinate(1.868));
            Point d3 = new Point(xCordinate(2.415), yCordinate(1.868));

            mill = new List<Point> { d1, d2, d3 };
            result.Add(mill);

            Point d5 = new Point(xCordinate(1.716), yCordinate(1.868));
            Point d6 = new Point(xCordinate(1.505), yCordinate(1.868));
            Point d7 = new Point(xCordinate(1.335), yCordinate(1.868));

            mill = new List<Point> { d5, d6, d7 };
            result.Add(mill);

            Point e3 = new Point(xCordinate(2.415), yCordinate(1.475));
            Point e4 = new Point(xCordinate(2.007), yCordinate(1.475));
            Point e5 = new Point(xCordinate(1.716), yCordinate(1.475));

            mill = new List<Point> { e3, e4, e5 };
            result.Add(mill);

            Point f2 = new Point(xCordinate(3.01), yCordinate(1.222));
            Point f4 = new Point(xCordinate(2.007), yCordinate(1.222));
            Point f6 = new Point(xCordinate(1.505), yCordinate(1.222));

            mill = new List<Point> { f2, f4, f6 };
            result.Add(mill);

            Point g1 = new Point(xCordinate(4.03), yCordinate(1.042));
            Point g4 = new Point(xCordinate(2.007), yCordinate(1.042));
            Point g7 = new Point(xCordinate(1.335), yCordinate(1.042));

            mill = new List<Point> { g1, g4, g7 };
            result.Add(mill);
            mill = new List<Point> { a1, b2, c3 };
            result.Add(mill);
            mill = new List<Point> { a1, d1, g1 };
            result.Add(mill);
            mill = new List<Point> { a4, b4, c4 };
            result.Add(mill);
            mill = new List<Point> { a7, b6, c5 };
            result.Add(mill);
            mill = new List<Point> { a7, d7, g7 };
            result.Add(mill);
            mill = new List<Point> { b2, d2, f2 };
            result.Add(mill);
            mill = new List<Point> { b6, d6, f6 };
            result.Add(mill);
            mill = new List<Point> { c3, d3, e3 };
            result.Add(mill);
            mill = new List<Point> { c5, d5, e5 };
            result.Add(mill);
            mill = new List<Point> { g1, f2, e3 };
            result.Add(mill);
            mill = new List<Point> { g4, f4, e4 };
            result.Add(mill);
            mill = new List<Point> { g7, f6, e5 };
            result.Add(mill);

            return result;
        }

        //Create valid neighbours, manually
        private List<List<Point>> neighbours()
        {
            List<List<Point>> result = new List<List<Point>>();
            Point a1 = new Point(xCordinate(4.03), yCordinate(9.05));
            Point a4 = new Point(xCordinate(2.007), yCordinate(9.05));
            Point a7 = new Point(xCordinate(1.335), yCordinate(9.05));
            
            Point b2 = new Point(xCordinate(3.01), yCordinate(3.94));
            Point b4 = new Point(xCordinate(2.007), yCordinate(3.94));
            Point b6 = new Point(xCordinate(1.505), yCordinate(3.94));
            
            Point c3 = new Point(xCordinate(2.415), yCordinate(2.54));
            Point c4 = new Point(xCordinate(2.007), yCordinate(2.54));
            Point c5 = new Point(xCordinate(1.716), yCordinate(2.54));
            
            Point d1 = new Point(xCordinate(4.03), yCordinate(1.868));
            Point d2 = new Point(xCordinate(3.01), yCordinate(1.868));
            Point d3 = new Point(xCordinate(2.415), yCordinate(1.868));
            
            Point d5 = new Point(xCordinate(1.716), yCordinate(1.868));
            Point d6 = new Point(xCordinate(1.505), yCordinate(1.868));
            Point d7 = new Point(xCordinate(1.335), yCordinate(1.868));
            
            Point e3 = new Point(xCordinate(2.415), yCordinate(1.475));
            Point e4 = new Point(xCordinate(2.007), yCordinate(1.475));
            Point e5 = new Point(xCordinate(1.716), yCordinate(1.475));
            
            Point f2 = new Point(xCordinate(3.01), yCordinate(1.222));
            Point f4 = new Point(xCordinate(2.007), yCordinate(1.222));
            Point f6 = new Point(xCordinate(1.505), yCordinate(1.222));
            
            Point g1 = new Point(xCordinate(4.03), yCordinate(1.042));
            Point g4 = new Point(xCordinate(2.007), yCordinate(1.042));
            Point g7 = new Point(xCordinate(1.335), yCordinate(1.042));

            List<Point> a1_neighbours = new List<Point> { d1, b2, a4 };
            List<Point> a4_neighbours = new List<Point> { a7, b4, a1 };
            List<Point> a7_neighbours = new List<Point> { d7, b6, a4 };
            List<Point> b2_neighbours = new List<Point> { c3, a1, d2, b4 };
            List<Point> b4_neighbours = new List<Point> { c4, b2, a4, b6 };
            List<Point> b6_neighbours = new List<Point> { c5, d6, b4, a7 };
            List<Point> c3_neighbours = new List<Point> { d3, b2, c4 };
            List<Point> c4_neighbours = new List<Point> { c3, b4, c5 };
            List<Point> c5_neighbours = new List<Point> { c4, b6, d5 };
            List<Point> d1_neighbours = new List<Point> { a1, g1, d2 };
            List<Point> d2_neighbours = new List<Point> { d1, d3, b2,f2 };
            List<Point> d3_neighbours = new List<Point> { d2, c3, e3 };
            List<Point> d5_neighbours = new List<Point> { c5, e5, d6 };
            List<Point> d6_neighbours = new List<Point> { d5, b6, f6,d7 };
            List<Point> d7_neighbours = new List<Point> { d6, a7, g7 };
            List<Point> e3_neighbours = new List<Point> { d3, f2, e4 };
            List<Point> e4_neighbours = new List<Point> { e3, f4, e5 };
            List<Point> e5_neighbours = new List<Point> { e4, f6, d5 };
            List<Point> f2_neighbours = new List<Point> { d2, g1, e3, f4 };
            List<Point> f4_neighbours = new List<Point> { f2, e4, g4,f6 };
            List<Point> f6_neighbours = new List<Point> { f4, e5, d6,g7 };
            List<Point> g1_neighbours = new List<Point> { d1, g4, f2 };
            List<Point> g4_neighbours = new List<Point> { g1, f4, g7 };
            List<Point> g7_neighbours = new List<Point> { g4, f6, d7 };

            List<List<Point>> neighbours1 = new List<List<Point>> { a1_neighbours, a4_neighbours, a7_neighbours, b2_neighbours, b4_neighbours, b6_neighbours, c3_neighbours, c4_neighbours};
            List<List<Point>> neighbours2 = new List<List<Point>> { c5_neighbours, d1_neighbours, d2_neighbours, d3_neighbours, d5_neighbours, d6_neighbours, d7_neighbours, e3_neighbours };
            List<List<Point>> neighbours3 = new List<List<Point>> { e4_neighbours, e5_neighbours, f2_neighbours, f4_neighbours, f6_neighbours, g1_neighbours, g4_neighbours, g7_neighbours };

            for (int i = 0; i < neighbours1.Count; i++) result.Add(neighbours1[i]);
            for (int i = 0; i < neighbours2.Count; i++) result.Add(neighbours2[i]);
            for (int i = 0; i < neighbours3.Count; i++) result.Add(neighbours3[i]);

            return result;
        }
        
        /// <summary>
        /// Given a player's mill list and a 'Moving' from point, check if it was in a mill in order to remove the mill from mill list, so that next time i srecognized as a new one
        /// </summary>
        /// <param name="mill_List"> Player's mill list</param>
        /// <param name="p"> A move from point</param>
        private void brokenMill(List<List<Point>> mill_List, Point p)
        {
            for (int i = 0; i < mill_List.Count; i++)
            {
                if (mill_List[i].Contains(p))
                {
                    mill_List.Remove(mill_List[i]);
                    return;
                }
            }
        }

        /// <summary>
        /// Given a mill list and a Point, check if that point is in a mill
        /// </summary>
        /// <param name="mill_List"> Player's mill list</param>
        /// <param name="p"> Given point</param>
        /// <returns></returns>
        private bool cowIn_MillPos(List<List<Point>> mill_List, Point p)
        {
            for(int i=0;i<mill_List.Count;i++)
            {
                if (mill_List[i].Contains(p)) return true;
            }
            return false;
        }

        /// <summary>
        /// Run visual presentations to indicate who is playing or what's the error
        /// </summary>
        private void run_playerTurnGUI()
        {
            if (!mill)
            {
                player1GUI.player_err_msg.Visibility = Visibility.Hidden;
                player2GUI.player_err_msg.Visibility = Visibility.Hidden;

                currentPlayer = swapPlayer(currentPlayer);
                if (currentPlayer == "Yellow")
                {
                    player2GUI.playerTurn.Visibility = Visibility.Visible;
                    player1GUI.playerTurn.Visibility = Visibility.Hidden;
                }
                else
                {
                    player1GUI.playerTurn.Visibility = Visibility.Visible;
                    player2GUI.playerTurn.Visibility = Visibility.Hidden;
                }
            }
        }

        /// <summary>
        /// Locate the piece/cow which matches the coordinates of the given point
        /// </summary>
        /// <param name="p"> A given point</param>
        /// <returns> An ellipse</returns>
        private Ellipse candidate(Point p)
        {
            foreach (object ob in brd.Children)
            {
                if (ob is Ellipse)
                {
                    Ellipse x = (Ellipse)ob;
                    if (Canvas.GetLeft(x) + (x.ActualWidth / 2) == p.X && Canvas.GetTop(x) + (x.ActualHeight / 2) == p.Y)
                    {
                        return x;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Given a point, locate it and remove it from the board, using all sorts of methods from validation and location
        /// </summary>
        /// <param name="p"> Given point</param>
        public void Eliminate(Point p)
        {
            if (invalidKill_specialCase())
            {
                mill = false;
                currentPlayer = swapPlayer(currentPlayer);
                return;
            }

            p = pointValidation(p);

            if (!invalidKill(p))
            {
                Ellipse victim = candidate(p);
                brd.Children.Remove(victim);
                mill = false;
                if (currentPlayer == "Red") Player1.eliminateOpponent(Player2, p);
                else Player2.eliminateOpponent(Player1, p);

                Player1.stageUpdate();
                Player2.stageUpdate();

                player2GUI.GUI_update();
                player1GUI.GUI_update();
                run_playerTurnGUI();
            }

        }

        /// <summary>
        /// Given a point to kill enemy cow, check if it is a valid point, is it an enemy cow which is not in a mill, and it's not your own cow
        /// </summary>
        /// <param name="p"> Given point to eliminate the cow</param>
        /// <returns></returns>
        private bool invalidKill(Point p)
        {
            Ellipse victim = candidate(p);
            if (victim == null)
            {
                messageDisplay("Invalid point, try again");
                return true;
            }
            else
            {
                if (currentPlayer == "Red" && victim.Fill.Equals(Brushes.Yellow))
                {
                    if (cowIn_MillPos(Player2.mill_List, p) && Player2.lives != 3)
                    {
                        messageDisplay("Cannot kill a cow already\n in a mill, try\n another cow");
                        return true;
                    }
                    return false;

                }
                else if (currentPlayer == "Yellow" && victim.Fill.Equals(Brushes.Red))
                {
                    if (cowIn_MillPos(Player1.mill_List, p) && Player1.lives != 3)
                    {
                        messageDisplay("Cannot kill a cow already\n in a mill, try\n another cow");
                        return true;
                    }
                    return false;
                }
                else
                {
                    messageDisplay("Don't kill yourself, Try again");
                    return true;
                }
            }
        }

        /// <summary>
        /// Check if all enemy cows are in mill formation, if so, a kill is wasted and a player loses a turn
        /// </summary>
        /// <param name="player"> Opponent to killed </param>
        /// <param name="pg1"> player1GUI</param>
        /// <param name="pg2"> player2GUI</param>
        /// <param name="whichCow"> string for display purpose</param>
        /// <returns></returns>
        private bool invalid_kill_special(Player player, GUI pg1, GUI pg2, string whichCow)
        {
            foreach (Point playedPos in player.playedPos)
            {
                bool pointInMill = false;
                for (int i = 0; i < player.mill_List.Count; i++)
                {
                    if (player.mill_List[i].Contains(playedPos)) pointInMill = true;
                }
                if (!pointInMill || player.lives == 3) return false;
            }
            messageDisplay($"Bad timing to eliminate, all\n{whichCow} COWS IN MILL!\n   MILL WASTED!!");
            pg1.playerTurn.Visibility = Visibility.Hidden;
            pg2.playerTurn.Visibility = Visibility.Visible;
            return true;
        }

        /// <summary>
        /// Check invalid kill special using the above method
        /// </summary>
        /// <returns></returns>
        private bool invalidKill_specialCase()
        {
            if (currentPlayer == "Red")
            {
                return invalid_kill_special(Player2, player1GUI, player2GUI, "YELLOW");
            }
            else
            {
                return invalid_kill_special(Player1, player2GUI, player1GUI, "RED");
            }

        }


        /// <summary>
        /// GUI update display error or informative messages
        /// </summary>
        /// <param name="err_message"></param>
        public void messageDisplay(string err_message)
        {
            if (currentPlayer == "Red")
            {
                player1GUI.player_err_msg.Visibility = Visibility.Visible;
                player1GUI.player_err_msg.Content = err_message;
            }
            else
            {
                player2GUI.player_err_msg.Visibility = Visibility.Visible;
                player2GUI.player_err_msg.Content = err_message;
            }

        }

        /// <summary>
        /// Always run to check for a mill formation and update/broadcast accordingly i.e a field 'mill' will be set true should a mill be found
        /// </summary>
        public void isMill()
        {
            if(currentPlayer=="Red")
            {
                for (int i = 0; i < possibleMills.Count; i++)
                {
                    int count = 0;
                    for (int k = 0; k < Player1.playedPos.Count; k++)
                    {
                        if (possibleMills[i].Contains(Player1.playedPos[k])) count++;
                    }

                    if(count==3 && !Player1.mill_List.Contains(possibleMills[i]))
                    {
                        Player1.mill_List.Add(possibleMills[i]);
                        messageDisplay("RED HAS MILL, Choose a cow\n to eliminate");
                        mill = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < possibleMills.Count; i++)
                {
                    int count = 0;
                    for (int k = 0; k < Player2.playedPos.Count; k++)
                    {
                        if (possibleMills[i].Contains(Player2.playedPos[k])) count++;
                    }

                    if (count == 3 && !Player2.mill_List.Contains(possibleMills[i]))
                    {
                        Player2.mill_List.Add(possibleMills[i]);
                        messageDisplay("Yellow HAS MILL, Choose a cow\n to eliminate");
                        mill = true;
                    }
                }
            }
        }

        /// <summary>
        /// Given a point, validate it and check who owns the point, this is to avoid a player trying to move another player's piece 
        /// </summary>
        /// <param name="p1"> Given point</param>
        /// <returns> The ower of the point</returns>
        public bool player_own_Point(Point p1)
        {
            p1 = pointValidation(p1);
            return (currentPlayer=="Red"?Player1.playedPos.Contains(p1): Player2.playedPos.Contains(p1));
        }

        /// <summary>
        /// Given a point, return an index to be used in the neighbours list, since within that index is a point's list of neighbours
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int getIndex(Point p)
        {
            Point a1 = new Point(xCordinate(4.03), yCordinate(9.05));
            Point a4 = new Point(xCordinate(2.007), yCordinate(9.05));
            Point a7 = new Point(xCordinate(1.335), yCordinate(9.05));

            Point b2 = new Point(xCordinate(3.01), yCordinate(3.94));
            Point b4 = new Point(xCordinate(2.007), yCordinate(3.94));
            Point b6 = new Point(xCordinate(1.505), yCordinate(3.94));

            Point c3 = new Point(xCordinate(2.415), yCordinate(2.54));
            Point c4 = new Point(xCordinate(2.007), yCordinate(2.54));
            Point c5 = new Point(xCordinate(1.716), yCordinate(2.54));

            Point d1 = new Point(xCordinate(4.03), yCordinate(1.868));
            Point d2 = new Point(xCordinate(3.01), yCordinate(1.868));
            Point d3 = new Point(xCordinate(2.415), yCordinate(1.868));

            Point d5 = new Point(xCordinate(1.716), yCordinate(1.868));
            Point d6 = new Point(xCordinate(1.505), yCordinate(1.868));
            Point d7 = new Point(xCordinate(1.335), yCordinate(1.868));

            Point e3 = new Point(xCordinate(2.415), yCordinate(1.475));
            Point e4 = new Point(xCordinate(2.007), yCordinate(1.475));
            Point e5 = new Point(xCordinate(1.716), yCordinate(1.475));

            Point f2 = new Point(xCordinate(3.01), yCordinate(1.222));
            Point f4 = new Point(xCordinate(2.007), yCordinate(1.222));
            Point f6 = new Point(xCordinate(1.505), yCordinate(1.222));

            Point g1 = new Point(xCordinate(4.03), yCordinate(1.042));
            Point g4 = new Point(xCordinate(2.007), yCordinate(1.042));
            Point g7 = new Point(xCordinate(1.335), yCordinate(1.042));

            if (p == a1) return 0;
            if (p == a4) return 1;
            if (p == a7) return 2;
            if (p == b2) return 3;
            if (p == b4) return 4;
            if (p == b6) return 5;
            if (p == c3) return 6;
            if (p == c4) return 7;
            if (p == c5) return 8;
            if (p == d1) return 9;
            if (p == d2) return 10;
            if (p == d3) return 11;
            if (p == d5) return 12;
            if (p == d6) return 13;
            if (p == d7) return 14;
            if (p == e3) return 15;
            if (p == e4) return 16;
            if (p == e5) return 17;
            if (p == f2) return 18;
            if (p == f4) return 19;
            if (p == f6) return 20;
            if (p == g1) return 21;
            if (p == g4) return 22;
            if (p == g7) return 23;

            return -1;
        }

        /// <summary>
        /// check if the a point to MOVE TO is a black space and is a neighbour by checking MOVE FROM 's neighbours for moving stage, otherwise disregard the neighbour part for flying
        /// </summary>
        /// <param name="p1"> MOVE FROM</param>
        /// <param name="p2">MOVE TO</param>
        /// <returns></returns>
        private bool invalidMove0(Point p1, Point p2)
        {
            if (!validPos.Contains(p2))
            {
                messageDisplay("You have clicked an \ninvalid point, try again!");
                return true;
            }
            else if (Player1.playedPos.Contains(p2) || Player2.playedPos.Contains(p2))
            {
                messageDisplay("The space is already \noccupied, try another location");
                return true;
            }
            else
            {
                int index = getIndex(p1);
                if (!neighbourPos[index].Contains(p2))
                {
                    if (currentPlayer == "Red" && Player1.stage == "Flying") return false;
                    if (currentPlayer == "Yellow" && Player2.stage == "Flying") return false;
                    messageDisplay("Cannot move to that\nlocation, try another location");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checking for invalid moves for all 3 stages/states i.e Placing, Moving and Flying
        /// </summary>
        /// <param name="p"> MOVE FROM</param>
        /// <param name="p2"> MOVE TO</param>
        /// <returns></returns>
        private bool invalidMove(Point p, Point p2)
        {
            if (!validPos.Contains(p))
            {
                messageDisplay("You have clicked an \ninvalid point, try again!");
                return true;
            }
            else if (Player1.playedPos.Contains(p) && Player1.stage == "Placing" || Player2.playedPos.Contains(p) && Player2.stage == "Placing")
            {
                messageDisplay("The space is already \noccupied, try another location");
                return true;
            }
            else if (Player1.playedPos.Contains(p) && Player1.stage != "Placing")
            {
                return invalidMove0(p,p2);
            }
            else if (Player2.playedPos.Contains(p) && Player2.stage != "Placing")
            {
                return invalidMove0(p,p2);
            }
            return false;
        }

        /// <summary>
        /// Swap the player
        /// </summary>
        /// <param name="player"> Current player</param>
        /// <returns> The other player</returns>
        private string swapPlayer(string player)
        {
            return player == "Red" ? "Yellow" : "Red";
        }
        
        /// <summary>
        /// Check a game is draw i.e no blank space is available to play or move
        /// </summary>
        /// <returns></returns>
        private bool drawGame()
        {
            int countEmpty = 0;
            foreach (Point p in validPos)
            {
                if (Player2.playedPos.Contains(p) || Player1.playedPos.Contains(p)) countEmpty++;
            }
            return countEmpty == 24;
        }

        /// <summary>
        /// A draw game GUI to display realted messages about the draw and how to proceed
        /// </summary>
        /// <param name="pgWinner"> player1GUI</param>
        /// <param name="pgLoser">player2GUI</param>
        private void drawGame(GUI pgWinner, GUI pgLoser)
        {
            pgWinner.playerTurn.Visibility = Visibility.Visible;
            pgLoser.playerTurn.Visibility = Visibility.Visible;
            pgWinner.player_err_msg.Visibility = Visibility.Visible;
            pgLoser.player_err_msg.Visibility = Visibility.Visible;

            pgWinner.playerTurn.Content = "DRAW";
            pgWinner.player_err_msg.Content = "Game is a draw, game Over!\n\n click on back to main screen\n to start a new game";
            pgLoser.playerTurn.Content = "DRAW";
            pgLoser.player_err_msg.Content = "Game is a draw, game Over!\n\n click on back to main screen\n to start a new game";
            draw = true;
        }

        /// <summary>
        /// A method that actually run the whole game using almost all of the functions before accepting the points as valid, i.e it will fail if either of point p1 or p2 is not validated
        /// </summary>
        /// <param name="p1"> Place to poisition or MOVE/FLY FROM position</param>
        /// <param name="p2"> MOVE/FLY from position</param>
        public void gamePlay(Point p1, Point p2)
        {
            p1 = pointValidation(p1);
            p2 = pointValidation(p2);
            
            if (invalidMove(p1,p2))
            {
                return;
            }
            else
            {
                if (currentPlayer == "Red")
                {
                    Player1.makeMove(p1, p2);
                    if (cowIn_MillPos(Player1.mill_List, p1)) brokenMill(Player1.mill_List, p1);
                }
                else
                {
                    Player2.makeMove(p1, p2);
                    if (cowIn_MillPos(Player2.mill_List, p1)) brokenMill(Player2.mill_List, p1);
                }

                if (Player1.stage != "Placing" || Player1.stage != "Placing")
                {
                    if(drawGame())
                    {
                        drawGame(player1GUI, player2GUI);
                        return;
                    }
                }
                
                isMill();
                run_playerTurnGUI();
            }
        }
        
    }
}
