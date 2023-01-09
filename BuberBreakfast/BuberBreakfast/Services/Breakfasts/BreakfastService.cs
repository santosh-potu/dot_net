using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts;

public class breakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid,Breakfast> _breakfasts = new();
    public void CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id,breakfast);
    }

    public Breakfast GetBreakfast(Guid id)
    {
        return _breakfasts[id];
    }

    public void DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
    }

    public void UpsertBreakfast(Breakfast breakfast)
    {
        _breakfasts[breakfast.Id] = breakfast;
    }
}