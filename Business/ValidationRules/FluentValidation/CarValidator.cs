using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty().MinimumLength(2);
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            //Markası 1 olan arabanın günlük ücreti 50 den büyük olmalı.
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(50).When(c => c.BrandId == 1);
            
        }
    }
}
