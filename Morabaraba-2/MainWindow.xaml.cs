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
        bool game_start;
        bool game_over;
        Ellipse currentPiece;
        public MainWindow()
        {
            InitializeComponent();
            
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            game_start = false;
            KeyDown += Windows_KeyDown;
        }
        
        private void gameStart()
        {
            game = new Constraints(background);
            moves = new Point[] { new Point(0, 0), new Point(0, 0) };
            game_over = false;
            game_start = true;

            Start_game.Visibility = Visibility.Hidden;
            Quit_game.Visibility = Visibility.Hidden;
            Instructions.Visibility = Visibility.Hidden;
            
            Morabaraba.Background = Brushes.Navy;
            background.Opacity = 100;
        }

        private void gameOver(GUI pgWinner, GUI pgLoser)
        {
            pgWinner.playerTurn.Visibility = Visibility.Visible;
            pgLoser.playerTurn.Visibility = Visibility.Visible;
            pgWinner.player_err_msg.Visibility = Visibility.Visible;
            pgLoser.player_err_msg.Visibility = Visibility.Visible;

            pgWinner.playerTurn.Content = "WINNER";
            pgWinner.player_err_msg.Content = "CONGRADULATION\n  you have won the game";
            pgLoser.playerTurn.Content = "LOSER";
            pgLoser.player_err_msg.Content = "You have lost the game\n  try harder next time!";

            game_over = true;
        }

        private void quitGame()
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit game", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void InstrucuntionManual()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                string path = AppDomain.CurrentDomain.BaseDirectory + @"../../Instructions.pdf";
                Uri pdf = new Uri(path, UriKind.RelativeOrAbsolute);
                process.StartInfo.FileName = pdf.LocalPath;
                process.Start();
                process.WaitForExit();
            }
            catch (Exception error)
            {
                MessageBox.Show("Could not open the file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Start_game_Click(object sender, RoutedEventArgs e)
        {
            gameStart();
        }

        private void Quit_game_Click(object sender, RoutedEventArgs e)
        {
            quitGame();
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            InstrucuntionManual();
        }

        private void Windows_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    if (!game_start) gameStart();
                    else MessageBox.Show("Game in progress, use only the mouse to play");
                    return;
                case Key.Escape:
                    quitGame();
                    return;
                case Key.I:
                    InstrucuntionManual();
                    return;
                default:
                    if (!game_start) MessageBox.Show("Press Enter to start the game, Esc to quit, or I for instructions");
                    else MessageBox.Show("Game in progress, use only the mouse to play");
                    return;
            }
        }

        private void second_Move_request(GUI pg, Point[] moves, Player player)
        {
            if (!game.player_own_Point(moves[0]))
            {
                pg.player_err_msg.Content = "Please select your own\npiece to move!";
                pg.player_err_msg.Visibility = Visibility.Visible;
                moves[0].X = moves[0].Y = 0;
                return;
            }
            moves[0] = game.pointValidation(moves[0]);

            foreach (Ellipse elp in player.pieces)
            {
                if (game.currentPlayer == "Red" && !elp.Fill.Equals(Brushes.Red)) elp.Fill = Brushes.Red;
                if (game.currentPlayer == "Yellow" && !elp.Fill.Equals(Brushes.Yellow)) elp.Fill = Brushes.Yellow;
            }

            foreach (Ellipse elp in player.pieces)
            {
                if (game.currentPlayer == "Red" && !elp.Fill.Equals(Brushes.Red)) elp.Fill = Brushes.Red;
                if (game.currentPlayer == "Yellow" && !elp.Fill.Equals(Brushes.Yellow)) elp.Fill = Brushes.Yellow;

                if (Canvas.GetLeft(elp) + (elp.ActualWidth / 2) == moves[0].X && Canvas.GetTop(elp) + (elp.ActualHeight / 2) == moves[0].Y)
                {
                    elp.Fill = game.currentPlayer=="Yellow"?Brushes.YellowGreen: Brushes.IndianRed;
                    break;
                }
            }
            pg.playerTurn.Content = "Click the \nMOVE TO point";
            pg.player_err_msg.Visibility = Visibility.Hidden;

        }

        private void Background_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!game_start)
            {
                MessageBox.Show("To start the game, first click the 'START A NEW GAME' button");
                return;
            }

            if (game.draw) return;
            if (game_over) return;
            if(game.mill)
            {
                game.messageDisplay("The is mill, first choose a \ncow to eliminate before \ncontinuing, use mouse \nleft click to kill");
                return;
            }

            Point p1 = Mouse.GetPosition(background);

            if (moves[0].X == 0) moves[0] = p1;
            else moves[1] = p1;

            if (game.Player1.stage != "Placing" && moves[1].X==0 && game.currentPlayer=="Red")
            {
                second_Move_request(game.player1GUI, moves, game.Player1);
                return;
            }
            else if (game.Player2.stage != "Placing" && moves[1].X == 0 && game.currentPlayer == "Yellow")
            {
                second_Move_request(game.player2GUI, moves, game.Player2);
                return;
            }
            
            game.gamePlay(moves[0],moves[1]);
            moves[0].X = moves[0].Y = moves[1].X = moves[1].Y = 0;

            if (game.draw) return;
            game.player1GUI.GUI_update();
            game.player2GUI.GUI_update();
        }

        private void Background_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(!game_start)
            {
                MessageBox.Show("To start the game, first click the 'START A NEW GAME' button");
                return;
            }
            if (game.draw) return;
            if (game_over) return;
            Point p = Mouse.GetPosition(background);
            if (game.mill)
            {
                game.Eliminate(p);

                if(game.Player1.lives==2)
                {
                    gameOver(game.player2GUI, game.player1GUI);
                }
                if(game.Player2.lives==2)
                {
                    gameOver(game.player1GUI, game.player2GUI);
                }
            }
            game.isMill();
        }

        

        
    }
}
