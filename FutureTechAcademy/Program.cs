using Microsoft.Azure.Cosmos;
using FutureTechAcademy.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// --- START OF AZURE SETUP ---
var azureSettings = builder.Configuration.GetSection("AzureSettings");

// 1. Configure Cosmos DB 
CosmosClient cosmosClient = new CosmosClient(azureSettings["CosmosConnectionString"]);
var cosmosService = new CosmosService(cosmosClient, azureSettings["DatabaseName"], azureSettings["ContainerName"]);
builder.Services.AddSingleton<ICosmosService>(cosmosService);

// 2. Configure Blob Storage Service
var blobConnectionString = azureSettings["BlobConnectionString"];
var blobContainerName = azureSettings["BlobContainerName"];
builder.Services.AddSingleton<IBlobService>(new BlobService(blobConnectionString, blobContainerName));
// --- END OF AZURE SETUP ---

// --- START OF AUTHENTICATION SETUP ---
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});
// --- END OF AUTHENTICATION SETUP ---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// CRITICAL: Authentication must come before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();