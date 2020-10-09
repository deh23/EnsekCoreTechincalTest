using System;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;

namespace EnsekCore.Models
{
    public class Repository : IRepository
    {
        public bool Add(MeterReading entity)
        {
            try
            {
                using (var database = new EnsekModel())
                {
                    database.MeterReadings.Add(entity);
                    database.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public User Get(int entity)
        {
            using (var database = new EnsekModel())
            {
                var result = database.Users.Where(x => x.AccountId == entity).FirstOrDefault();
                return result;
            }
        }
    }
}
