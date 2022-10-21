
using DodgeDots.GameValues;
using DodgeDots.View.Sprites;


namespace DodgeDots.Model
{
    /// <summary>
    ///     creates a EnemyDot that the Player needs to dodge
    /// </summary>
    public class EnemyDot : GameObject
    {
        private const int purple = 1;
        private const int white = 2;
        private const int yellow = 3;

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
                sprite.ChangeColor(purple);
            }
            else if (direction == Direction.East || direction == Direction.West)
            {
                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.ChangeColor(white);
            }
            else
            {
                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.ChangeColor(yellow);
                SetSpeed(xSpeed, ySpeed);
            }

            SetSpeed(xSpeed, ySpeed);
        }

        #endregion
    }
}