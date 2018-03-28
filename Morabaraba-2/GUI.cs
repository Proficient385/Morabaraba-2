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
    class GUI
    {
        Player player;
        Ellipse[] pieces;
        Canvas brd;
        public Label playerTurn;
        public Label player_err_msg;

        public GUI(Player player)
        {
            this.player = player;
            pieces = player.pieces;
            brd = player.brd;
            playerTurn = GUI_gameUpdate();
            player_err_msg = player_Error_Message();
        }

        private double getLeft(double divider)
        {
            return brd.ActualWidth / divider;
        }

        private double getTop(double divider)
        {
            return brd.ActualHeight / divider;
        }
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

        public void GUI_pieces_allign()
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

        public void GUI_update()
        {
            Label player_Lives = new Label();
            player_Lives.Width = getLeft(7);
            player_Lives.Height = getTop(15);
            player_Lives.FontSize = getTop(50);
            player_Lives.FontFamily = new FontFamily("Broadway");

            Label player_Kills = new Label();
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

        public Label GUI_gameUpdate()
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
                player_Turn.Content = "Player 1 make a move";
                Canvas.SetLeft(player_Turn, -getLeft(17));
            }
            else
            {
                player_Turn.Foreground = Brushes.Yellow;
                player_Turn.Content = "Player 2 make a move";
                Canvas.SetLeft(player_Turn, getLeft(1.23));
            }
            return player_Turn;
        }

        public Label player_Error_Message()
        {
            Label player_errMsg = new Label();
            player_errMsg.Width = getLeft(4);
            player_errMsg.Height = getTop(10);
            player_errMsg.FontSize = getTop(45);
            player_errMsg.FontFamily = new FontFamily("OCR A Extended");

            Canvas.SetTop(player_errMsg, getTop(4));
            brd.Children.Add(player_errMsg);

            if (player.symbol == "Red")
            {
                player_errMsg.Foreground = Brushes.DarkOrange;
                player_errMsg.Content = "Player 1 Error Message";
                Canvas.SetLeft(player_errMsg, -getLeft(25));
            }
            else
            {
                player_errMsg.Foreground = Brushes.DarkOrange;
                player_errMsg.Content = "Player 2 Error message";
                Canvas.SetLeft(player_errMsg, getLeft(1.25));
            }
            player_errMsg.Visibility = Visibility.Hidden;
            return player_errMsg;
        }
    }
}
