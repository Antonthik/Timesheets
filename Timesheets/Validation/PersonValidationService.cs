using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Validation
{
    public class PersonValidationService : AbstractValidator<Person>
    {
        public PersonValidationService()
        {
            var msg = "Ошибка в поле {PropertyName}: значение {PropertyValue}";
            RuleFor(x => x.FirstName)
                .Must(c=>c.All(char.IsLetter))
                .WithMessage("Имя должно содержать только символы")
                .WithErrorCode("BRL-100.1");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Фамилия не должна быть пустым")
                .WithErrorCode("BRL-100.2");
            RuleFor(x => x.Age)
                .GreaterThan(14)
                .LessThan(150)
                .WithMessage("Возраст должен быть от 14 до 150")
                .WithErrorCode("BRL-100.3");
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(msg)
                .WithErrorCode("BRL-100.4"); 
            RuleFor(x => x.Email)
                 .NotEmpty()
                 .WithMessage(msg)
                 .WithErrorCode("BRL-100.5");

        }
    }
}
