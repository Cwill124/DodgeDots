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
        public SolidColorBrush color { get; set; }
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnemyBallSprite" /> class.
        /// </summary>
        public EnemyBallSprite()
        {
            this.InitializeComponent();
            

        }

        public void changeColor(int number)
        {
            switch (number)
            {
                case 1:
                {
                    var myBrush = new SolidColorBrush(Colors.Red);
                    this.color = myBrush;
                    this.dot.Fill = myBrush;
                    break;
                }
                case 2:
                {
                    var myBrush = new SolidColorBrush(Colors.White);
                    this.color = myBrush;
                    this.dot.Fill = myBrush;
                    break;
                }
                case 3:
                {
                    var myBrush = new SolidColorBrush(Colors.Yellow);
                    this.color = myBrush;
                    this.dot.Fill = myBrush;
                    break;
                }
            }
        }
        

        #endregion
    }
}