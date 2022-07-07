using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Too few students for ranked grading!");
            }
            double percentileRank = (averageGrade / 100) * (Students.Count + 1);

            if (percentileRank >= 80)
            {
                return 'A';
            }
            else if (percentileRank >= 60)
            {
                return 'B';
            }
            else if (percentileRank >= 40)
            {
                return 'C';
            }
            else if (percentileRank >= 20)
            {
                return 'D';
            }
            return 'F';
        }
    }
}
