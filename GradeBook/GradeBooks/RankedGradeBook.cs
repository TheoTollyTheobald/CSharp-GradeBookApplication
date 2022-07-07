using System;
using System.Linq;
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

            // Works out how many students are in 20% - rounding up
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            // Orders all students in a list of descending grade and then takes a list of just those values
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList(); 
            // Determine if argument is greater than or equal to the grade on the border of the 20th percentile 

            if (averageGrade >= grades[threshold] - 1) // -1 because list starts at 0th element
            {
                return 'A';
            }
            else if (averageGrade >= grades[threshold*2] - 1)
            {
                return 'B';
            }
            else if (averageGrade >= grades[threshold*3] - 1)
            {
                return 'C';
            }
            else if (averageGrade >= grades[threshold*4] - 1)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
