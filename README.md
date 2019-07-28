# Romanum
Forum software written in ASP.NET MVC. It's not a fully completed product but contains basic structure and the most important features (creating or displaying sections/categories/topics/posts, login and registration, editing user profile).
The project is divided into several layers, which allows to separating logic and responsibility between them.

# Project structure
  * **App.MVC** - contains MVC project with all frontend.
  * **App.Services** - represents services which are associated with App.MVC (like calls to the external APIs or so).
  * **App.Services.Tests** - unit and integral tests for services contained in the App.Services project.
  * **Business.Services** - represents business services with main forum logic.
  * **Business.Services.Tests** - unit and integral tests for Business.Services.
  * **DataAccess** - contains all ORM classes (like database context, migration configuration or model classes).
  
# External APIs
  * Gravatar
  
# Used libraries:
  * **ORM**: Entity Framework
  * **DI**: Autofac
  * **Mapping**: AutoMapper
  * **Logging**: NLog
  * **Unit tests**: xUnit, Moq