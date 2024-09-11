var builder = DistributedApplication.CreateBuilder(args);

var productApi = builder.AddProject<Projects.Ecomm_Product_API>("product-api");
var orderApi = builder.AddProject<Projects.Ecomm_Order_API>("order-api");

var clientApp = builder.AddProject<Projects.Ecomm_Client>("client-app")
                       .WithReference(productApi)
                       .WithReference(orderApi);

builder.Build().Run();
