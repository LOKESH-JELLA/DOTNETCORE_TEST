namespace TS_LRS.Repositories.LookUp.Interfaces
{
    public interface ILookUpRepo
    {
        Task<string> GetAllCountriesAsyn();
    }
}
