using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BashSoft.IO;
using BashSoft.Models;
using BashSoft.Static_data;

namespace BashSoft.Repository
{
    public class StudentsRepository
    {
        private bool isDataInitialized = false;
        private Dictionary<string, Course> coursesByName;
        private Dictionary<string, Student> studentsByName;
        private RepositoryFilter filter;
        private RepositorySorter sorter;

        public StudentsRepository(RepositoryFilter filter, RepositorySorter sorter)
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

            this.coursesByName = new Dictionary<string, Course>();
            this.studentsByName = new Dictionary<string, Student>();
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
                string pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    string inputLine = allInputLines[line];

                    if (!string.IsNullOrEmpty(inputLine) && rgx.IsMatch(inputLine))
                    {
                        Match currentMatch = rgx.Match(inputLine);
                        string courseName = currentMatch.Groups[1].Value;
                        string username = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;

                        try
                        {
                            int[] scores = scoresStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
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

                            Course course = coursesByName[courseName];
                            Student student = studentsByName[username];

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
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
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
            if (this.IsQueryForCoursePossible(courseName) && this.coursesByName[courseName].studentsByName.ContainsKey(studentName))
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
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(username, this.coursesByName[courseName].studentsByName[username].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (var studentMarksEntry in this.coursesByName[courseName].studentsByName)
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
                    studentsToTake = this.coursesByName[courseName].studentsByName.Count;
                }

                Dictionary<string, double> marks = this.coursesByName[courseName]
                    .studentsByName
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
                    studentsToTake = this.coursesByName[courseName].studentsByName.Count;
                }

                Dictionary<string, double> marks = this.coursesByName[courseName]
                    .studentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }
    }
}