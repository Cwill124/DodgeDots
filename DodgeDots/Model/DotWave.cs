using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Calls.Background;
using Windows.UI.Xaml;
using DodgeDots.GameValues;
using Windows.UI.Xaml.Controls;

namespace DodgeDots.Model
{
    /// <summary>
    ///     A wave of dots for the Player to dodge
    /// </summary>
    public class DotWave
    {
        #region Data members

        private const int MinSpeed = 1;
        private const int MaxSpeed = 4;
        public Direction direction { get; }
        private readonly Random random;
        public  IList<EnemyDot> dots { get; }
        private readonly Canvas background;


        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="DotWave" /> class.</summary>
        /// <param name="direction">The direction facing.</param>
        /// <param name="background"></param>
        public DotWave(Direction direction, Canvas background)
        {
            this.direction = direction;
            this.random = new Random();
            this.dots = new List<EnemyDot>();
            this.background = background;

        }



        #endregion

        #region Methods

        /// <summary>Creates a dot for the collection that calls it .</summary>
        public void CreateDot()
        {
            if (this.direction == Direction.North)
            {
                this.makeNorthDot();
            }
            else if (this.direction == Direction.West)
            {
                this.makeWestDot();
            }
            else if (this.direction == Direction.South)
            {
                this.makeSouthDot();
            }
            else if (this.direction == Direction.East)
            {
                this.makeEastDot();
            } else if (this.direction == Direction.BlitzNorth)
            {
                this.makeNorthDot();
                
            } else if (this.direction == Direction.BlitzSouth)
            {
                this.makeSouthDot();
            }
        }

       

        private void makeEastDot()
        {
            var random = this.random.Next(MinSpeed, MaxSpeed);
            var dot = new EnemyDot(random, 0, this.direction);
            random = this.random.Next(0, 370);
            dot.X = 430;
            dot.Y = random;
            this.dots.Add(dot);
            this.background.Children.Add(dot.Sprite);
        }

        private void makeSouthDot()
        {
            var random = this.random.Next(MinSpeed, MaxSpeed);
            var dot = new EnemyDot(0, random, this.direction);
            random = this.random.Next(0, 370);
            dot.X = random;
            dot.Y = 430;
            this.dots.Add(dot);
            this.background.Children.Add(dot.Sprite);
        }

        private void makeWestDot()
        {
            var random = this.random.Next(MinSpeed, MaxSpeed);
            var dot = new EnemyDot(random, 0, this.direction);
            random = this.random.Next(0, 370);
            dot.X = -30;
            dot.Y = random;
            this.dots.Add(dot);
            this.background.Children.Add(dot.Sprite);
        }

        private void makeNorthDot()
        {
            var random = this.random.Next(MinSpeed, MaxSpeed);
            var dot = new EnemyDot(0, random, this.direction);
            random = this.random.Next(0, 370);
            dot.X = random;
            dot.Y = -30;
            this.dots.Add(dot);
            this.background.Children.Add(dot.Sprite);
        }
        

        #endregion
    }
   
} 