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

```
└── server.postman
    ├── package.json
    ├── yarn.lock
    └── api_test.json   # Postman Collection
```

Before running the REST API integration tests, ensure that the database server and ASP.NET server is running. After that, run the tests using:

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