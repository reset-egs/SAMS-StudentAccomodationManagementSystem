var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSession();
builder.Services.AddMvc();

builder.Services.AddScoped<IApartmentService, ADOApartmentService>();
builder.Services.AddScoped<IDormitoryService, ADODormitoryService>();
builder.Services.AddScoped<ILeasingService, ADOLeasingService>();
builder.Services.AddScoped<IRoomService, ADORoomService>();
builder.Services.AddScoped<IStudentService, ADOStudentService>();
builder.Services.AddScoped<IUserService, ADOUserService>();

builder.Services.AddScoped<ADOApartment>();
builder.Services.AddScoped<ADODormitory>();
builder.Services.AddScoped<ADOLeasing>();
builder.Services.AddScoped<ADORoom>();
builder.Services.AddScoped<ADOStudent>();
builder.Services.AddScoped<ADOUser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
