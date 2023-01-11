using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Models;

public class Breakfast
{
    public const int MinNameLength = 5;
    public const int MaxNameLength = 50;
    public const int MinDescriptionLength = 10;
    public const int MaxDescriptionLength = 250;
    public Guid Id {get;}
    public string Name {get;}
    public string Description {get;}
    public DateTime StartDateTime {get;}
    public DateTime EndDateTime {get;}
    public DateTime LastModifiedDateTime {get;}
    public List<string> Savory {get;}
    public List<string> Sweet {get;}

    private Breakfast(
        Guid id,
        string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModifiedDateTime, List<string> savory, List<string> sweet)
    {
        //To do enforce 
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }

    public static ErrorOr<Breakfast> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> savory,
        List<string> sweet,
        Guid? id = null)
    {
        List<Error> errors = new();
        if(name.Length < 5 || name.Length > 50){
            return Errors.Breakfast.InvalidName;
        }
        return new Breakfast();
    }
}