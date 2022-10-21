// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236


using Windows.UI;

using Windows.UI.Xaml.Media;

namespace DodgeDots.View.Sprites
{
    /// <summary>
    /// </summary>
    public sealed partial class EnemyBallSprite
    {
        /// <summary>Gets or sets the Color.</summary>
        /// <value>The Color.</value>
        public SolidColorBrush Color { get; set; }

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnemyBallSprite" /> class.
        /// </summary>
        public EnemyBallSprite()
        {
            this.InitializeComponent();
        }

        /// <summary>Changes the color.</summary>
        /// <param name="number">The number.</param>
        public void ChangeColor(int number)
        {
            switch (number)
            {
                case 1:
                {
                    var myBrush = new SolidColorBrush(Colors.MediumPurple);
                    this.Color = myBrush;
                    this.dot.Fill = myBrush;
                    break;
                }
                case 2:
                {
                    var myBrush = new SolidColorBrush(Colors.White);
                    this.Color = myBrush;
                    this.dot.Fill = myBrush;
                    break;
                }
                case 3:
                {
                    var myBrush = new SolidColorBrush(Colors.Yellow);
                    this.Color = myBrush;
                    this.dot.Fill = myBrush;
                    break;
                }
            }
        }

        #endregion
    }
}