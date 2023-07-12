using AddresBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AddresBook.Controllers
{
    [Authorize] // Атрибут, указывающий на необходимость авторизации для доступа к контроллеру
    public class HomeController : Controller
    {
        private readonly IRepository<Person> repository;

        public HomeController(IRepository<Person> repository)
        {
            this.repository = repository;
        }

        // Метод, возвращающий представление со списком всех людей
        public IActionResult GetAllPeople()
        {
            var all = repository.GetAll(); // Получаем все записи о людях из репозитория
            return View("GetAllPeople", all); // Возвращаем представление "GetAllPeople" с передачей списка всех людей в качестве модели
        }

        [HttpGet]
        // Метод, возвращающий представление для обновления информации о человеке с указанным идентификатором
        public IActionResult Update(int id)
        {
            var person = repository.Read(id); // Получаем информацию о человеке с указанным идентификатором из репозитория
            return View("Update", person); // Возвращаем представление "Update" с передачей информации о человеке в качестве модели
        }

        // Метод для обновления информации о человеке
        public IActionResult Update(Person person)
        {
            if (ModelState.IsValid) // Проверяем, валидна ли модель (введенная информация о человеке)
            {
                repository.Update(person); // Обновляем информацию о человеке в репозитории
                var all = repository.GetAll(); // Получаем все записи о людях из репозитория
                return View("EditAddressBook", all); // Возвращаем представление "EditAddressBook" с передачей списка всех людей в качестве модели
            }
            return View("Update", person); // Возвращаем представление "Update" с передачей информации о человеке в качестве модели (в случае невалидной модели)
        }

        // Метод для удаления информации о человеке с указанным идентификатором
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid) // Проверяем, валидна ли модель (введенная информация о человеке)
            {
                var person = repository.Read(id); // Получаем информацию о человеке с указанным идентификатором из репозитория
                repository.Delete(person); // Удаляем информацию о человеке из репозитория
                var all = repository.GetAll(); // Получаем все записи о людях из репозитория
                return View("EditAddressBook", all); // Возвращаем представление "EditAddressBook" с передачей списка всех людей в качестве модели
            }
            throw new Exception("Model is invalid"); // В случае невалидной модели выбрасываем исключение
        }

        // Метод, возвращающий представление для редактирования адресной книги (списка всех людей)
        public IActionResult Edit()
        {
            var all = repository.GetAll(); // Получаем все записи о людях из репозитория
            return View("EditAddressBook", all); // Возвращаем представление "EditAddressBook" с передачей списка всех людей в качестве модели
        }

        // Метод для поиска людей по имени
        public IActionResult FindByFirstName(string name)
        {
            var all = repository.GetAll(); // Получаем все записи о людях из репозитория
            all = all
                .Where(p => p.FirstName.Equals(name)) // Фильтруем записи о людях, сравнивая имя с заданным значением
                .ToList(); // Преобразуем результат в список
            return View("EditAddressBook", all); // Возвращаем представление "EditAddressBook" с передачей отфильтрованного списка людей в качестве модели
        }

        // Метод для поиска людей по фамилии
        public IActionResult FindByLastName(string name)
        {
            var all = repository.GetAll() // Получаем все записи о людях из репозитория
                .Where(p => p.LastName == name) // Фильтруем записи о людях, сравнивая фамилию с заданным значением
                .ToList(); // Преобразуем результат в список
            return View("EditAddressBook", all); // Возвращаем представление "EditAddressBook" с передачей отфильтрованного списка людей в качестве модели
        }

        // Метод для поиска людей по дате рождения
        public IActionResult FindByDate(DateTime date)
        {
            var all = repository.GetAll() // Получаем все записи о людях из репозитория
                .Where(p => p.DateOfBirth == date) // Фильтруем записи о людях, сравнивая дату рождения с заданным значением
                .ToList(); // Преобразуем результат в список
            return View("EditAddressBook", all); // Возвращаем представление "EditAddressBook" с передачей отфильтрованного списка людей в качестве модели
        }

        // Метод для поиска людей по электронной почте
        public IActionResult FindByEmail(string email)
        {
            var all = repository.GetAll() // Получаем все записи о людях из репозитория
                .Where(p => p.Email == email) // Фильтруем записи о людях, сравнивая электронную почту с заданным значением
                .ToList(); // Преобразуем результат в список
            return View("EditAddressBook", all); // Возвращаем представление "EditAddressBook" с передачей отфильтрованного списка людей в качестве модели
        }

        [HttpGet]
        // Метод, возвращающий представление для создания нового человека
        public IActionResult Create()
        {
            return View("Create"); // Возвращаем представление "Create"
        }

        // Метод для создания нового человека
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid) // Проверяем, валидна ли модель (введенная информация о человеке)
            {
                repository.Add(person); // Добавляем информацию о человеке в репозиторий
                var all = repository.GetAll(); // Получаем все записи о людях из репозитория
                return View("EditAddressBook", all); // Возвращаем представление "EditAddressBook" с передачей списка всех людей в качестве модели
            }
            return Create(); // Возвращаем представление "Create" (в случае невалидной модели)
        }

        // Метод, возвращающий представление по умолчанию
        public IActionResult Index()
        {
            return View(); // Возвращаем представление по умолчанию
        }
    }

}