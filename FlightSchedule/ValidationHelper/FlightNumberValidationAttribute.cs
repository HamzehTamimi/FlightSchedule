using System.ComponentModel.DataAnnotations;

namespace FlightSchedule.VildationHelper
{
    public class FlightNumberValidationAttribute:ValidationAttribute
    {
        //private readonly ApplicationDbContext.ApplicationDbContext _applicationDbContext;

        //public FLightNumberVildationAttribute(ApplicationDbContext.ApplicationDbContext applicationDbContext)
        //{
        //       _applicationDbContext = applicationDbContext;   
        
        
        //} 


        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                string flightNUmber = (string)value;


                if (flightNUmber.Length <= 4)
                {
                    return new  ValidationResult ("length  not valid ");
                    
                 
                }

                 string  Iata=flightNUmber.Substring(0, 2);

                var dbContext = (ApplicationDbContext.ApplicationDbContext)validationContext
                .GetService(typeof(ApplicationDbContext.ApplicationDbContext));

                if (dbContext == null)
                {
                    throw new InvalidOperationException("Database context not available.");
                }
                bool isIataExsist = dbContext.Airlines.Any(x => x.IATA.ToLower() == Iata.ToLower());

                if(!isIataExsist)
                return new ValidationResult("length  not valid ");
              

            } else
            {
                                 return new ValidationResult("fliight number is null ");
                
            }


            return ValidationResult.Success; 

            
        }
    }
}
