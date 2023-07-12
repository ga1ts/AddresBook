using AddresBook;
using AddresBook.Models;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Создание экземпляра приложения веб-приложения ASP.NET Core

// Добавление сервисов в контейнер зависимостей
builder.Services.AddControllersWithViews(); // Добавление поддержки контроллеров и представлений
builder.Services.AddSingleton<IRepository<Person>, AddressBookRepository>(); // Регистрация синглтон-сервиса для интерфейса IRepository<Person> с использованием AddressBookRepository
builder.Services.AddSingleton<AddressBookDbContext>(); // Регистрация синглтон-сервиса для AddressBookDbContext

// Добавление аутентификации и авторизации
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate(); // Добавление аутентификации схемы Negotiate
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build(); // Построение хоста приложения

// Конфигурация конвейера обработки HTTP-запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Использование обработчика исключений при возникновении ошибок
    // Значение HSTS по умолчанию равно 30 дням. В продакшене рекомендуется изменить это значение, см. https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // Использование HTTP Strict Transport Security (HSTS) для обеспечения безопасности соединения
}

app.UseHttpsRedirection(); // Перенаправление HTTP-запросов на HTTPS
app.UseStaticFiles(); // Разрешение использования статических файлов

app.UseAuthentication(); // Использование аутентификации

app.UseRouting(); // Использование маршрутизации

app.UseAuthorization(); // Использование авторизации

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Определение маршрута по умолчанию для контроллеров и представлений

app.Run(); // Запуск приложения

