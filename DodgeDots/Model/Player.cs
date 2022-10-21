using DodgeDots.View.Sprites;

namespace DodgeDots.Model
{
    /// <summary>
    ///     Manages the Player.
    /// </summary>
    /// <seealso cref="DodgeDots.Model.GameObject" />
    public class Player : GameObject
    {
        #region Data members

        private const int SpeedXDirection = 3;
        private const int SpeedYDirection = 3;
        private readonly double backgroundWidth;
        private readonly double backgroundHeight;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        public Player(double backgroundWidth, double backgroundHeight)
        {
            Sprite = new PlayerSprite();
            SetSpeed(SpeedXDirection, SpeedYDirection);
            this.backgroundWidth = backgroundWidth;
            this.backgroundHeight = backgroundHeight;
        }

        /// <summary>
        ///     Moves the Player to the left.
        ///     Precondition: none
        ///     Postcondition: The Player has moved left.
        /// </summary>
        public void MovePlayerLeft()
        {
            var leftBorder = 0;
            if (X > leftBorder)
            {
                MoveLeft();
            }
        }

        /// <summary>
        ///     Moves the Player to the right.
        ///     Precondition: none
        ///     Postcondition: The Player has moved right.
        /// </summary>
        public void MovePlayerRight()
        {
            if (X < this.backgroundWidth - Width)
            {
                MoveRight();
            }
        }

        /// <summary>
        ///     Moves the Player up
        ///     Precondition: none
        ///     Postcondition: The Player has moved up.
        /// </summary>
        public void MovePlayerUp()
        {
            var topBorder = 0;
            if (Y > topBorder)
            {
                MoveUp();
            }
        }

        /// <summary>
        ///     Moves the Player down
        ///     Precondition: none
        ///     Postcondition: The Player has moved down.
        /// </summary>
        public void MovePlayerDown()
        {
            if (Y < this.backgroundHeight - Height)
            {
                MoveDown();
            }
        }

        /// <summary>Swaps the color.</summary>
        public void SwapColor()
        {
            var sprite = (PlayerSprite)Sprite;
            sprite.SwapColors();
        }

        #endregion
    }
}