namespace EnsekCore.Models
{
    public interface IRepository
    {
        bool Add(MeterReading entity);
        User Get(int entity);
    }
}