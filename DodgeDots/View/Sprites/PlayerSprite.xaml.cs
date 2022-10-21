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
        /// <summary>Gets or sets the swap number.</summary>
        /// <value>The swap.</value>
        public int Swap { get; set; }

        /// <summary>Gets or sets the color.</summary>
        /// <value>The color.</value>
        public SolidColorBrush Color { get; set; }

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PlayerSprite" /> class.
        ///     Precondition: none
        ///     Postcondition: Sprite created.
        /// </summary>
        public PlayerSprite()
        {
            this.InitializeComponent();
            this.Swap = 0;
            this.Color = new SolidColorBrush(Colors.MediumPurple);
        }

        /// <summary>Swaps the colors.</summary>
        public void SwapColors()
        {
            switch (this.Swap)
            {
                case 0:
                {
                    var innerColor = new SolidColorBrush(Colors.MediumPurple);
                    this.playerInner.Fill = innerColor;
                    var outerColor = new SolidColorBrush(Colors.White);
                    this.playerOuter.Fill = outerColor;
                    this.Swap = 1;
                    this.Color = outerColor;
                    break;
                }
                case 1:
                {
                    var innerColor = new SolidColorBrush(Colors.White);
                    this.playerInner.Fill = innerColor;
                    var outerColor = new SolidColorBrush(Colors.MediumPurple);
                    this.playerOuter.Fill = outerColor;
                    this.Swap = 0;
                    this.Color = outerColor;
                    break;
                }
            }
        }

        #endregion
    }
}