# TogetherHub (.NET Core + CQRS)

## 📌 Описание проекта

**TogetherHub** — это backend-проект на C#, реализующий:
- Авторизацию пользователей с использованием JWT
- Создание и управление топиками
- Архитектуру, построенную на паттерне **CQRS**
- Разделение на слои: `Api`, `Application`, `Domain`, `Infrastructure`, `Shared`

---

## ⚙️ Используемые технологии

- ASP.NET Core Web API
- MediatR (CQRS)
- Entity Framework Core
- Identity + JWT Token
- SQLite

---

## 🚧 Планируемый рефакторинг

- Распределить классы по необходимым слоям и папкам
- Переработать LoginUser, RegisterUser под команды, соответсвующий принципам чистой архитектуры и CQRS
- Обновить AuthController

---

## ✅ Выполненный рефакторинг (ветка `refatoring`)

1. В слое **`Application/DTOs/TopicDto`** перемещены соответствующие файлы и выполнен рефакторинг `using`-ов.
2. В слое **`Application/DTOs/AuthDto`** перенесены файлы из **`Domain`**, обновлены пространства имён (`namespace`).
3. Класс **`CustomIdentityUser`** перенесён в **`Domain/Models`**.  
   Интерфейс **`IJwtSecurityService`** перемещён в **`Domain/Interfaces`**.
4. Добавлено исключение **`Application/Exceptions/UserNotFoundException`** для обработки случая, когда пользователь не найден.
5. Создана папка **`Application/Auth/Commands`**, реализована команда **`LoginUserQuery`** в соответствии с паттерном **CQRS**.
6. Логика авторизации удалена из **`Api/Controllers/AuthController`**, заменена на использование команды **`LoginUserQuery`**.
7. Исправлены ошибки в **`Application/Exceptions/UserNotFoundException`**.
8. Добавлено исключение **`Application/Exceptions/InvalidDataException`**, выбрасываемое при попытке регистрации пользователя с уже существующим `email` или `username`.
9. Реализована команда **`Application/Auth/Commands/RegisterUserCommand`**.  
   Логика из **`Api/Controllers/AuthController (Register)`** заменена на эту команду.
10. Проведена чистка `using`-ов по проекту, общие `using`-и вынесены в **`GlobalUsings`**.
