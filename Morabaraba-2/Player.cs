using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Morabaraba_2
{
    /// <summary>
    /// Player class to be used to created 2 players of the game
    /// </summary>
    class Player
    {
        
        public string symbol { get; private set; }          // symbol is a player identifier
        public int lives { get; set; }                      // lives is the number of cows a player currently have
        public int kills { get; set; }                      // Number of cows this player has eliminated
        public string stage;                                // Current state of this playing between the 3 states that exists                                
        public List<Point> playedPos;                       // All points/positions that this player played
        public List<List<Point>> mill_List;                 // All the mills formed by this player
        public Ellipse[] pieces;                            // Actual pieces of this player i.e visual cows
        private int pIdx;                                   // index to identify cow in the array of cows above
        public Canvas brd;                                  // Canvas of the whole game where Controls/cows and any visual stuff must be place at

        /// <summary>
        /// Initialization at first run, instatiation/creation
        /// </summary>
        /// <param name="symbol"> Player identifier</param>
        /// <param name="brd"> Canvas </param>
        public Player(string symbol, Canvas brd)
        {
            this.symbol = symbol;
            this.brd = brd;
            pieces = createPlayerPieces();
            playedPos = new List<Point>();
            mill_List = new List<List<Point>>();
            stage = "Placing";
            lives = 12;
            kills = 0;
            pIdx = 0;
        }

        // Creation of cows/pieces
        private Ellipse[] createPlayerPieces()
        {
            Ellipse[] result = new Ellipse[12];
            int dimension = Convert.ToInt32(brd.ActualWidth / 24.7);
            for (int i = 0; i < 12; i++)
            {
                Ellipse p = new Ellipse();
                p.Height = dimension;
                p.Width = dimension;
                p.Fill = symbol == "Red" ? Brushes.Red : Brushes.Yellow;
                brd.Children.Add(p);
                result[i] = p;
            }

            return result;
        }
        
        /// <summary>
        /// Given two points, either use only 1 point p1 to place a cow in board, or use both points p1 and p2 to move a cow in the board
        /// </summary>
        /// <param name="P1"> Position to place to/ Position to move/fly from </param>
        /// <param name="P2"> Position to move/fly to </param>
        public void makeMove(Point P1 , Point P2)
        {
            if (stage == "Placing")
            {
                playedPos.Add(P1);
                Canvas.SetLeft(pieces[pIdx], (P1.X - (pieces[pIdx].ActualWidth / 2)));
                Canvas.SetTop(pieces[pIdx], (P1.Y - (pieces[pIdx].ActualHeight / 2)));
                pIdx++;
            }
            else
            {
                movePiece(P1, P2);
            }
            stage = stageUpdate();
        }

        /// <summary>
        /// Given two points, find the actual cow and change its position in the canvas
        /// </summary>
        /// <param name="pt_from"> Position to move/fly from</param>
        /// <param name="pt_to">Position to move/fly to</param>
        private void locatePiece_and_move(Point pt_from, Point pt_to)
        {
            foreach (Ellipse piece in pieces)
            {
                if((Canvas.GetLeft(piece)+ piece.ActualWidth / 2) == pt_from.X && (Canvas.GetTop(piece)+ piece.ActualWidth / 2) == pt_from.Y)
                {
                    Canvas.SetLeft(piece, (pt_to.X- (piece.ActualWidth / 2)));
                    Canvas.SetTop(piece, (pt_to.Y - (piece.ActualHeight / 2)));
                    piece.Fill = symbol == "Red" ? Brushes.Red : Brushes.Yellow;
                    return;
                }
            }
        }

        /// <summary>
        /// Given two points, locatePiece_and_move, and also updating that list of played position to remove pt_from and add pt_to 
        /// </summary>
        /// <param name="pt_from"> Position to move/fly from</param>
        /// <param name="pt_to">Position to move/fly to</param>

        public void movePiece(Point pt_from, Point pt_to)
        {
            foreach(Point point in playedPos)
            {
                if(point.Equals(pt_from))
                {
                    playedPos.Remove(point);
                    playedPos.Add(pt_to);
                    locatePiece_and_move(pt_from, pt_to);
                    break;
                }
            }
        }

        /// <summary>
        /// Update the stage of the player using index of cows already placed and number of cows left
        /// </summary>
        /// <returns> current stage</returns>
        public string stageUpdate()
        {
            stage = (pIdx>=12 ? "Moving":"Placing");
            return stage = (lives == 3 ? "Flying" : stage);
        }

        /// <summary>
        /// This player eliminate the opponent's cows, When given which cow to eliminate
        /// </summary>
        /// <param name="X"> which Player to be eliminated</param>
        /// <param name="p"> which cow to be killed</param>
        public void eliminateOpponent(Player X,Point p)
        {
            X.lives--;
            kills++;
            X.playedPos.Remove(p);
        }
        
    }
}

