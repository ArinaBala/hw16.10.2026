using System;
using System.Collections.Generic;
using System.Text;

namespace hw16._10._2026
{ 
        public class Address
        {
            public string City 
        {
            get;
            set;
        }
            public string Street
        {
            get;
            set;
        }
        public string Building
        {
            get;
            set;
        }

        public Address(string city, string street, string building)
            {
                if (string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(building))
                    throw new ArgumentException("дані адреси не можуть бути порожніми.");

                City = city;
                Street = street;
                Building = building;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"адреса: м. {City}, вул. {Street}, буд. {Building}");
            }
        }

        public class Student
        {
            public int Id { get; }
            public string Name { get; set; }

            public Student(int id, string name)
            {
                if (id <= 0)
                    throw new ArgumentException("id студента повинен бути більшим за 0.", nameof(id));
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("ім'я студента не може бути порожнім.", nameof(name));

                Id = id;
                Name = name;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"[студент id: {Id}] {Name}");
            }
        }

        public class Teacher
        {
            public int Id { get; }
            public string Name { get; set; }
            public string Subject { get; set; }

            public Teacher(int id, string name, string subject)
            {
                if (id <= 0)
                    throw new ArgumentException("id викладача повинен бути більшим за 0.", nameof(id));
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("ім'я викладача не може бути порожнім.", nameof(name));
                if (string.IsNullOrWhiteSpace(subject))
                    throw new ArgumentException("предмет не може бути порожнім.", nameof(subject));

                Id = id;
                Name = name;
                Subject = subject;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"[викладач id: {Id}] {Name} (предмет: {Subject})");
            }
        }
    }

