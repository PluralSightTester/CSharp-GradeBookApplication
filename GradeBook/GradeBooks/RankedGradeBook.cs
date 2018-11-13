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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count(s => s.Grades.Any()) < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
