
# Dependencies

## axios
HTTP Library to call our REST API.

## Babel
Used to transpile our Javascript into browser compatible Javascript.

## Enzyme
Javascript testing utilities for React.

## ESLint
Linting utility. Configured to follow Airbnb's Javascript styling guide.

## Jest
Javascript testing framework.

## JSDoc
Javascript documentation generator

## Mobx
Library for application state management.

## React
Javascript library to compose UI Componenets.

## React-Router
Declarative routing for React.

## Semantic UI React
UI framework.

## Webpack
Module bundler and build tool.

# Commands

Install all dependencies:
```
yarn install
```

Start the development server:
```
yarn run dev
```

Run the linter:
```
yarn run lint
```

Run the linter and try to fix some errors:
```
yarn run lint-fix
```

Run the Jest and Enzyme unit tests:
```
yarn run test
```

Generate the documentation using JSDoc:
```
yarn run doc
```

Build the project for production:
```
yarn run publish
```

Run the Jest and Enzyme tests in Docker:
```
yarn run docker-tests
```

Build the project for production and run it in Docker:
```
yarn run docker-publish
```

Stop the production Docker server:
```
yarn run docker-stop
```