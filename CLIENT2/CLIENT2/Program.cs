using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
class Program       //requests without await
{
    static HttpClient httpClient = new HttpClient();

    static Person GetPerson(string uri)
    {
        Person person = new Person();
        try
        {
            var response = httpClient.GetFromJsonAsync<Person>(uri);
            if (response.Result != null)
            {
                person = response.Result;
                Console.WriteLine($"Result of getting request in class-format\nName: {person?.Name}   Age: {person?.Id}");
                Console.WriteLine($"Result of getting request in JSON format\n{JsonSerializer.Serialize(person)}");
            }
            else
            {
                Console.WriteLine("Request result is NULL");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception while getting request: {ex.ToString()}");
        }
        return person;
    }

    static void Main()
    {
        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();
        for (int i = 0; i < 100; i++)
        {
            Person person1 = GetPerson("https://localhost:7121/person1");
            Person person2 = GetPerson("https://localhost:7121/person2");
            Person person3 = GetPerson("https://localhost:7121/person3");
        }
        sw.Stop();
        Console.WriteLine($"Total time taken: {sw.ElapsedMilliseconds} ms");
    }
}