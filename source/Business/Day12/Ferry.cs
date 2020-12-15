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

        public class Position
        {
            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }

            public Position Rotate(int degrees)
            {
                double radians = degrees * Math.PI / 180;
                return new Position(Convert.ToInt32(X * Math.Cos(radians) - Y * Math.Sin(radians)), 
                                    Convert.ToInt32(X * Math.Sin(radians) + Y * Math.Cos(radians)));
            }
        }

        public Direction CurrentDirection { get; set; }
        public Position CurrentPosition { get; set; }

        public Position Waypoint { get; set; }

        public Ferry(bool useWaypoint)
        {
            CurrentDirection = Direction.East;
            CurrentPosition = new Position(0, 0);

            if (useWaypoint)
                Waypoint = new Position(10, -1);
        }

        internal void Move((Direction, int) ins)
        {
            bool hasWaypoint = Waypoint != null;

            switch (ins.Item1)
            {
                case Direction.East:
                    if (hasWaypoint)
                        Waypoint.X += ins.Item2;
                    else
                        CurrentPosition.X += ins.Item2;
                    break;
                case Direction.West:
                    if (hasWaypoint)
                        Waypoint.X -= ins.Item2;
                    else
                        CurrentPosition.X -= ins.Item2;
                    break;
                case Direction.North:
                    if (hasWaypoint)
                        Waypoint.Y -= ins.Item2;
                    else
                        CurrentPosition.Y -= ins.Item2;
                    break;
                case Direction.South:
                    if (hasWaypoint)
                        Waypoint.Y += ins.Item2;
                    else
                        CurrentPosition.Y += ins.Item2;
                    break;
                case Direction.Left:
                    if (hasWaypoint)
                        RotateWaypoint(ins.Item2 * -1);
                    else
                        Rotate(Direction.Left, ins.Item2);
                    break;
                case Direction.Right:
                    if (hasWaypoint)
                        RotateWaypoint(ins.Item2);
                    else
                        Rotate(Direction.Right, ins.Item2);
                    break;
                case Direction.Forward:
                    if (hasWaypoint)
                        MoveShipAndWaypoint(ins.Item2);
                    else
                        Move((CurrentDirection, ins.Item2));
                    break;
            }
        }

        private void MoveShipAndWaypoint(int reps)
        {
            if (Waypoint == null)
                throw new Exception();

            for (var i = 0; i < reps; i++)
            {
                CurrentPosition.X += Waypoint.X;
                CurrentPosition.Y += Waypoint.Y;
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

        private void RotateWaypoint(int degrees)
        {
            Waypoint = Waypoint.Rotate(degrees);
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
