
namespace AutocompleteExample.Models
{
    public interface ICityRepository
    {
        string[] FindCities(string q);
    }
}
