using Microsoft.EntityFrameworkCore;

namespace AddresBook.Models
{
    public class AddressBookDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } // Набор сущностей Person, который будет представлять таблицу в базе данных

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Настройка параметров подключения к базе данных
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-VMM55HA\MSSQLSERVER02;Database=AddressBook;TrustServerCertificate=True;Trusted_Connection=True");
            // Здесь:
            // - "DESKTOP-VMM55HA" - это имя компьютера, где установлен SQL Server и экземпляр с именем MSSQLSERVER02.
            // - "AddressBook" - это имя базы данных, с которой устанавливается соединение.
            // - "TrustServerCertificate=True" указывает, что клиентское приложение будет доверять серверному сертификату без его проверки.
            // - "Trusted_Connection=True" указывает на использование доверенного соединения Windows.


            /*
            Для замены строки подключения для другого пользователя:
            1. Замените только имя компьютера (Data Source) на имя компьютера, где установлен SQL Server или находится нужный сервер базы данных.
            2. При необходимости, замените имя базы данных (Database) на нужное вам имя.
            3. Остальные параметры (TrustServerCertificate и Trusted_Connection) могут оставаться неизменными.

            Пример новой строки подключения с заменой имени компьютера:
            optionsBuilder.UseSqlServer(@"
                Data Source=НОВОЕ_ИМЯ_КОМПЬЮТЕРА\SQLEXPRESS;
                Database=AddressBook;
                TrustServerCertificate=True;
                Trusted_Connection=True;
            ");
            */
        }
    }

}
