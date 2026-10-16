using System;
using System.Collections.Generic;
using System.Text;

namespace hw16._10._2026
{
    
        public class Course
        {
            public static int CourseCount { get; private set; } = 0;

            public string Title { get; set; }

            private List<string> _modules;
            private List<Student> _students;

            public Course(string title, string[] initialModules)
            {
                if (string.IsNullOrWhiteSpace(title))
                    throw new ArgumentException("назва курсу не може бути порожньою.", nameof(title));

                Title = title;
                _students = new List<Student>();
                _modules = new List<string>();

                if (initialModules != null)
                {
                    foreach (var module in initialModules)
                    {
                        if (!string.IsNullOrWhiteSpace(module))
                            _modules.Add(module);
                    }
                }

                CourseCount++;
            }

            public void AddStudent(Student student)
            {
                if (student == null)
                    throw new ArgumentNullException(nameof(student), "студент не може бути null.");

                if (_students.Exists(s => s.Id == student.Id))
                    throw new InvalidOperationException($"студент {student.Name} (id: {student.Id}) вже зареєстрований на курс '{Title}'.");

                _students.Add(student);
                Console.WriteLine($"студента {student.Name} успішно додано на курс '{Title}'.");
            }

            public void RemoveStudent(int studentId)
            {
                Student studentToRemove = _students.Find(s => s.Id == studentId);
                if (studentToRemove == null)
                    throw new InvalidOperationException($"студента з id {studentId} не знайдено на курсі '{Title}'.");

                _students.Remove(studentToRemove);
                Console.WriteLine($"студента {studentToRemove.Name} видалено з курсу '{Title}'.");
            }

            public Student FindStudent(string query)
            {
                return _students.Find(s => s.Name.Equals(query, StringComparison.OrdinalIgnoreCase) || s.Id.ToString() == query);
            }

            public void DisplayStudents()
            {
                Console.WriteLine($"--- студенти курсу '{Title}' ---");
                if (_students.Count == 0)
                {
                    Console.WriteLine("на курсі немає студентів.");
                    return;
                }

                foreach (var student in _students)
                {
                    student.DisplayInfo();
                }
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"\n=== навчальний курс: {Title} ===");
                Console.WriteLine("модулі курсу (композиція):");
                foreach (var module in _modules)
                {
                    Console.WriteLine($" - {module}");
                }
                DisplayStudents();
            }
        }
    }

