using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Models;
using BashSoft.Static_data;

namespace BashSoft.Repository
{
    public class StudentsRepository : IDatabase
    {
        private bool isDataInitialized = false;
        private Dictionary<string, ICourse> coursesByName;
        private Dictionary<string, IStudent> studentsByName;
        private IDataFilter filter;
        private IDataSorter sorter;

        public StudentsRepository(IDataFilter filter, IDataSorter sorter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitilizedException);
                return;
            }

            this.coursesByName = new Dictionary<string, ICourse>();
            this.studentsByName = new Dictionary<string, IStudent>();
            this.ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.coursesByName = null;
            this.studentsByName = null;
            this.isDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = $"{SessionData.currentPath}\\{fileName}";

            if (File.Exists(path))
            {
                var pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                var rgx = new Regex(pattern);
                var allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    var inputLine = allInputLines[line];

                    if (!string.IsNullOrEmpty(inputLine) && rgx.IsMatch(inputLine))
                    {
                        var currentMatch = rgx.Match(inputLine);
                        var courseName = currentMatch.Groups[1].Value;
                        var username = currentMatch.Groups[2].Value;
                        var scoresStr = currentMatch.Groups[3].Value;

                        try
                        {
                            var scores = scoresStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                            if (scores.Any(s => s > 100 || s < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                continue;
                            }

                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.studentsByName.ContainsKey(username))
                            {
                                this.studentsByName.Add(username, new Student(username));
                            }

                            if (!this.coursesByName.ContainsKey(courseName))
                            {
                                this.coursesByName.Add(courseName, new Course(courseName));
                            }

                            var course = coursesByName[courseName];
                            var student = studentsByName[username];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);

                        }
                        catch (FormatException formatException)
                        {
                            OutputWriter.DisplayException($"{formatException.Message} at line: {line}");
                        }
                    }
                }

                this.isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                throw new InvalidPathException();
            }
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (this.isDataInitialized)
            {
                if (this.coursesByName.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentName)
        {
            if (this.IsQueryForCoursePossible(courseName) && this.coursesByName[courseName].StudentsByName.ContainsKey(studentName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (this.IsQueryForStudentPossible(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(username, this.coursesByName[courseName].StudentsByName[username].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (var studentMarksEntry in this.coursesByName[courseName].StudentsByName)
                {
                    OutputWriter.PrintStudent(new KeyValuePair<string, double>(studentMarksEntry.Key, studentMarksEntry.Value.MarksByCourseName[courseName]));
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.coursesByName[courseName].StudentsByName.Count;
                }

                var marks = this.coursesByName[courseName]
                    .StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.coursesByName[courseName].StudentsByName.Count;
                }

                var marks = this.coursesByName[courseName]
                    .StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }
    }
}