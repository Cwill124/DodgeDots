
using DodgeDots.GameValues;
using DodgeDots.View.Sprites;


namespace DodgeDots.Model
{
    /// <summary>
    ///     creates a EnemyDot that the Player needs to dodge
    /// </summary>
    public class EnemyDot : GameObject
    {
        private const int Purple = 1;
        private const int White = 2;
        private const int Yellow = 3;

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
                sprite.ChangeColor(Purple);
            }
            else if (direction == Direction.East || direction == Direction.West)
            {
                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.ChangeColor(White);
            }
            else
            {
                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.ChangeColor(Yellow);
                SetSpeed(xSpeed, ySpeed);
            }

            SetSpeed(xSpeed, ySpeed);
        }

        #endregion
    }
}