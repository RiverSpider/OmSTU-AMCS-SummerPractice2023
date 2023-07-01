using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
class Student
{
    public string Name = "";
    public string Group = "";
    public string Discipline = "";
    public double Mark { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = args[0]; 
        string outputFilePath = args[1]; 

        string jsonData = File.ReadAllText(inputFilePath);
        dynamic input = JsonConvert.DeserializeObject(jsonData) ?? new JObject();

        List<Student> students = input.data.ToObject<List<Student>>();
        string taskName = input.taskName;
        List<dynamic> answer;
        switch (taskName){
            case "GetStudentsWithHighestGPA":
                answer = GetStudentsWithHighestGPA(students);
                break;
            case "CalculateGPAByDiscipline":
                answer = CalculateGPAByDiscipline(students);
                break;
            case "GetBestGroupsByDiscipline":
                answer = GetBestGroupsByDiscipline(students);
                break;
            default:
                answer = new List<dynamic>();
                break;
        } 
        var result = new { Response = answer };

        string outputJson = JsonConvert.SerializeObject(result, Formatting.Indented);

        File.WriteAllText(outputFilePath, outputJson);
    }

    static List<dynamic> GetStudentsWithHighestGPA(List<Student> students)
    {
        double highestGPA = students.Max(s => s.Mark);
        var studentsWithHighestGPA = students
            .Where(s => s.Mark == highestGPA)
            .Select(s => new { Cadet = s.Name, GPA = s.Mark.ToString("0.##") })
            .Distinct()
            .ToList<dynamic>();

        return studentsWithHighestGPA;
    }

    static List<dynamic> CalculateGPAByDiscipline(List<Student> students)
    {
        var averageMarksByDiscipline = students
        .GroupBy(s => s.Discipline)
        .Select(g => new JObject(new JProperty(g.Key, g.Average(s => s.Mark))))
        .ToList<dynamic>();

        return averageMarksByDiscipline;
    }    

    static List<dynamic> GetBestGroupsByDiscipline(List<Student> students)
    {
        var bestGroupsByDiscipline = students
        .GroupBy(s => new { s.Discipline, s.Group })
        .Select(g => new
        {
            Discipline = g.Key.Discipline,
            Group = g.Key.Group,
            GPA = g.Average(s => s.Mark)
        })
        .GroupBy(g => g.Discipline)
        .Select(g => new JObject(
            new JProperty("Discipline", g.Key),
            new JProperty("Group", g.OrderByDescending(gg => gg.GPA).FirstOrDefault()?.Group),
            new JProperty("GPA", g.Max(gg => gg.GPA))
        ))
        .ToList<dynamic>();

        return bestGroupsByDiscipline;
    }   
}