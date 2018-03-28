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

        public Player(string symbol,Canvas brd)
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
            int dimension = Convert.ToInt32(brd.ActualWidth/24.7);
            for (int i = 0; i < 12;i++)
            {
                Ellipse p = new Ellipse();
                p.Height = dimension;
                p.Width = dimension;
                p.Fill = symbol=="Red"? Brushes.Red: Brushes.Yellow;
                brd.Children.Add(p);
                result[i] = p;
            }
            
            return result;
        }

        public void makeMove(Point P)
        {
            stage = stageUpdate();
            if (stage == "Placing")
            {
                playedPos.Add(P);
                Canvas.SetLeft(pieces[pIdx], (P.X - (pieces[pIdx].ActualWidth / 2)));
                Canvas.SetTop(pieces[pIdx], (P.Y - (pieces[pIdx].ActualHeight / 2)));
                pIdx++;
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

