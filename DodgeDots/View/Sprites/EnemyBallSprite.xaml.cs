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
            this.ChangeColor(colorNumber);
        }

        private void ChangeColor(int number)
        {
            if (number == 1)
            {
                SolidColorBrush myBrush = new SolidColorBrush(Colors.Red);
                this.dot.Fill = myBrush;
            }
            else if(number == 2) {
                SolidColorBrush myBrush = new SolidColorBrush(Colors.White);
                this.dot.Fill = myBrush;
            }
            else
            {
                SolidColorBrush myBrush = new SolidColorBrush(Colors.Yellow);
                this.dot.Fill = myBrush;
            }
            
           
        }
        

        #endregion
    }
}