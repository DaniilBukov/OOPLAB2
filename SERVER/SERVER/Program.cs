var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/person1/", () => new Person("BIBKI", 18));
app.MapGet("/person2/", () => new Person("BARAN", 110));
app.MapGet("/person3/", () => new Person("UTKA", 12));

app.Run();


