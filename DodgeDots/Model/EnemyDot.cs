using System.Drawing;
using Windows.UI;
using Windows.UI.Xaml.Media;
using DodgeDots.GameValues;
using DodgeDots.View.Sprites;
using Color = Windows.UI.Color;

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
        /// <param name="direction">The direction facing.</param>
        public EnemyDot(int xSpeed, int ySpeed, Direction direction)
        {
            if (direction == Direction.North || direction == Direction.South)
            {

                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.changeColor(1);



            }
            else if(direction == Direction.East || direction == Direction.West)
            {
                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.changeColor(2);

            }
            else
            {
                Sprite = new EnemyBallSprite();
                var sprite = (EnemyBallSprite)Sprite;
                sprite.changeColor(3);
                SetSpeed(xSpeed, ySpeed);
            }

            SetSpeed(xSpeed, ySpeed);
        }

        #endregion
    }
}