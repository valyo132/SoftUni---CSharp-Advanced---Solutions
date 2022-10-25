namespace ClassroomProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Classroom
    {
        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get { return Students.Count; } }
        private List<Student> students;

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student == null)
                return "Student not found";

            Students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            if (Students.Any(x => x.Subject == subject))
            {
                var students = Students.FindAll(x => x.Subject == subject).ToArray();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var item in students)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
            => Count;

        public Student GetStudent(string firstName, string lastName)
            => Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
    }
}