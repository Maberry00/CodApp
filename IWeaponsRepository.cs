using CodApp.Models;

namespace CodApp
{
    public interface IWeaponsRepository
    {
        public IEnumerable<Weapons> GetAllWeapons ();
        public Weapons GetWeapons (int id);

        public void UpdateWeapons (Weapons weapons);
    }
}
