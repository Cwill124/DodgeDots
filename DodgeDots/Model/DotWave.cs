using System;
using System.Collections.Generic;
using DodgeDots.GameValues;
using Windows.UI.Xaml.Controls;

namespace DodgeDots.Model
{
    /// <summary>
    ///     A wave of Dots for the Player to dodge
    /// </summary>
    public class DotWave
    {
        #region Data members

        private const int MinSpeed = 2;
        private const int MaxSpeed = 5;
        /// <summary>Gets the direction.</summary>
        /// <value>The direction.</value>
        public Direction Direction { get; }
        private readonly Random random;
        /// <summary>Gets the dots.</summary>
        /// <value>The dots.</value>
        public IList<EnemyDot> Dots { get; }
        private readonly Canvas background;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="DotWave" /> class.</summary>
        /// <param name="direction">The Direction facing.</param>
        /// <param name="background"></param>
        public DotWave(Direction direction, Canvas background)
        {
            this.Direction = direction;
            this.random = new Random();
            this.Dots = new List<EnemyDot>();
            this.background = background;
        }

        #endregion

        #region Methods

        /// <summary>Creates a dot for the collection that calls it .</summary>
        public void CreateDot()
        {
            if (this.Direction == Direction.North)
            {
                this.makeNorthDot();
            }
            else if (this.Direction == Direction.West)
            {
                this.makeWestDot();
            }
            else if (this.Direction == Direction.South)
            {
                this.makeSouthDot();
            }
            else if (this.Direction == Direction.East)
            {
                this.makeEastDot();
            }
            else if (this.Direction == Direction.BlitzNorth)
            {
                this.makeNorthDot();
            }
            else if (this.Direction == Direction.BlitzSouth)
            {
                this.makeSouthDot();
            }
        }

        private void makeEastDot()
        {
            var random = this.random.Next(MinSpeed, MaxSpeed);
            var dot = new EnemyDot(random, 0, this.Direction);
            random = this.random.Next(0, 370);
            dot.X = 430;
            dot.Y = random;
            this.Dots.Add(dot);
            this.background.Children.Add(dot.Sprite);
        }

        private void makeSouthDot()
        {
            var random = this.random.Next(MinSpeed, MaxSpeed);
            var dot = new EnemyDot(0, random, this.Direction);
            random = this.random.Next(0, 370);
            dot.X = random;
            dot.Y = 430;
            this.Dots.Add(dot);
            this.background.Children.Add(dot.Sprite);
        }

        private void makeWestDot()
        {
            var random = this.random.Next(MinSpeed, MaxSpeed);
            var dot = new EnemyDot(random, 0, this.Direction);
            random = this.random.Next(0, 370);
            dot.X = -30;
            dot.Y = random;
            this.Dots.Add(dot);
            this.background.Children.Add(dot.Sprite);
        }

        private void makeNorthDot()
        {
            var random = this.random.Next(MinSpeed, MaxSpeed);
            var dot = new EnemyDot(0, random, this.Direction);
            random = this.random.Next(0, 370);
            dot.X = random;
            dot.Y = -30;
            this.Dots.Add(dot);
            this.background.Children.Add(dot.Sprite);
        }

        #endregion
    }
}