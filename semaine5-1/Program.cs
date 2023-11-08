var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/tva", (double price, String country) =>
{
    double tva = 0;

    switch (country)
    {
        case "FR":
            tva = 0.20;
            break;
        case "BE":
            tva = 0.21;
            break;
        default:
            break;
    }

    return price + tva * price;
});

app.Run();