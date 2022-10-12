using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Calls.Background;
using Windows.UI.Xaml;
using DodgeDots.GameValues;
using Windows.UI.Xaml.Controls;

namespace DodgeDots.Model
{
    /// <summary>
    ///     A wave of dots for the player to dodge
    /// </summary>
    public class DotWave
    {
        #region Data members

        private const int MinSpeed = 1;
        private const int MaxSpeed = 3;
        public Direction direction { get; }
        private readonly Random random;
        public  IList<EnemyDot> dots { get; }
        private Canvas background;


        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="DotWave" /> class.</summary>
        /// <param name="direction">The direction facing.</param>
        public DotWave(Direction direction, Canvas background)
        {
            this.direction = direction;
            this.random = new Random();
            this.dots = new List<EnemyDot>();
            this.background = background;

        }

        

        #endregion

        #region Methods

        public void CreateDot()
        {
            var random=0;
            if (this.direction == Direction.North)
            {
                random = this.random.Next(MinSpeed,MaxSpeed);
                var dot = new EnemyDot(0, random, this.direction);
                random = this.random.Next(0, 370);
                dot.X = random;
                dot.Y = -30;
                this.dots.Add(dot);
                this.background.Children.Add(dot.Sprite);
            } else if (this.direction == Direction.South)
            {
                random = this.random.Next(MinSpeed, MaxSpeed);
                var dot = new EnemyDot(0, random, this.direction);
                random = this.random.Next(0, 370);
                dot.X = random;
                dot.Y = 430;
                this.dots.Add(dot);
                this.background.Children.Add(dot.Sprite);
            }
            
        }
        

        #endregion
    }
   
}