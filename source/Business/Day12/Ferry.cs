using System;

namespace AdventOfCode2020.Business.Day12
{
    public class Ferry
    {
        public enum Direction
        {
            North = 78, South = 83, East = 69, West = 87,
            Left = 76, Right = 82,
            Forward = 70
        }

        private class Position
        {
            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }

        public Direction CurrentDirection { get; set; }
        private Position CurrentPosition { get; set; }

        public Ferry()
        {
            CurrentDirection = Direction.East;
            CurrentPosition = new Position(0, 0);
        }

        internal void Move((Direction, int) ins)
        {
            switch (ins.Item1)
            {
                case Direction.East: CurrentPosition.X += ins.Item2; break;
                case Direction.West: CurrentPosition.X -= ins.Item2; break;
                case Direction.North: CurrentPosition.Y -= ins.Item2; break;
                case Direction.South: CurrentPosition.Y += ins.Item2; break;
                case Direction.Left: Rotate(Direction.Left, ins.Item2); break;
                case Direction.Right: Rotate(Direction.Right, ins.Item2); break;
                case Direction.Forward: Move((CurrentDirection, ins.Item2)); break;
            }
        }

        private void Rotate(Direction direction, int degrees)
        {
            if (direction == Direction.Left)
                degrees = 360 - degrees;

            for (var i = 0; i < degrees / 90; i++)
            {
                CurrentDirection = Next(CurrentDirection);
            }
        }

        private Direction Next(Direction d)
        {
            if (d == Direction.North) return Direction.East;
            if (d == Direction.East) return Direction.South;
            if (d == Direction.South) return Direction.West;
            if (d == Direction.West) return Direction.North;

            return Direction.East;
        }

        public int GetTravelDistance()
        {
            return Math.Abs(CurrentPosition.X) + Math.Abs(CurrentPosition.Y);
        }
    }
}
