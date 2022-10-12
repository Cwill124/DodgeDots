﻿using DodgeDots.GameValues;
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
        /// <param name="direction">The direction facing.</param>
        public EnemyDot(int xSpeed, int ySpeed, Direction direction)
        {
            if (direction == Direction.North || direction == Direction.South)
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