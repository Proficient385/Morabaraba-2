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
    class Player
    {
        public string symbol { get; private set; }
        public int lives { get; set; }
        public int kills { get; set; }
        public string stage;
        public List<Point> playedPos;
        public List<List<Point>> mill_List;
        public Ellipse[] pieces;
        private int pIdx;
        public Canvas brd;

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
        
        public void placePiece(Point P1 , Point P2)
        {
            //stage = stageUpdate();
            if (stage == "Placing")
            {
                playedPos.Add(P1);
                Canvas.SetLeft(pieces[pIdx], (P1.X - (pieces[pIdx].ActualWidth / 2)));
                Canvas.SetTop(pieces[pIdx], (P1.Y - (pieces[pIdx].ActualHeight / 2)));
                pIdx++;
            }
            else if(stage=="Moving")
            {
                MessageBox.Show($"Last player {symbol} : Movements should start!");
                movePiece(P1, P2);
            }
            stage = stageUpdate();
        }

        private void locatePiece_and_move(Point pt_from, Point pt_to)
        {
            foreach (Ellipse piece in pieces)
            {
                if((Canvas.GetLeft(piece)+ piece.ActualWidth / 2) == pt_from.X && (Canvas.GetTop(piece)+ piece.ActualWidth / 2) == pt_from.Y)
                {
                    Canvas.SetLeft(piece, (pt_to.X- (piece.ActualWidth / 2)));
                    Canvas.SetTop(piece, (pt_to.Y - (piece.ActualHeight / 2)));
                    return;
                }
            }
        }
        
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

        private string stageUpdate()
        {
            stage = (pIdx>=12 ? "Moving":"Placing");
            return stage = (lives == 3 ? "Flying" : stage);
        }
        public void eliminateOpponent(Player X,Point p)
        {
            X.lives--;
            kills++;
            X.playedPos.Remove(p);
        }
        
    }
}

