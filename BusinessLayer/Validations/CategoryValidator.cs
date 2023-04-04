using EntityLayer.Concrete;
using FluentValidation;


namespace BusinessLayer.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() 
        { 
            RuleFor(m=>m.CategoryStatus).NotEmpty();
            RuleFor(m => m.CategoryName).NotEmpty().MinimumLength(5).WithMessage("You should use at least 5 words to create a category name otherwise it won`t apply");
            RuleFor(m => m.CategoryDescription).NotEmpty().MaximumLength(100).WithMessage("You should not write more than 100 words to describe the description");
        }
    }
}
