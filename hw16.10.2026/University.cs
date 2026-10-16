using System;
using System.Collections.Generic;
using System.Text;

namespace hw16._10._2026
{
    using System;
    using System.Collections.Generic;

    namespace UniversitySystem
    {
        public class University
        {
            public string Name 
            {
                get;
                set;
            }
            public Address AddressInfo {
                get;
                private set;
            }

            private List<Teacher> _teachers;

            public University(string name, string city, string street, string building)
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("назва університету не може бути порожньою.", nameof(name));

                Name = name;
                AddressInfo = new Address(city, street, building);
                _teachers = new List<Teacher>();
            }

            public void AddTeacher(Teacher teacher)
            {
                if (teacher == null)
                    throw new ArgumentNullException(nameof(teacher), "викладач не може бути null.");

                if (_teachers.Exists(t => t.Id == teacher.Id))
                    throw new InvalidOperationException($"викладач {teacher.Name} вже працює в університеті.");

                _teachers.Add(teacher);
                Console.WriteLine($"викладача {teacher.Name} додано до університету '{Name}'.");
            }

            public void DisplayTeachers()
            {
                Console.WriteLine($"--- викладачі університету '{Name}' ---");
                if (_teachers.Count == 0)
                {
                    Console.WriteLine("викладачів поки немає.");
                    return;
                }

                foreach (var teacher in _teachers)
                {
                    teacher.DisplayInfo();
                }
            }
            public void DisplayInfo()
            {
                Console.WriteLine($"==========================================");
                Console.WriteLine($"університет: {Name}");
                AddressInfo.DisplayInfo();
                Console.WriteLine($"==========================================");
                DisplayTeachers();
            }
        }
    }
}
