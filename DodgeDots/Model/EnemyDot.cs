
using DodgeDots.GameValues;
using DodgeDots.View.Sprites;


namespace DodgeDots.Model
{
    /// <summary>
    ///     creates a EnemyDot that the Player needs to dodge
    /// </summary>
    public class EnemyDot : GameObject
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="EnemyDot" /> class.</summary>
        /// <param name="xSpeed">The x speed.</param>
        /// <param name="ySpeed">The y speed.</param>
        /// <param name="direction">The Direction facing.</param>
        public EnemyDot(int xSpeed, int ySpeed, Direction direction)
        {
            if (direction == Direction.North || direction == Direction.South)
            {
                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.ChangeColor(1);
            }
            else if (direction == Direction.East || direction == Direction.West)
            {
                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.ChangeColor(2);
            }
            else
            {
                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.ChangeColor(3);
                SetSpeed(xSpeed, ySpeed);
            }

            SetSpeed(xSpeed, ySpeed);
        }

        #endregion
    }
}