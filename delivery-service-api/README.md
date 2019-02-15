
# DeliveryServiceAPI

Prerequisites:
- VS2017
- .NET Framework 4.6.1
- SQL Server 2012+


Development Environment:
- Modify the database connection string as per your instance and authentication.
- Build the solution in VS.
- On Package Manager Console move to the “DeliveryService” folder (the folder containing the “DeliveryService.csproj" file) and execute these commands:
  1. `Update-Database` for updating database.
  2. Run `DeliveryService`
  3. Development server  `http://localhost:5152/`
  4. Swagger url `http://localhost:5152/swagger` can be used for API response and request

- Unit tests are aunder the `DeliveryService.Tests` class project
    1. Use VS Test Explorer to run the tests. 

- Used
    1. `Swagger` API documentation listing
    2. `EntityFramework` ORM
    3. `Autofac` DI
