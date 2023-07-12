using AddresBook.Models;

namespace AddresBook
{
    public class AddressBookRepository : IRepository<Person>
    {
        private readonly AddressBookDbContext context; // Контекст базы данных

        public AddressBookRepository(AddressBookDbContext context)
        {
            this.context = context;
        }

        // Метод для добавления новой записи о человеке
        public Person Add(Person item)
        {
            var added = context.Persons.Add(item); // Добавляем новую запись о человеке в контекст базы данных
            context.SaveChanges(); // Сохраняем изменения в базе данных
            return added.Entity; // Возвращаем добавленную запись о человеке
        }

        // Метод для удаления записи о человеке
        public Person Delete(Person item)
        {
            var removed = context.Persons.Remove(item); // Удаляем запись о человеке из контекста базы данных
            context.SaveChanges(); // Сохраняем изменения в базе данных
            return removed.Entity; // Возвращаем удаленную запись о человеке
        }

        // Метод для получения всех записей о людях
        public IEnumerable<Person> GetAll()
        {
            var all = context.Persons.ToList(); // Получаем все записи о людях из контекста базы данных
            return all; // Возвращаем список всех записей о людях
        }

        // Метод для чтения записи о человеке по идентификатору
        public Person Read(int id)
        {
            return context.Persons.FirstOrDefault(x => x.Id == id); // Возвращаем запись о человеке с указанным идентификатором из контекста базы данных
        }

        // Метод для обновления записи о человеке
        public bool Update(Person item)
        {
            var updated = context.Persons.Update(item); // Обновляем запись о человеке в контексте базы данных
            context.SaveChanges(); // Сохраняем изменения в базе данных
            return updated.IsKeySet; // Возвращаем значение, указывающее, был ли установлен ключ при обновлении
        }
    }

}
