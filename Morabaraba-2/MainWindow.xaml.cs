using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Morabaraba_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player Player1;
        Player Player2;
        List<Point> validPos;
        string currentPlayer;
        public MainWindow()
        {
            InitializeComponent();
            currentPlayer = "Red";

            validPos = validPosiitons();
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }

        }
         
        private List<Point> validPosiitons()
        {
            List<Point> result = new List<Point>();
            // A---
            result.Add(new Point(430, 113));
            result.Add(new Point(863, 113));
            result.Add(new Point(1297, 113));
            // B--
            result.Add(new Point(575, 260));
            result.Add(new Point(863, 260));
            result.Add(new Point(1151, 260));
            // C--
            result.Add(new Point(717, 403));
            result.Add(new Point(863, 403));
            result.Add(new Point(1009, 403));
            // D---
            result.Add(new Point(430, 548));
            result.Add(new Point(575, 548));
            result.Add(new Point(717, 548));
            result.Add(new Point(1009, 548));
            result.Add(new Point(1151, 548));
            result.Add(new Point(1297, 548));
            // E--
            result.Add(new Point(717, 694));
            result.Add(new Point(863, 694));
            result.Add(new Point(1009, 694));
            // F--
            result.Add(new Point(575, 837));
            result.Add(new Point(863, 837));
            result.Add(new Point(1151, 837));
            // G--
            result.Add(new Point(430, 982));
            result.Add(new Point(863, 982));
            result.Add(new Point(1297, 982));
            return result;
        }

        private string swapPlayer(string player)
        {
            return player == "Red" ? "Yellow" : "Red";
        }
        private void Background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            Point p = Mouse.GetPosition(Background);

            foreach (Point point in validPos)
            {
                if (Math.Abs(p.X - point.X) <= 70 && Math.Abs(p.Y - point.Y) <= 70)
                {
                    p = point;
                    break;
                }
            }
            

            t.Text = string.Format("X : {0}\nY : {1}", p.X, p.Y);

            if (currentPlayer == "Red") Player1.makeMove(p);
            else Player2.makeMove(p);

            currentPlayer = swapPlayer(currentPlayer);
            // Canvas
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Player1 = new Player("Red", Piece1, Background);
            Player2 = new Player("Yellow", Piece2, Background);
        }
    }
}
