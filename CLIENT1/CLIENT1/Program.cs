using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

class Program       //requests with await
{
    static async ValueTask<Person> GetPersonAsync(string uri)
    {
        Person? person = new Person();
        try
        {
            person = await httpClient.GetFromJsonAsync<Person>(uri);
            Console.WriteLine($"Result of getting request in class-format\nName: {person?.Name}   Age: {person?.Id}");
            Console.WriteLine($"Result of getting request in JSON format\n{JsonSerializer.Serialize(person)}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception while getting request: {ex.ToString()}");
        }
        return person;
    }

    static HttpClient httpClient = new HttpClient();
    static async Task Main()
    {
        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();
        for (int i = 0; i < 10; i++)
        {
            Person person1 = await GetPersonAsync("https://localhost:7121/person1");

            Person person2 = await GetPersonAsync("https://localhost:7121/person2");

            Person person3 = await GetPersonAsync("https://localhost:7121/person3");
        }
        sw.Stop();
        Console.WriteLine($"Total time taken: {sw.ElapsedMilliseconds} ms");
    }
}