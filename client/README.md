# Typical Workflow

1) Ensure that the database server is running.
2) Ensure that the backend server is running.
3) Run the frontend development server:
```sh
yarn run dev
```
4) Work on the project in your text editor.
5) Changes to any files will cause Webpack to recompile the application automatically.
4) Run unit tests:
```sh
yarn run test
```
5) Run ESLint linter and fix linting errors.
```sh
yarn run lint
yarn run lint-fix
```
6) Commit and push to repository

# Development

## Development Server

The Webpack development server can be run using:

``` sh
yarn run dev
```

It is configured to hot reload. This means that changes to any project files will trigger Webpack to automatically recompiled the application.

## Javascript

ECMAScript 2015, 2016 and 2017 can all be used as Babel will transpile them down to browser comptaible ECMAScript 5

- Javascript Tutorial and Reference https://developer.mozilla.org/bm/docs/Web/JavaScript
- Online Javascirpt development environment https://codepen.io/

## Javascript Styling

Javascript should be written to follow Airbnb's Javascript style guide

- Airbnb Javascript style guide https://github.com/airbnb/javascript

The styling can be enforced by running ESLint.

## React

Resources
 - Tutorial https://reactjs.org/tutorial/tutorial.html
 - Documentation https://reactjs.org/docs/hello-world.html

## React-Router

Resources
 - Tutorial https://reacttraining.com/react-router/web/example/basic

## Mobx

Resources
 - Tutorial https://mobx.js.org/getting-started.html

## Semantic UI React

Resources
 - Reference https://react.semantic-ui.com/introduction

# Testing

Testing is done using Jest and Enzyme.

Jest
 - React Tutorial http://facebook.github.io/jest/docs/en/tutorial-react.html
 - Mock Functions https://facebook.github.io/jest/docs/en/mock-functions.html
 - Manual Mocks http://facebook.github.io/jest/docs/en/manual-mocks.html
 - API Reference http://facebook.github.io/jest/docs/en/api.html

Enzyme
 - React Tutorial http://facebook.github.io/jest/docs/en/tutorial-react.html
 - Shallow Rendering API Reference http://airbnb.io/enzyme/docs/api/shallow.html
 - API Reference http://airbnb.io/enzyme/docs/api/

# Linting

Linting is done using ESLint. It is configured to follow Airbnb's Javascript styling guide with some minor modifications. 

- ESLint Webpage https://eslint.org/
- Airbnb Javascript Style Guide https://github.com/airbnb/javascript

``` sh
yarn run lint
yarn run lint-fix
```

# Documentation

Javascript documentation can be generated using JSDoc. http://usejsdoc.org/

 - JSDoc Webpage http://usejsdoc.org/
 - ES 2015 Classes Tutorial http://usejsdoc.org/howto-es2015-classes.html
 - ES 2015 Modules Tutorial http://usejsdoc.org/howto-es2015-modules.html
 - JSDoc Block Tags http://usejsdoc.org/

``` sh
yarn run doc
```

# Dependencies and Tools

## axios
HTTP Library to call our REST API.

## Babel
Javascript transpiler.

## Enzyme
Javascript testing utilities for React.

## ESLint
Linting utility.

## Jest
Javascript testing framework.

## JSDoc
Javascript documentation generator.

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

# Folder Structure

``` sh
├── src                         # Folder containing the source code
├── .babelrc                    # Babel configuration file
├── .dockerignore               # Docker will ignore the files and folders in this file
├── .eslintrc.json              # ESLint configuration file
├── .gitignore                  # Git will ignore the files and folders in this file
├── Dockerfile.Compose          # Dockerfile for docker-compose
├── Dockerfile.Production       # Dockerfile for production
├── Dockerfile.Testing          # Dockerfile for testing
├── jsdoc.conf                  # JSDoc configuration file
├── package.json                # NPM configuration file
├── README.md                   # This file
├── run                         # Utility script to run docker commands
├── secrets.json                # Generated secrets file
├── secrets.json.sample         # Template secrets file. Do not edit
├── tests.setup                 # Jest/Enzyme setup file
├── webpack.common.js           # Webpack config file for all environments
├── webpack.dev.js              # Webpack config file for development
├── webpack.prod.js             # Webpack config file for production
└── yarn.lock                   # Yarn file to track dependencies
```

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
``` sh
sh run docker-tests
yarn run docker-tests   # This command will run "sh run docker-tests"
```

Build the project for production and run it in Docker:
``` sh
sh run docker-publish
yarn run docker-publish # This command will run "sh run docker-publish"
```

Stop the production Docker server:
``` sh
sh run docker-stop
yarn run docker-stop    # This command will run "sh run docker-stop"
```