using MediatR;
using MinimalApiWithHandlers;
using MinimalApiWithHandlers.Controllers.Testing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));
builder.Services.AddApiVersioning(opts =>
{
    opts.DefaultApiVersion = WebApiVersionsExtensions.ApiVersion090;
});

var app = builder.Build();

// prepare API versions
var apiVersionSet = app.BuildApiVersionSet();

// register API controllers with actions
app.AddTestingControllerWithActions(apiVersionSet);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();