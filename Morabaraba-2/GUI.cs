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
        public GUI(Player player)
        {
            this.player = player;
            pieces = player.pieces;
            brd = player.brd;
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

    }
}
