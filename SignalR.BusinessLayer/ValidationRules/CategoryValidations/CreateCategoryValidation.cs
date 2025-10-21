using FluentValidation;
using SignalR.DtoLayer.CategoryDto;

namespace SignalR.BusinessLayer.ValidationRules.CategoryValidations;

public class CreateCategoryValidation : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidation()
    {
        RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name cannot be empty.").MinimumLength(3).WithMessage
            ("Kategori İsmi en az 3 karakterli olması gerek.");

    }
}
