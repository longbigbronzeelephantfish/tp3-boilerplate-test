# Typical Workflow

1) Ensure that database server is running.
2) Work on project in Visual Studio 2017.
3) Run unit tests and integration tests.
4) Commit and push to repository.

# Development

Resources
- ASP.NET Core Documentation https://docs.microsoft.com/en-us/aspnet/core/
- ASP.NET Core REST API
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api
- Entity Framework Core Documentation https://docs.microsoft.com/en-us/ef/core/

# Testing

Resources
- xUnit Unit Testing https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
- ASP.NET Core Testing https://docs.microsoft.com/en-us/aspnet/core/testing/
- Moq Mocking Tutorial https://github.com/Moq/moq4/wiki/Quickstart
- Postman Documentation https://www.getpostman.com/docs/

# Documentation

Resources
- C# XML Documentation Comments https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments
- Swagger https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger

# Projects

## server

Contains the main ASP.NET Core project. Before running this project, ensure that the database server is running. After that, run using Visual Studio or:

```
sh run dev
```

## server.tests

Contains the xUnit and Moq unit testing project. Run the tests using Visual Studio or:

```
sh run test
```

## server.postman

Contains the Postman integration tests. Run using Node Package Manager.

``` sh
└── server.postman
    ├── package.json
    ├── yarn.lock
    └── api_test.json   # Postman Collection
```

Before running the REST API integration tests, ensure that the database server and ASP.NET server is running. After that, run the tests using Postman or:

```
sh run postman-test
```

# Commands

Install all dependencies:
```
sh run install
```

Clean the project directories:
```
sh run clean
```

Start the development server:
```
sh run dev
```

Run the xUnit/Moq unit tests:
```
sh run test
```

Run the Postman REST API integration tests using Newman:
```
sh run postman-test
```

Build the project for production:
```
sh run publish
```

Run the unit tests in Docker:
```
sh run docker-test
```

Build the project for production and run it in Docker:
```
sh run docker-publish
```

Stop the production Docker server:
```
sh run docker-stop
```