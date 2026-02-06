# Inventory Management API

RESTful **ASP.NET Core Web API** за управление на склад, разработен с **C#**, **Entity Framework Core** и **SQLite**.  

## Функционалности

-  Създаване, четене, редактиране и изтриване на артикули
-  Търсене и филтриране по име и количество
-  Отчети за текущото състояние на склада
-  SQLite база данни с EF Core migrations
-  Автоматично seed-ване на примерни данни
-  Swagger/OpenAPI документация


## Технологии

- **.NET 10 / ASP.NET Core Web API**
- **C#**
- **Entity Framework Core**
- **SQLite**
- **Swagger**

## Структура на проекта
- Controllers → HTTP endpoints  
- Services → Бизнес логика  
- Repositories → Достъп до данни  
- Data → DbContext + Seeder  
- Models → Домейн модели  
- DTOs → Request/Response модели  
- Migrations/ → EF Core migrations  
- Program.cs → Конфигурация и DI  
- appsettings.json → Настройки

## Стартиране на проекта
1. Клониране на проекта
```
git clone https://github.com/severin29/inventory-api.git
cd inventory.api

dotnet run
```

Api-то е достъпно на:
```
http://localhost:5211
```

Може да разгледате и да тествате API ендпоинтите тук:
```
http://localhost:5211/swagger
```
| Метод  | Endpoint                | Описание                       |
| ------ | ----------------------- | ------------------------------ |
| POST   | `/api/inventory`        | Създаване на артикул           |
| GET    | `/api/inventory`        | Всички артикули (с филтриране) |
| GET    | `/api/inventory/{id}`   | Артикул по ID                  |
| PUT    | `/api/inventory/{id}`   | Редактиране                    |
| DELETE | `/api/inventory/{id}`   | Изтриване                      |
| GET    | `/api/inventory/report` | Обобщен отчет                  |

