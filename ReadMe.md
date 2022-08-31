# TodoApi Clean

![BUILD](https://github.com/keith-marchant/todo-api-clean/actions/workflows/build.yml/badge.svg)

- [TodoApi Clean](#todoapi-clean)
  - [Summary](#summary)
    - [Specification](#specification)
      - [Specification Tooling](#specification-tooling)
      - [Specification Mocking](#specification-mocking)

## Summary

TodoApi Clean is a basic todo API written using the [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) framework with [Mediatr](https://github.com/jbogard/MediatR) handling communication between layers.

### Specification

The specification is written using [OpenAPI](https://swagger.io/specification/) and may be accessed [here](./spec/todo-api.v1.yaml).

#### Specification Tooling

I use VS Code to edit the OpenAPI YAML along with the following extensions to help navigate and render it:
- [OpenAPI Swagger Editor](https://github.com/42Crunch/vscode-openapi)
- [redoc-cli](https://github.com/Redocly/redoc)

Builds can be done by running: `redoc-cli bundle .\todo-api.v1.yaml` which will generate a redoc static html file. 

#### Specification Mocking

When building an API it can be helpful to mock the spec for the purposes of front end development, test suite generation, and demonstration purposes. To mock this spec I recommend [Prism](https://meta.stoplight.io/docs/prism/ZG9jOjky-installation)

To mock this API execute `prism mock .\todo-api.v1.yaml` and a mock server will launch at http://localhost:4010 so that you may run cURL (or other tooling of your choice) requests.

```
curl --request GET \
  --url http://localhost:4010/items/1
```

Prism will display a log of all requests and will pull responses from the examples loaded into the specification.

