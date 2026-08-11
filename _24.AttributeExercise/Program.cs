
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace _24.AttributeExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>()
            {
                new Student(){Age=10,Name="Tom",StudentId=001},
                new Teacher(){Age=25,Name="Lisha",TeachingMajor="Chinese"},
                new Principle(){Age=40,Name="Trump",Level="03"}
            };
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
    public class Person
    {
        public int Age { get; set; }
        public string? Name { get; set; }
        public override string ToString()
        {
            var type = GetType();
            var hasSerializableAttribute = type.IsDefined(typeof(SerializableAttribute), false);
            if (hasSerializableAttribute)
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
            return base.ToString();

        }
    }
    [Serializable]
    public class Student : Person
    {
        public int StudentId { get; set; }
    }
    [Serializable]
    public class Teacher : Person
    {
        public string? TeachingMajor { get; set; }
    }
    public class Principle : Person
    {
        public string? Level { get; set; }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class SerializableAttribute : Attribute
    {
        public SerializableAttribute()
        {
            
        }
    }
}
