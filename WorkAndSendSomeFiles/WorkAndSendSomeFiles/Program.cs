var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/files", async (HttpContext context) =>
{
    var forms = context.Request.Form;

    var userName = forms["name"];
    var userAge = forms["age"];
    var userEmail = forms["email"];

    var directoryPath = $"{Directory.GetCurrentDirectory()}/uploads";
    Directory.CreateDirectory(directoryPath);

    var files = forms.Files;
    foreach (var file in files)
    {
        var fileName = $"{directoryPath}/{file.FileName}";

        await using var fileCreate = new FileStream(fileName, FileMode.Create);
        await file.CopyToAsync(fileCreate);
    }

    await context.Response.WriteAsync($"{userName} yours files uploaded");
});


app.Run();