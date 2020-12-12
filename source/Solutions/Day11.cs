using AdventOfCode2020.Business;
using System;
using System.Linq;

namespace AdventOfCode2020.Solutions
{
    internal class Day11 : CodePuzzleSolution<string>
    {
        private const char FLOOR = '.';
        private const char EMPTY_SEAT = 'L';
        private const char OCCUPIED_SEAT = '#';

        private int rows;
        private int columns;
        private char[,] matrix;

        public Day11(bool autoSolve = true, bool time = false) : base(11, new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 11: Seating System ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        public long SolvePart1()
        {
            matrix = CreateMatrix();

            int numChangesOfState;
            do
            {
                var clone = matrix.Clone() as char[,];
                numChangesOfState = 0;

                for (var r = 1; r < rows - 1; r++)
                {
                    for (var c = 1; c < columns - 1; c++)
                    {
                        var seat = matrix[r, c];
                        var occupiedNeighbors = NumberOfOccupiedNeighborSeats(r, c);

                        if(seat == EMPTY_SEAT && occupiedNeighbors == 0)
                        {
                            numChangesOfState++;
                            clone[r, c] = OCCUPIED_SEAT;
                        }
                        else if(seat == OCCUPIED_SEAT && occupiedNeighbors >= 4)
                        {
                            numChangesOfState++;
                            clone[r, c] = EMPTY_SEAT;
                        }
                    }
                }
                matrix = clone;
            } while (numChangesOfState > 0);

            return CountNumberOfOccupiedSeats();
        }

        public long SolvePart2()
        {
            matrix = CreateMatrix();

            int numChangesOfState;
            do
            {
                var clone = matrix.Clone() as char[,];
                numChangesOfState = 0;

                for (var r = 1; r < rows - 1; r++)
                {
                    for (var c = 1; c < columns - 1; c++)
                    {
                        var seat = matrix[r, c];
                        var occupiedNeighbors = NumberOfOccupiedVisibleSeats(r, c);

                        if (seat == EMPTY_SEAT && occupiedNeighbors == 0)
                        {
                            numChangesOfState++;
                            clone[r, c] = OCCUPIED_SEAT;
                        }
                        else if (seat == OCCUPIED_SEAT && occupiedNeighbors >= 5)
                        {
                            numChangesOfState++;
                            clone[r, c] = EMPTY_SEAT;
                        }
                    }
                }
                matrix = clone;
            } while (numChangesOfState > 0);

            return CountNumberOfOccupiedSeats();
        }

        private char[,] CreateMatrix()
        {
            columns = Data[0].Trim().Length +2;
            rows = Data.Count +2;

            var matrix = new char[rows, columns];

            for(var i = 0; i < Data.Count; i++)
            {
                var line = Data[i].Trim();
                for(var j = 0; j < line.Length;j++)
                {
                    matrix[i+1, j+1] = line[j];
                }
            }

            return matrix;
        }

        private int CountNumberOfOccupiedSeats()
        {
            int count = 0;
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 1; c < columns - 1; c++)
                {
                    if (matrix[r, c] == OCCUPIED_SEAT)
                        count++;
                }
            }

            return count;
        }

        private int NumberOfOccupiedNeighborSeats(int r, int c)
        {
            var numSeats = 0;

            if (matrix[r - 1, c] == OCCUPIED_SEAT) numSeats++;
            if (matrix[r + 1, c] == OCCUPIED_SEAT) numSeats++;
            if (matrix[r, c - 1] == OCCUPIED_SEAT) numSeats++;
            if (matrix[r, c + 1] == OCCUPIED_SEAT) numSeats++;
            if (matrix[r + 1, c + 1] == OCCUPIED_SEAT) numSeats++;
            if (matrix[r - 1, c - 1] == OCCUPIED_SEAT) numSeats++;
            if (matrix[r - 1, c + 1] == OCCUPIED_SEAT) numSeats++;
            if (matrix[r + 1, c - 1] == OCCUPIED_SEAT) numSeats++;

            return numSeats;
        }

        private int NumberOfOccupiedVisibleSeats(int r, int c)
        {
            var numSeats = 0;

            if (FindFirstSeatInLine(r, c, (r, c) => (r - 1, c)) == OCCUPIED_SEAT) numSeats++;
            if (FindFirstSeatInLine(r, c, (r, c) => (r + 1, c)) == OCCUPIED_SEAT) numSeats++;
            if (FindFirstSeatInLine(r, c, (r, c) => (r, c - 1)) == OCCUPIED_SEAT) numSeats++;
            if (FindFirstSeatInLine(r, c, (r, c) => (r, c  + 1)) == OCCUPIED_SEAT) numSeats++;
            if (FindFirstSeatInLine(r, c, (r, c) => (r + 1, c + 1)) == OCCUPIED_SEAT) numSeats++;
            if (FindFirstSeatInLine(r, c, (r, c) => (r - 1, c - 1)) == OCCUPIED_SEAT) numSeats++;
            if (FindFirstSeatInLine(r, c, (r, c) => (r - 1, c + 1)) == OCCUPIED_SEAT) numSeats++;
            if (FindFirstSeatInLine(r, c, (r, c) => (r + 1, c - 1)) == OCCUPIED_SEAT) numSeats++;

            return numSeats;
        }

        private char FindFirstSeatInLine(int r, int c, Func<int,int, (int,int)> moverFunc)
        {
            char current = FLOOR;

            while(current == FLOOR)
            {
                var newPos = moverFunc(r, c);
                r = newPos.Item1;
                c = newPos.Item2;
                current = matrix[r, c];
            }

            return current;
        }

       
    }
}
