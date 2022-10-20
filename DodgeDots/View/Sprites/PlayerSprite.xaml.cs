// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

using Windows.UI.Xaml.Media;
using Windows.UI;

namespace DodgeDots.View.Sprites
{
    /// <summary>
    ///     Draws the play object.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.UserControl" />
    public sealed partial class PlayerSprite
    {
        public int swap { get; set; }

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PlayerSprite" /> class.
        ///     Precondition: none
        ///     Postcondition: Sprite created.
        /// </summary>
        public PlayerSprite()
        {
            this.InitializeComponent();
            this.swap = 0;

        }


        public void SwapColors()
        {
            switch (this.swap)
            {
                case 0:
                {
                    var innerColor = new SolidColorBrush(Colors.Red);
                    this.playerInner.Fill = innerColor;
                    var outerColor = new SolidColorBrush(Colors.White);
                    this.playerOuter.Fill = outerColor;
                    this.swap = 1;
                    break;
                }
                case 1:
                {
                    var innerColor = new SolidColorBrush(Colors.White);
                    this.playerInner.Fill = innerColor;
                    var outerColor = new SolidColorBrush(Colors.Red);
                    this.playerOuter.Fill = outerColor;
                    this.swap = 0;
                    break;
                }
            }
        }

        #endregion
    }
}