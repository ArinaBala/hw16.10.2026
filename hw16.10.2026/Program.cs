using hw16._10._2026.UniversitySystem;

namespace hw16._10._2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                Student st1 = new Student(1, "олексій попов");
                Student st2 = new Student(2, "марія коваленко");
                Student st3 = new Student(3, "дмитро бондаренко");

                Teacher t1 = new Teacher(101, "олена петрівна", "вища математика");
                Teacher t2 = new Teacher(102, "іван сергійович", "програмування c#");

                University uni = new University("одеський національний університет", "одеса", "дворянська", "2");

                Course csharpCourse = new Course("об'єктно-орієнтоване програмування", new string[] { "основи ооп", "агрегація та композиція", "обробка винятків" });
                Course mathCourse = new Course("вища математика", new string[] { "лінійна алгебра", "математичний аналіз" });

                Console.WriteLine($"всього створено курсів: {Course.CourseCount}\n");

                Console.WriteLine("=== додавання викладачів (агрегація) ===");
                uni.AddTeacher(t1);
                uni.AddTeacher(t2);

                Console.WriteLine("\n=== додавання студентів на курси (агрегація) ===");
                csharpCourse.AddStudent(st1);
                csharpCourse.AddStudent(st2);
                mathCourse.AddStudent(st2);
                mathCourse.AddStudent(st3);

                Console.WriteLine();
                uni.DisplayInfo();
                csharpCourse.DisplayInfo();
                mathCourse.DisplayInfo();

                Console.WriteLine("\n=== пошук студента ===");
                Student found = csharpCourse.FindStudent("марія коваленко");
                if (found != null)
                {
                    Console.Write("знайдено студента: ");
                    found.DisplayInfo();
                }

                Console.WriteLine("\n=== спроба додати одного студента двічі ===");
                try
                {
                    csharpCourse.AddStudent(st1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[помилка перехоплена]: {ex.Message}");
                }

                Console.WriteLine("\n==================================================");
                Console.WriteLine("=== демонстрація різниці між агрегацією та композицією ===");
                Console.WriteLine("==================================================");

                csharpCourse = null;
                Console.WriteLine("1. об'єкт csharpCourse знищено.");

                Console.Write("студент 1 все ще існує незалежно від курсу: ");
                st1.DisplayInfo();

                Console.WriteLine("2. об'єкт address створювався всередині university і не має незалежного існування.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[загальна помилка]: {ex.Message}");
            }
        }
    }
}
