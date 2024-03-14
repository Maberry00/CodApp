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

        public Weapons GetWeapons(int id)
        {
            return _conn.QuerySingle<Weapons>("SELECT * FROM Guns WHERE GUN_ID = @id", new { id = id });
        }

        public void UpdateWeapons(Weapons weapons)
        {
            _conn.Execute("UPDATE guns SET Name = @name, Category = @category WHERE Gun_Id = @id",
            new { name = weapons.Name, category = weapons.Category, id = weapons.Gun_Id });
        }
    }
}
