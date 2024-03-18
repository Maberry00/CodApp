using CodApp.Models;

namespace CodApp
{
    public interface IWeaponsRepository
    {
        public IEnumerable<Weapons> GetAllWeapons ();
        public Weapons GetWeapon (int id);

        public void UpdateWeapon (Weapons weapons);
        public void InsertWeapon(Weapons weaponsToInsert);
       

        public void DeleteWeapon(Weapons weapons);


    }
}
