using CodApp.Models;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;


namespace CodApp
{
    public class WeaponsRepository : IWeaponsRepository
    {

        private readonly IDbConnection _conn;

        public WeaponsRepository(IDbConnection conn)
        {
           _conn = conn;
        }
        public IEnumerable<Weapons> GetAllWeapons()
        {
            return _conn.Query<Weapons>("Select * From guns");
        }

        public Weapons GetWeapon(int id)
        {
            return _conn.QuerySingle<Weapons>("SELECT * FROM Guns WHERE GUN_ID = @id", new { id = id });
        }

        public void UpdateWeapon(Weapons weapons)
        {
            _conn.Execute("UPDATE guns SET Name = @name, Category = @category WHERE Gun_Id = @id",
            new { name = weapons.Name, category = weapons.Category, id = weapons.Gun_Id });
        }

        public void InsertWeapon(Weapons weaponsToInsert)
        {
            _conn.Execute("INSERT INTO guns (NAME, CATEGORY, RANKING, DAMAGE, TIME_TO_KILL, BEST_DISTANCE) VALUES (@name, @category, @ranking, @damage, @time_to_kill, @best_distance);",
                new { name = weaponsToInsert.Name, category = weaponsToInsert.Category, ranking = weaponsToInsert.Ranking, damage = weaponsToInsert.Damage, time_to_kill = weaponsToInsert.Time_To_Kill, best_distance = weaponsToInsert.Best_Distance });
        }

    

        public void DeleteWeapon(Weapons weapons)
        {
            _conn.Execute("DELETE FROM GUNS WHERE Gun_Id = @id;", new { id = weapons.Gun_Id });


        }
    }
}
