using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int studentsWithLowerGrades = Students.Count(s => s.AverageGrade < averageGrade);

            double percentageStudentsWithLowerGrades = (double)studentsWithLowerGrades / Students.Count * 100;
            if (percentageStudentsWithLowerGrades >= 80)
            {
                return 'A';
            }
            else if(percentageStudentsWithLowerGrades >= 60)
            {
                return 'B';
            }
            else if (percentageStudentsWithLowerGrades >= 40)
            {
                return 'C';
            }
            else if (percentageStudentsWithLowerGrades >= 20)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
