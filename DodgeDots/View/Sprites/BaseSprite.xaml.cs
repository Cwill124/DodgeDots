using System.Drawing;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DodgeDots.View.Sprites
{
    /// <summary>
    ///     Holds common functionality for all game sprites.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.UserControl" />
    public abstract partial class BaseSprite : ISpriteRenderer
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseSprite" /> class.
        /// </summary>
        protected BaseSprite()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Renders user control at the specified (x,y) location in relation
        ///     to the top, left part of the canvas.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void RenderAt(double x, double y)
        {
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
        }

        /// <summary>Determines whether the specified sprite is touching.</summary>
        /// <param name="sprite">The sprite.</param>
        /// <param name="sprite2">The sprite2.</param>
        /// <returns>
        ///     <c>true</c> if the specified sprite is touching; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTouching(BaseSprite sprite, BaseSprite sprite2)
        {
            var heightAndWidth = 30;

            var x1 = Canvas.GetLeft(sprite);
            var y1 = Canvas.GetTop(sprite);
            var rectangle = new Rectangle((int)x1, (int)y1, heightAndWidth, heightAndWidth);
            var x2 = Canvas.GetLeft(sprite2);
            var y2 = Canvas.GetTop(sprite2);
            var rectangle2 = new Rectangle((int)x2, (int)y2, heightAndWidth, heightAndWidth);
            return rectangle2.IntersectsWith(rectangle);
        }

        #endregion
    }
}