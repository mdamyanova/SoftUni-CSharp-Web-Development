using System;
using System.Collections.Generic;
using System.Linq;
using BashSoft.IO;
using BashSoft.Static_data;

namespace BashSoft.Repository
{
    public class RepositoryFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.50, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int printedStudentsCounter = 0;
            foreach (var studentMark in studentsWithMarks)
            {
                if (printedStudentsCounter == studentsToTake)
                {
                    break;
                }

                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(new KeyValuePair<string, double>(studentMark.Key, studentMark.Value));
                    printedStudentsCounter++;
                }
            }
        }

        private double Average(List<int> scoresOnTask)
        {
            double totalScore = scoresOnTask.Sum();
            double percentageOfAll = totalScore / scoresOnTask.Count / 100.0;
            double mark = percentageOfAll * 4 + 2;

            return mark;
        }
    }
}