using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AddresBook.Models
{
    public class Person
    {
        [Key] // Атрибут, указывающий на то, что поле Id является первичным ключом в базе данных
        public int Id { get; set; } = 0; // Идентификатор человека

        [DisplayName("Имя")] // Атрибут, определяющий отображаемое имя для поля FirstName
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Поле должно содержать только буквы.")] // Регулярное выражение для проверки значения поля FirstName на наличие только букв
        public string FirstName { get; set; } = null!; // Имя человека

        [DisplayName("Фамилия")] // Атрибут, определяющий отображаемое имя для поля LastName
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Поле должно содержать только буквы.")] // Регулярное выражение для проверки значения поля LastName на наличие только букв
        public string LastName { get; set; } = null!; // Фамилия человека

        [DataType(DataType.Date)] // Атрибут, указывающий на тип данных для поля DateOfBirth (дата рождения)
        [DisplayName("Дата рождения")] // Атрибут, определяющий отображаемое имя для поля DateOfBirth
        public DateTime DateOfBirth { get; set; } // Дата рождения человека

        [EmailAddress] // Атрибут, указывающий на то, что поле Email должно быть валидным адресом электронной почты
        public string Email { get; set; } = null!; // Адрес электронной почты человека
    }

}
