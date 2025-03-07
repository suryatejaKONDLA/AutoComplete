var builder = WebApplication.CreateBuilder(args);


var jsonData = GenerateJsonData(100);
var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GeneratedData.json");
File.WriteAllText(filePath, jsonData);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(x => x.DetailedErrors = true);

builder.Services.AddScoped<GroupService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
return;

static string GenerateJsonData(int count)
{
    var records = new List<object>();
    for (var i = 1; i <= count; i++)
    {
        records.Add(new
        {
            groupId = i,
            lineOfBusiness = "TPA",
            groupNo = $"GRP{12345 + i}",
            groupName = $"Group Name {i}",
            dbaOrTradeName = $"Trade Name {i}",
            isActive = i % 2 == 0,
            isCompleted = i % 3 == 0,
            modifiedBy = "PAI\\dummy_user"
        });
    }

    return System.Text.Json.JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
}
