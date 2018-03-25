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
        
        public MainWindow()
        {
            InitializeComponent();
            
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }

        }
         
       
        private void Background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(Background);
            game.gamePlay(p);   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            game = new Constraints(Piece1,Piece2, Background);
        }
    }
}
