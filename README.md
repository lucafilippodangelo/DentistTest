---
services: app-service\web,app-service
platforms: dotnet
author: Luca D'Angelo
---

# ASP.NET and SQL Database for Azure App Service - Dentist Test App

Test
[Create an ASP.NET app in Azure with SQL Database](https://docs.microsoft.com/en-us/azure/app-service-web/app-service-web-tutorial-dotnet-sqldatabase/). 

## License

See [LICENSE](LICENSE).

## Contributing

### DONE:
- enable migrations in azure (it's possible to access using credentials and endpoint provided in azure)
  - https://docs.microsoft.com/en-us/azure/app-service/app-service-web-tutorial-dotnet-sqldatabase

### DOING:
- DB migrations updated but scaffolding not working and nNtoN not working
  need to implement 
  - https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
  - https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/reading-related-data-with-the-entity-framework-in-an-asp-net-mvc-application
  used in last push using "Entity Framework Core": https://blog.oneunicorn.com/2017/09/25/many-to-many-relationships-in-ef-core-2-0-part-1-the-basics/

### TO DO:
- SignalR
  - https://github.com/aspnet/SignalR-samples
  - https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-2.2
- controller actions
  - https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/controller-methods-views?view=aspnetcore-2.2
- modeling relationships
  - https://docs.microsoft.com/en-us/ef/core/modeling/relationships
  - https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-inheritance-with-the-entity-framework-in-an-asp-net-mvc-application
- seed data
  - https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-2.2&tabs=visual-studio
- authentication and authorization (read only)
  - https://docs.microsoft.com/en-us/aspnet/core/signalr/authn-and-authz?view=aspnetcore-2.2
- add Validations
  - https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/validation?view=aspnetcore-2.2
  - https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/handling-concurrency-with-the-entity-framework-in-an-asp-net-mvc-application
- add Search
  - https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/search?view=aspnetcore-2.2
- client and server side validations
  - https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2
- pagination
  - https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-2.2
- concurrency
  - https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/handling-concurrency-with-the-entity-framework-in-an-asp-net-mvc-application

