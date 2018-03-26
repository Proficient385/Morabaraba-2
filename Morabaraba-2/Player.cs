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
        private string stage;
        public List<Point> playedPos;
        public List<List<Point>> mill_List;
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
            GUI_pieces_allign();
            playedPos = new List<Point>();
            mill_List = new List<List<Point>>();
            stage = "Placing";
            lives = 12;
            pIdx = 0;
        }

        private void allign_Red_Pieces()
        {
            Canvas.SetLeft(pieces[0], -70);
            Canvas.SetTop(pieces[0], brd.ActualHeight / 1.7);
            Canvas.SetLeft(pieces[1], 20);
            Canvas.SetTop(pieces[1], brd.ActualHeight / 1.7);
            Canvas.SetLeft(pieces[2], 110);
            Canvas.SetTop(pieces[2], brd.ActualHeight / 1.7);
            Canvas.SetLeft(pieces[3], -70);
            Canvas.SetTop(pieces[3], brd.ActualHeight / 1.5);
            Canvas.SetLeft(pieces[4], 20);
            Canvas.SetTop(pieces[4], brd.ActualHeight / 1.5);
            Canvas.SetLeft(pieces[5], 110);
            Canvas.SetTop(pieces[5], brd.ActualHeight / 1.5);
            Canvas.SetLeft(pieces[6], -70);
            Canvas.SetTop(pieces[6], brd.ActualHeight / 1.33);
            Canvas.SetLeft(pieces[7], 20);
            Canvas.SetTop(pieces[7], brd.ActualHeight / 1.33);
            Canvas.SetLeft(pieces[8], 110);
            Canvas.SetTop(pieces[8], brd.ActualHeight / 1.33);
            Canvas.SetLeft(pieces[9], -70);
            Canvas.SetTop(pieces[9], brd.ActualHeight / 1.2);
            Canvas.SetLeft(pieces[10], 20);
            Canvas.SetTop(pieces[10], brd.ActualHeight / 1.2);
            Canvas.SetLeft(pieces[11], 110);
            Canvas.SetTop(pieces[11], brd.ActualHeight / 1.2);
        }

        private void allign_Yellow_Pieces()
        {
            Canvas.SetLeft(pieces[0], brd.ActualWidth/1.13);
            Canvas.SetTop(pieces[0], brd.ActualHeight / 1.7);
            Canvas.SetLeft(pieces[1], brd.ActualWidth / 1.070);
            Canvas.SetTop(pieces[1], brd.ActualHeight / 1.7);
            Canvas.SetLeft(pieces[2], brd.ActualWidth / 1.015);
            Canvas.SetTop(pieces[2], brd.ActualHeight / 1.7);
            Canvas.SetLeft(pieces[3], brd.ActualWidth / 1.13);
            Canvas.SetTop(pieces[3], brd.ActualHeight / 1.5);
            Canvas.SetLeft(pieces[4], brd.ActualWidth / 1.070);
            Canvas.SetTop(pieces[4], brd.ActualHeight / 1.5);
            Canvas.SetLeft(pieces[5], brd.ActualWidth / 1.015);
            Canvas.SetTop(pieces[5], brd.ActualHeight / 1.5);
            Canvas.SetLeft(pieces[6], brd.ActualWidth / 1.13);
            Canvas.SetTop(pieces[6], brd.ActualHeight / 1.33);
            Canvas.SetLeft(pieces[7], brd.ActualWidth / 1.070);
            Canvas.SetTop(pieces[7], brd.ActualHeight / 1.33);
            Canvas.SetLeft(pieces[8], brd.ActualWidth / 1.015);
            Canvas.SetTop(pieces[8], brd.ActualHeight / 1.33);
            Canvas.SetLeft(pieces[9], brd.ActualWidth / 1.13);
            Canvas.SetTop(pieces[9], brd.ActualHeight / 1.2);
            Canvas.SetLeft(pieces[10], brd.ActualWidth / 1.070);
            Canvas.SetTop(pieces[10], brd.ActualHeight / 1.2);
            Canvas.SetLeft(pieces[11], brd.ActualWidth / 1.015);
            Canvas.SetTop(pieces[11], brd.ActualHeight / 1.2);
        }

        private void GUI_pieces_allign()
        {
            Border boarder = new Border();
            boarder.Width = brd.ActualWidth / 5.7;
            boarder.Height = brd.ActualHeight / 2.7;
            Canvas.SetTop(boarder, brd.ActualHeight / 1.75);
            boarder.BorderThickness = new Thickness(2);
            brd.Children.Add(boarder);

            if (symbol == "Red")
            {
                boarder.BorderBrush = Brushes.Red;
                Canvas.SetLeft(boarder, -90);
                allign_Red_Pieces();
            }
            else
            {
                boarder.BorderBrush = Brushes.Yellow;
                Canvas.SetLeft(boarder, brd.ActualWidth / 1.15);
                allign_Yellow_Pieces();
            }

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

        private string stageUpdate()
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

