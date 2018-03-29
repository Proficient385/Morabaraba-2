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
        Constraints game;
        Point[] moves;
        public MainWindow()
        {
            InitializeComponent();
            
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            
        }
         
       
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            game = new Constraints(Background);
            moves = new Point[] { new Point(0,0), new Point(0,0)};
        }

        private void Background_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(game.mill)
            {
                //MessageBox.Show("The is mill, first choose a cow to eliminate before continuing");
                game.messageDisplay("The is mill, first choose a \ncow to eliminate before \ncontinuing, use mouse \nleft click to kill");
                return;
            }
            Point p1 = Mouse.GetPosition(Background);

            if (moves[0].X == 0) moves[0] = p1;
            else moves[1] = p1;

            if (game.Player1.stage == "Moving" && moves[1].X==0 && game.currentPlayer=="Red")
            {
                game.player1GUI.playerTurn.Content = "Click the \nMOVE TO point";
                return;
            }
            else if (game.Player2.stage == "Moving" && moves[1].X == 0 && game.currentPlayer == "Yellow")
            {
                game.player2GUI.playerTurn.Content = "Click the \nMOVE TO point";
                return;
            }
            
            game.gamePlay(moves[0],moves[1]);
            moves[0].X = moves[0].Y = moves[1].X = moves[1].Y = 0;
            game.player1GUI.GUI_update();
            game.player2GUI.GUI_update();
        }

        private void Background_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(Background);
            if (game.mill)
            {
                game.Eliminate(p);
            }
            game.isMill();
        }
    }
}
