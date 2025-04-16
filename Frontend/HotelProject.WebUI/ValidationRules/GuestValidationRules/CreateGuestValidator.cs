using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Misafir adı boş geçilemez")
                .MinimumLength(3).WithMessage("Misafir adı en az 3 karakter olmalıdır")
                .MaximumLength(20).WithMessage("Misafir adı en fazla 20 karakter olabilir");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Misafir soyadı boş geçilemez")
                .MinimumLength(2).WithMessage("Misafir soyadı en az 2 karakter olmalıdır")
                .MaximumLength(30).WithMessage("Misafir soyadı en fazla 30 karakter olabilir");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı boş geçilemez")
                .MinimumLength(3).WithMessage("Şehir adı en az 3 karakter olmalıdır")
                .MaximumLength(20).WithMessage("Şehir adı en fazla 20 karakter olabilir");
        }
    }
}
