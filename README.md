# Книжный магазин "Чешир"

Простое WPF.NET Core приложение, позволяющее просматривать список книг из БД (MS SQL Server), удалять и добавлять их, а также просматривать статистику лучших продаж.
  
### Используемые пакеты
* Entity Framework Core 5
* Microsoft.Extensions.Hosting (инверсия управления зависимостей в составе)
* Microsoft.Xaml.Behaviors.Wpf

### О программе
Используется реализация шаблонов хранилища для доступа к сущностям БД, а также шаблон Unit of work.  
Создана собственная точка входа приложения (класс Program.cs). При запуске создается хост, из сервисов которого формируется контекст БД.  
  
Реализованы три проекта в решении:
* Bookstore.Interfaces
* Bookstore.Lib
* CheshireBookstore
  
**CheshireBookstore** - основной WPF-проект с шаблоном MVVM, который запускает инициализацию тестовых данных в базе, а также отвечает за основную логику приложения.  
  
**Bookstore.Lib** - библиотека классов .NET Standard, содержащая описание основных сущностей, контекста БД и миграций. Также хранит реализацию репозиториев.  
  
**Bookstore.Interfaces** - библиотека классов .NET Standard, содержащая основную логику (интерфейсы) репозиториев, задача которых - реализация CRUD операций.  
