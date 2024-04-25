internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
                            builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader()
                                   .SetIsOriginAllowed(x => true));
        }
        );

        var app = builder.Build();

        app.UseCors(builder => builder.AllowAnyHeader()
                                      .AllowAnyMethod()
                                      .SetIsOriginAllowed(x => true));

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapGet("/products", () =>
        {
            var products = Enumerable.Range(1, 5).Select(index =>
                new Product
                (
                    index,
                    "name " + index,
                    Math.Round((decimal)(index * Math.PI) * 100, 2),
                    "image..."
                ))
                .ToArray();
            return products;
        })
        .WithName("GetProducts")
        .WithOpenApi();

        app.MapGet("/cart", () =>
        {
            var products = Enumerable.Range(1, 5).Select(index =>
                new Product
                (
                    index,
                    "name " + index,
                    Math.Round((decimal)(index * Math.PI) * 100, 2),
                    "image..."
                ))
                .ToArray();
            return products;
        })
        .WithName("GetCarts")
        .WithOpenApi();

        app.Run();
    }
}

record Product (int id, string name, decimal price, string image_url){}