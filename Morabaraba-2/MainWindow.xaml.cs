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

        private void second_Move_request(GUI pg, Point[] moves)
        {
            if (!game.player_own_Point(moves[0]))
            {
                pg.player_err_msg.Content = "Please select your own\npiece to move!";
                pg.player_err_msg.Visibility = Visibility.Visible;
                moves[0].X = moves[0].Y = 0;
                return;
            }
            pg.playerTurn.Content = "Click the \nMOVE TO point";
            pg.player_err_msg.Visibility = Visibility.Hidden;
           
        }
        private void Background_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(game.mill)
            {
                game.messageDisplay("The is mill, first choose a \ncow to eliminate before \ncontinuing, use mouse \nleft click to kill");
                return;
            }
            Point p1 = Mouse.GetPosition(Background);

            if (moves[0].X == 0) moves[0] = p1;
            else moves[1] = p1;

            if (game.Player1.stage == "Moving" && moves[1].X==0 && game.currentPlayer=="Red")
            {
                second_Move_request(game.player1GUI, moves);
                return;
            }
            else if (game.Player2.stage == "Moving" && moves[1].X == 0 && game.currentPlayer == "Yellow")
            {
                second_Move_request(game.player2GUI, moves);
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
