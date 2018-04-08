using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Morabaraba_2
{
    /// <summary>
    /// GUI classes to initialise some of the GUI display and also updating as the game goes along
    /// </summary>
    class GUI
    {
        Player player;
        Ellipse[] pieces;
        Canvas brd;
        public Label playerTurn;                    // Who is playing
        public Label player_err_msg;                // What's the error message
        private Label player_Lives;                 // How many cows left
        private Label player_Kills;                 // How many kills yet

        /// <summary>
        /// Creates a GUI for each player
        /// </summary>
        /// <param name="player"> Which player</param>
        public GUI(Player player)
        {
            this.player = player;
            pieces = player.pieces2;
            brd = player.brd;
            playerTurn = playerTurn_label();
            player_err_msg = player_Error_Message();

            player_Lives = new Label();
            player_Kills = new Label();

            GUI_labels_allign();
            GUI_pieces_allign();
            GUI_update();
        }

        /// <summary>
        /// Given a divider, return a X-coordinate in the Canvas
        /// </summary>
        /// <param name="divider"> Magic Number</param>
        /// <returns></returns>
        private double getLeft(double divider)
        {
            return brd.ActualWidth / divider;
        }

        /// <summary>
        /// Given a divider, return a Y-coordinate in the Canvas
        /// </summary>
        /// <param name="divider"> Magic Number</param>
        /// <returns></returns>
        private double getTop(double divider)
        {
            return brd.ActualHeight / divider;
        }

        /// <summary>
        /// Get coordinates of where to initially place red pieces and place them 
        /// </summary>
        private void allign_Red_Pieces()
        {
            Canvas.SetLeft(pieces[0], -getLeft(24.7));
            Canvas.SetTop(pieces[0], getTop(1.7));
            Canvas.SetLeft(pieces[1], getLeft(85));
            Canvas.SetTop(pieces[1], getTop(1.7));
            Canvas.SetLeft(pieces[2], getLeft(15.8));
            Canvas.SetTop(pieces[2], getTop(1.7));
            Canvas.SetLeft(pieces[3], -getLeft(24.7));
            Canvas.SetTop(pieces[3], getTop(1.5));
            Canvas.SetLeft(pieces[4], getLeft(85));
            Canvas.SetTop(pieces[4], getTop(1.5));
            Canvas.SetLeft(pieces[5], getLeft(15.8));
            Canvas.SetTop(pieces[5], getTop(1.5));
            Canvas.SetLeft(pieces[6], -getLeft(24.7));
            Canvas.SetTop(pieces[6], getTop(1.33));
            Canvas.SetLeft(pieces[7], getLeft(85));
            Canvas.SetTop(pieces[7], getTop(1.33));
            Canvas.SetLeft(pieces[8], getLeft(15.8));
            Canvas.SetTop(pieces[8], getTop(1.33));
            Canvas.SetLeft(pieces[9], -getLeft(24.7));
            Canvas.SetTop(pieces[9], getTop(1.2));
            Canvas.SetLeft(pieces[10], getLeft(85));
            Canvas.SetTop(pieces[10], getTop(1.2));
            Canvas.SetLeft(pieces[11], getLeft(15.8));
            Canvas.SetTop(pieces[11], getTop(1.2));
        }

        /// <summary>
        /// Get coordinates of where to initially place yellow pieces and place them 
        /// </summary>
        private void allign_Yellow_Pieces()
        {
            Canvas.SetLeft(pieces[0], getLeft(1.13));
            Canvas.SetTop(pieces[0], getTop(1.7));
            Canvas.SetLeft(pieces[1], getLeft(1.070));
            Canvas.SetTop(pieces[1], getTop(1.7));
            Canvas.SetLeft(pieces[2], getLeft(1.015));
            Canvas.SetTop(pieces[2], getTop(1.7));
            Canvas.SetLeft(pieces[3], getLeft(1.13));
            Canvas.SetTop(pieces[3], getTop(1.5));
            Canvas.SetLeft(pieces[4], getLeft(1.070));
            Canvas.SetTop(pieces[4], getTop(1.5));
            Canvas.SetLeft(pieces[5], getLeft(1.015));
            Canvas.SetTop(pieces[5], getTop(1.5));
            Canvas.SetLeft(pieces[6], getLeft(1.13));
            Canvas.SetTop(pieces[6], getTop(1.33));
            Canvas.SetLeft(pieces[7], getLeft(1.070));
            Canvas.SetTop(pieces[7], getTop(1.33));
            Canvas.SetLeft(pieces[8], getLeft(1.015));
            Canvas.SetTop(pieces[8], getTop(1.33));
            Canvas.SetLeft(pieces[9], getLeft(1.13));
            Canvas.SetTop(pieces[9], getTop(1.2));
            Canvas.SetLeft(pieces[10], getLeft(1.070));
            Canvas.SetTop(pieces[10], getTop(1.2));
            Canvas.SetLeft(pieces[11], getLeft(1.015));
            Canvas.SetTop(pieces[11], getTop(1.2));
        }

        /// <summary>
        /// Given the current player, decide which of the 2 above function to run, as well as additional GUI elements
        /// </summary>
        private void GUI_pieces_allign()
        {
            Border boarder = new Border();
            boarder.Width = getLeft(5.7);
            boarder.Height = getTop(2.7);
            boarder.BorderThickness = new Thickness(2);

            Label player_Lbl = new Label();
            player_Lbl.Width = getLeft(8);
            player_Lbl.Height = getTop(20);
            player_Lbl.FontSize = getTop(30);
            player_Lbl.FontFamily = new FontFamily("Ravie");

            Canvas.SetTop(boarder, getTop(1.75));
            Canvas.SetTop(player_Lbl, getTop(1.05));
            brd.Children.Add(boarder);
            brd.Children.Add(player_Lbl);

            if (player.symbol == "Red")
            {
                boarder.BorderBrush = Brushes.Red;
                player_Lbl.Foreground = Brushes.Red;
                player_Lbl.Content = "Player 1";
                Canvas.SetLeft(boarder, -getLeft(18));
                Canvas.SetLeft(player_Lbl, -getLeft(30));
                allign_Red_Pieces();
            }
            else
            {
                boarder.BorderBrush = Brushes.Yellow;
                player_Lbl.Foreground = Brushes.Yellow;
                player_Lbl.Content = "Player 2";
                Canvas.SetLeft(boarder, getLeft(1.16));
                Canvas.SetLeft(player_Lbl, getLeft(1.12));
                allign_Yellow_Pieces();
            }

        }

        /// <summary>
        /// Allign labels accordingly
        /// </summary>
        private void GUI_labels_allign()
        {
            player_Lives.Width = getLeft(7);
            player_Lives.Height = getTop(15);
            player_Lives.FontSize = getTop(50);
            player_Lives.FontFamily = new FontFamily("Broadway");

            player_Kills.Width = getLeft(7);
            player_Kills.Height = getTop(15);
            player_Kills.FontSize = getTop(50);
            player_Kills.FontFamily = new FontFamily("Snap ITC");

            Canvas.SetTop(player_Lives, getTop(2));
            Canvas.SetTop(player_Kills, getTop(1.9));
            brd.Children.Add(player_Lives);
            brd.Children.Add(player_Kills);

            player_Lives.Content = "Cows remaining  : " + player.lives;
            player_Kills.Content = "Cows eliminated : " + player.kills;

            if (player.symbol == "Red")
            {
                player_Lives.Foreground = Brushes.Red;
                player_Kills.Foreground = Brushes.Yellow;
                Canvas.SetLeft(player_Lives, -getLeft(30));
                Canvas.SetLeft(player_Kills, -getLeft(30));
            }
            else
            {
                player_Lives.Foreground = Brushes.Yellow;
                player_Kills.Foreground = Brushes.Red;
                Canvas.SetLeft(player_Lives, getLeft(1.12));
                Canvas.SetLeft(player_Kills, getLeft(1.12));
            }
        }

        /// <summary>
        /// Allign labels accordingly
        /// </summary>
        private Label playerTurn_label()
        {
            Label player_Turn = new Label();
            player_Turn.Width = getLeft(4);
            player_Turn.Height = getTop(15);
            player_Turn.FontSize = getTop(50);
            player_Turn.FontFamily = new FontFamily("Wide Latin");

            Canvas.SetTop(player_Turn, getTop(8));
            brd.Children.Add(player_Turn);

            if (player.symbol == "Red")
            {
                player_Turn.Foreground = Brushes.Red;
                Canvas.SetLeft(player_Turn, -getLeft(17));
            }
            else
            {
                player_Turn.Foreground = Brushes.Yellow;
                Canvas.SetLeft(player_Turn, getLeft(1.23));
            }
            return player_Turn;
        }

        /// <summary>
        /// Allign labels accordingly
        /// </summary>
        private Label player_Error_Message()
        {
            Label player_errMsg = new Label();
            player_errMsg.Width = getLeft(4);
            player_errMsg.Height = getTop(8);
            player_errMsg.FontSize = getTop(45);
            player_errMsg.FontFamily = new FontFamily("OCR A Extended");

            Canvas.SetTop(player_errMsg, getTop(4));
            brd.Children.Add(player_errMsg);

            if (player.symbol == "Red")
            {
                player_errMsg.Foreground = Brushes.DarkOrange;
                Canvas.SetLeft(player_errMsg, -getLeft(25));
            }
            else
            {
                player_errMsg.Foreground = Brushes.DarkOrange;
                Canvas.SetLeft(player_errMsg, getLeft(1.25));
            }
            player_errMsg.Visibility = Visibility.Hidden;
            return player_errMsg;
        }

        /// <summary>
        /// Update the GUI elements as the game proceeds, the only public method in this class
        /// </summary>
        public void GUI_update()
        {
            player_Lives.Content = "Cows remaining  : " + player.lives;
            player_Kills.Content = "Cows eliminated : " + player.kills;

            string action = player.stage == "Moving" ? "'MOVE'" : "'FLY'";
            playerTurn.Content = (player.stage == "Placing" ? "Place a piece\non the board" : $"click\n a {action} from position");
        }

    }
}
