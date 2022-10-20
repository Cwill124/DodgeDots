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
        private double backgroundWidth = 0;
        private double backgroundHeight = 0;

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
            if (this.X > leftBorder)
            {
                this.MoveLeft();
            }
        }

        /// <summary>
        ///     Moves the Player to the right.
        ///     Precondition: none
        ///     Postcondition: The Player has moved right.
        /// </summary>
        public void MovePlayerRight()
        {
            if (this.X < this.backgroundWidth - this.Width)
            {
                this.MoveRight();
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
            if (this.Y > topBorder)
            {
                this.MoveUp();
            }
        }

        /// <summary>
        ///     Moves the Player down
        ///     Precondition: none
        ///     Postcondition: The Player has moved down.
        /// </summary>
        public void MovePlayerDown()
        {
            if (this.Y < this.backgroundHeight - this.Height)
            {
                this.MoveDown();
            }
        }
        #endregion
    }
}