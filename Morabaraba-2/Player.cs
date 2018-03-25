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
        Ellipse Piece1;

        public Player(string symbol, Ellipse Piece1)
        {
            this.symbol = symbol;
            this.Piece1 = Piece1;
            playedPos = new List<Point>();
            mill_List = new List<Point>();
            stage = "Placing";
            lives = 12;
        }

        public void makeMove(Point P)
        {

           
        }

        public void eliminateOpponent(Player X)
        {
           
        }
    }
}

