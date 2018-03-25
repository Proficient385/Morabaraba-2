using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Morabaraba_2
{
    class Player
    {
        public string symbol { get; private set; }
        public int lives { get; set; }
        private string stage;
        public List<Point> playedPos;
        public List<Point> mill_List;
        private Ellipse[] pieces;
        private int pIdx;
        private Canvas brd;
        private Ellipse piece;

        public Player(string symbol, Ellipse piece, Canvas brd)
        {
            this.symbol = symbol;
            this.brd = brd;
            this.piece = piece;
            pieces = createPlayerPieces();
            playedPos = new List<Point>();
            mill_List = new List<Point>();
            stage = "Placing";
            lives = 12;
            pIdx = 0;
        }

        private Ellipse[] createPlayerPieces()
        {
            Ellipse[] result = new Ellipse[12];
            for (int i = 0; i < 12;i++)
            {
                Ellipse p = new Ellipse();
                p.Height = piece.ActualHeight;
                p.Width = piece.ActualWidth;
                p.Fill = piece.Fill;
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

        public string stageUpdate()
        {
            stage = (pIdx>=12 ? "Moving":"Placing");
            return stage = (lives == 3 ? "Flying" : stage);
        }
        public void eliminateOpponent(Player X)
        {
            X.lives--;
        }
    }
}

