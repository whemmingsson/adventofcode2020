using System;

namespace AdventOfCode2020.Business.Day12
{
    public class Ferry
    {
        private readonly int part;

        public enum Direction
        {
            North = 78, South = 83, East = 69, West = 87,
            Left = 76, Right = 82,
            Forward = 70
        }

        public class Position
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
        public Position CurrentPosition { get; set; }

        public Position Waypoint { get; set; }

        public Ferry(int part)
        {
            this.part = part;
            CurrentDirection = Direction.East;
            CurrentPosition = new Position(0, 0);

            if (part == 2)
                Waypoint = new Position(10, -1);
        }

        internal void Move((Direction, int) ins)
        {
            bool part2 = part == 2;

            switch (ins.Item1)
            {
                case Direction.East:
                    if (part2)
                        Waypoint.X += ins.Item2;
                    else
                        CurrentPosition.X += ins.Item2;
                    break;
                case Direction.West:
                    if (part2)
                        Waypoint.X -= ins.Item2;
                    else
                        CurrentPosition.X -= ins.Item2;
                    break;
                case Direction.North:
                    if (part2)
                        Waypoint.Y -= ins.Item2;
                    else
                        CurrentPosition.Y -= ins.Item2;
                    break;
                case Direction.South:
                    if (part2)
                        Waypoint.Y += ins.Item2;
                    else
                        CurrentPosition.Y += ins.Item2;
                    break;
                case Direction.Left:
                    if (part2)
                        RotateWaypoint(Direction.Left, ins.Item2);
                    else
                        Rotate(Direction.Left, ins.Item2);
                    break;
                case Direction.Right:
                    if (part2)
                        RotateWaypoint(Direction.Right, ins.Item2);
                    else
                        Rotate(Direction.Right, ins.Item2);
                    break;
                case Direction.Forward:
                    if (part2)
                        MoveShipAndWaypoint(ins.Item2);
                    else
                        Move((CurrentDirection, ins.Item2));
                    break;
            }
        }

        private void MoveShipAndWaypoint(int reps)
        {
            bool part2 = part == 2;

            if (!part2 || Waypoint == null)
                throw new Exception();

            var deltaX = Waypoint.X - CurrentPosition.X;
            var deltaY = Waypoint.Y - CurrentPosition.Y;

            for (var i = 0; i < reps; i++)
            {
                CurrentPosition.X += deltaX;
                CurrentPosition.Y += deltaY;

                Waypoint.X += deltaX;
                Waypoint.Y += deltaY;
            }                      
        }

        public void Rotate(Direction direction, int degrees)
        {
            if (direction == Direction.Left)
                degrees = 360 - degrees;

            for (var i = 0; i < degrees / 90; i++)
            {
                CurrentDirection = Next(CurrentDirection);
            }
        }

        private void RotateWaypoint(Direction direction, int degrees)
        {
            if (direction == Direction.Left)
                degrees *= -1;

            double radians = degrees * Math.PI / 180;

            var wpXRelative = Waypoint.X - CurrentPosition.X;
            var wpYRelative = Waypoint.Y - CurrentPosition.Y;

            var wpXNew = Convert.ToInt32(wpXRelative * Math.Cos(radians) - wpYRelative * Math.Sin(radians));
            var wpYNew = Convert.ToInt32(wpXRelative * Math.Sin(radians) + wpYRelative * Math.Cos(radians));

            Waypoint = new Position(wpXNew + CurrentPosition.X, wpYNew + CurrentPosition.Y);
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
