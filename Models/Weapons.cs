namespace CodApp.Models
{
    public class Weapons
    {
        public int Gun_Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int Ranking { get; set; }
        public int Damage { get; set; }
        public double Time_To_Kill { get; set; }
        public int Best_Distance { get; set; }

    }
}
