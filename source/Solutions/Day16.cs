using AdventOfCode2020.Business;
using AdventOfCode2020.Business.Tools.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Solutions
{
    /// <summary>
    /// https://adventofcode.com/2020/day/X
    /// </summary>
    internal class Day16 : CodePuzzleSolution<string>
    {
        private TicketSheet sheet;
        public Day16(bool autoSolve = true, bool time = false) : base(new LineParser<string>(), autoSolve, time) { }

        public override void Solve()
        {
            if (!AutoSolve || Data == null || !Data.Any())
                return;

            Console.WriteLine("--- Day 16: Ticket Translation ---");
            Console.WriteLine($"Part 1: {SolveWithFun(SolvePart1)}");
            Console.WriteLine($"Part 2: {SolveWithFun(SolvePart2)}");
            Console.WriteLine("");
        }

        private int SolvePart1()
        {
            sheet = TicketSheet.Parse(Data);
            return sheet.GetErrorRateAndRemoveInvalidTickets();
        }

        private int SolvePart2()
        {
            return -1;
        }

    }

    class TicketSheet
    {
        public List<TicketInfo> TicketInfos { get; set; }
        public List<int> SantasTicket { get; set; }
        public List<List<int>> Tickets { get; set; }

        public TicketSheet()
        {
            TicketInfos = new List<TicketInfo>();
            Tickets = new List<List<int>>();
        }

        public int GetErrorRateAndRemoveInvalidTickets()
        {
            var errorRate = 0;
            List<int> invalidTicketIds = new List<int>();
            foreach(var ticket in Tickets)
            {
                var invalidNumbers = GetInvalidNumbers(ticket);
                errorRate += invalidNumbers.Sum();

                if(invalidNumbers.Count > 0)
                {
                    invalidTicketIds.Add(Tickets.IndexOf(ticket));
                }
            }

            for(var i = invalidTicketIds.Count - 1; i >= 0; i--)
            {
                Tickets.RemoveAt(invalidTicketIds[i]);
            }

            return errorRate;
        }

        public List<int> GetInvalidNumbers(List<int> ticket)
        {
            var result = new List<int>();
            foreach(var ticketNumber in ticket)
            {
                if (!TicketInfos.Any(ti => ti.ValueIsInRange(ticketNumber)))
                    result.Add(ticketNumber);
            
            }
            return result;
        }

        public static TicketSheet Parse(List<string> lines)
        {
            var sheet = new TicketSheet();

            var parsingTickets = false;
            for(int i = 0; i < lines.Count; i++)
            {
                if(i > 0 && lines[i-1].Contains("your ticket:"))
                {
                    sheet.SantasTicket = GetTicketNumbers(lines[i]);
                    continue;
                }

                if(i > 0 && lines[i - 1].Contains("nearby tickets:") || parsingTickets)
                {
                    sheet.Tickets.Add(GetTicketNumbers(lines[i]));

                    if(!parsingTickets)
                       parsingTickets = true;

                    continue;
                }

                var info = TicketInfo.Parse(lines[i]);

                if (info != null)
                    sheet.TicketInfos.Add(info);
            }

            return sheet;
        }

        private static List<int> GetTicketNumbers(string line)
        {
            return line.Split(",").Select(v => int.Parse(v)).ToList();
        }
    }

    public class TicketInfo
    {
        private static readonly Regex regex = new Regex("([\\w ]+): (\\d+)-(\\d+) or (\\d+)-(\\d+)");
        public string Label { get; set; }
        public List<NumberRange> Ranges {get;set;}

        public bool ValueIsInRange(int value)
        {
            return Ranges.Any(r => r.IsInRange(value));
        }

        public static TicketInfo Parse(string line)
        {
            if (!regex.IsMatch(line))
                return null;

            var groups = regex.Match(line).Groups;

            var ticketInfo = new TicketInfo
            {
                Label = groups[1].Value,
                Ranges = new List<NumberRange>()
            };

            ticketInfo.Ranges.Add(new NumberRange(int.Parse(groups[2].Value), int.Parse(groups[3].Value)));
            ticketInfo.Ranges.Add(new NumberRange(int.Parse(groups[4].Value), int.Parse(groups[5].Value)));

            return ticketInfo;
        }
        
    }

    public class NumberRange
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public NumberRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public bool IsInRange(int value)
        {
            return RangeValidator.IsInRange(value, Min, Max);
        }
    }
}
