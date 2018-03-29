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
    class Constraints
    {
        public Player Player1;
        public Player Player2;
        public GUI player1GUI;
        public GUI player2GUI;

        private List<Point> validPos;
        public string currentPlayer;
        private Canvas brd;

        private List<List<Point>> possibleMills;
        private List<List<Point>> neighbourPos;
        public bool mill;
        
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
            
            player2GUI.playerTurn.Visibility = Visibility.Hidden;
        }

        private int xCordinate (double divider)
        {
            return Convert.ToInt32((brd.ActualWidth / divider));
        }

        private int yCordinate(double divider)
        {
            return Convert.ToInt32((brd.ActualHeight / divider));
        }

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
            List<Point> d7_neighbours = new List<Point> { d6, a7, g1 };
            List<Point> e3_neighbours = new List<Point> { d3, f2, e4 };
            List<Point> e4_neighbours = new List<Point> { e3, f6, e5 };
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

            MessageBox.Show("" + result.Count);
            return result;
        }

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

        private Ellipse candidate(Point p)
        {
            foreach(object ob in brd.Children)
            {
                if(ob is Ellipse)
                {
                    Ellipse x = (Ellipse)ob;
                    if (Canvas.GetLeft(x) + (x.ActualWidth/2) == p.X && Canvas.GetTop(x) + (x.ActualHeight/2) == p.Y)
                    {
                        return x;
                    }
                }
            }
            return null;
        }

        private bool cowIn_MillPos(List<List<Point>> mill_List, Point p)
        {
            for(int i=0;i<mill_List.Count;i++)
            {
                if (mill_List[i].Contains(p)) return true;
            }
            return false;
        }

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

        public void Eliminate(Point p)
        {
            if (invalidKill_specialCase())
            {
                mill = false;
                currentPlayer = swapPlayer(currentPlayer);
                return;
            }

            foreach (Point point in validPos)
            {
                if (Math.Abs(p.X - point.X) <= 70 && Math.Abs(p.Y - point.Y) <= 70)
                {
                    p = point;
                    break;
                }
            }
            
            if (!invalidKill(p))
            {
                Ellipse victim = candidate(p);
                brd.Children.Remove(victim);
                mill = false;
                if (currentPlayer == "Red") Player1.eliminateOpponent(Player2, p);
                else Player2.eliminateOpponent(Player1, p);

                player1GUI.GUI_update();
                player2GUI.GUI_update();
                run_playerTurnGUI();
            }

        }

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

        public bool player_own_Point(Point p1)
        {
            foreach (Point point in validPos)
            {
                if (Math.Abs(p1.X - point.X) <= 70 && Math.Abs(p1.Y - point.Y) <= 70)
                {
                    p1 = point;
                }
            }
            return (currentPlayer=="Red"?Player1.playedPos.Contains(p1): Player2.playedPos.Contains(p1));
        }

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
                    messageDisplay("Cannot move to that\nlocation, try another location");
                    return true;
                }
            }
            return false;
        }

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
            else if (Player1.playedPos.Contains(p) && Player1.stage == "Moving")
            {
                return invalidMove0(p,p2);
            }
            else if (Player2.playedPos.Contains(p) && Player2.stage == "Moving")
            {
                return invalidMove0(p,p2);
            }
            return false;
        }

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
                    if (cowIn_MillPos(Player2.mill_List, p))
                    {
                        messageDisplay("Cannot kill a cow already in a mill,\n try another cow");
                        return true;
                    }
                    return false;
                    
                }
                else if(currentPlayer == "Yellow" && victim.Fill.Equals(Brushes.Red))
                {
                    if (cowIn_MillPos(Player1.mill_List, p))
                    {
                        messageDisplay("Cannot kill a cow already in a mill,\n try another cow");
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

        private bool invalid_kill_special(Player player, GUI pg1, GUI pg2, string whichCow)
        {
            foreach (Point playedPos in player.playedPos)
            {
                bool pointInMill = false;
                for (int i = 0; i < player.mill_List.Count; i++)
                {
                    if (player.mill_List[i].Contains(playedPos)) pointInMill = true;
                }
                if (!pointInMill) return false;
            }
            messageDisplay($"Bad timing to eliminate, all\n{whichCow} COWS IN MILL!\n   MILL WASTED!!");
            pg1.playerTurn.Visibility = Visibility.Hidden;
            pg2.playerTurn.Visibility = Visibility.Visible;
            return true;
        }

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

        private string swapPlayer(string player)
        {
            return player == "Red" ? "Yellow" : "Red";
        }
        

        public void gamePlay(Point p1, Point p2)
        {
            foreach (Point point in validPos)
            {
                if (Math.Abs(p1.X - point.X) <= 70 && Math.Abs(p1.Y - point.Y) <= 70)
                {
                    p1 = point;
                }
                if (Math.Abs(p2.X - point.X) <= 70 && Math.Abs(p2.Y - point.Y) <= 70)
                {
                    p2 = point;
                }
            }
            if (invalidMove(p1,p2))
            {
                return;
            }
            else
            {
                if (currentPlayer == "Red") Player1.placePiece(p1,p2);
                else Player2.placePiece(p1,p2);

                isMill();
                run_playerTurnGUI();
            }
        }
        
    }
}
