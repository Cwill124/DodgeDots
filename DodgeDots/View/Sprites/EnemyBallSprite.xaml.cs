// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DodgeDots.View.Sprites
{
    /// <summary>
    /// </summary>
    public sealed partial class EnemyBallSprite
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NorthSouthBallSprite" /> class.
        /// </summary>
        public EnemyBallSprite(int colorNumber)
        {
            this.InitializeComponent();
            this.changeColor(colorNumber);
        }

        private void changeColor(int number)
        {
            if (number == 1)
            {
                var myBrush = new SolidColorBrush(Colors.Red);
                this.dot.Fill = myBrush;
            }
            else if(number == 2) {
                var myBrush = new SolidColorBrush(Colors.White);
                this.dot.Fill = myBrush;
            }
            else
            {
                var myBrush = new SolidColorBrush(Colors.Yellow);
                this.dot.Fill = myBrush;
            }
            
           
        }
        

        #endregion
    }
}