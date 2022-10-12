using System;
using System.Collections.Generic;
using DodgeDots.GameValues;

namespace DodgeDots.Model
{
    /// <summary>
    ///     A wave of dots for the player to dodge
    /// </summary>
    public class DotWave
    {
        #region Data members

        private const int MinSpeed = 1;
        private const int MaxSpeed = 4;
        private readonly DirectionFacing directionFacing;
        private readonly Random random;
        public  IList<EnemyDot> dots { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="DotWave" /> class.</summary>
        /// <param name="directionFacing">The direction facing.</param>
        public DotWave(DirectionFacing directionFacing)
        {
            this.directionFacing = directionFacing;
            this.random = new Random();
            this.dots = new List<EnemyDot>();
        }

        #endregion

        #region Methods

        /// <summary>Adds the dots to the Wave.</summary>
        /// <postCondition>dots.Count == 11</postCondition>
        public void CreateDots()
        {
            if (this.directionFacing == DirectionFacing.North || this.directionFacing == DirectionFacing.South)
            {
                this.addNorthAndSouthDots();
            }
            else if (this.directionFacing == DirectionFacing.West || this.directionFacing == DirectionFacing.East)
            {
                this.addWestAndEastDots();
            }
        }
        private void addNorthAndSouthDots()
        {
            var amount = 11;
            var x = 0;
            var y = 0;
            y = this.checkForNorthOrSouth(y);
            for (var i = 0; i < amount; i++)
            {

                var random = this.random.Next(MinSpeed, MaxSpeed);
                var dot = new EnemyDot(random, random, this.directionFacing)
                {
                    X = x,
                    Y = y
                };
                this.dots.Add(dot);
                x += 40;
            }
        }

        private void addWestAndEastDots()
        {
            var amount = 11;
            var x = 0;
            var y = 0;
            x = this.checkForWestOrEast(x);
            for (var i = 0; i < amount; i++)
            {
                var random = this.random.Next(MinSpeed, MaxSpeed);
                var dot = new EnemyDot(random, random, this.directionFacing)
                {
                    X = x,
                    Y = y
                };
                this.dots.Add(dot);
                y += 40;
            }
        }

        private int checkForWestOrEast(int x)
        {
            switch (this.directionFacing)
            {
                case DirectionFacing.North:
                    x = -40;
                    break;
                case DirectionFacing.South:
                    x = 440;
                    break;
            }

            return x;
        }

        private int checkForNorthOrSouth(int y)
        {
            switch (this.directionFacing)
            {
                case DirectionFacing.North:
                    y = -10;
                    break;
                case DirectionFacing.South:
                    y = 440;
                    break;
            }

            return y;
        }

        #endregion
    }
}