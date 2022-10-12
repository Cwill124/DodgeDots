using DodgeDots.GameValues;
using DodgeDots.View.Sprites;

namespace DodgeDots.Model
{
    /// <summary>
    ///     creates a EnemyDot that the player needs to dodge
    /// </summary>
    public class EnemyDot : GameObject
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="EnemyDot" /> class.</summary>
        /// <param name="xSpeed">The x speed.</param>
        /// <param name="ySpeed">The y speed.</param>
        /// <param name="directionFacing">The direction facing.</param>
        public EnemyDot(int xSpeed, int ySpeed, DirectionFacing directionFacing)
        {
            if (directionFacing == DirectionFacing.North || directionFacing == DirectionFacing.South)
            {
                Sprite = new NorthSouthBallSprite();
            }
            else
            {
                Sprite = new WestEastBallSprite();
            }

            SetSpeed(xSpeed, ySpeed);
        }

        #endregion
    }
}