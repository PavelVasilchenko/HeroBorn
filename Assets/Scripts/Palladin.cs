using UnityEngine;

public class Palladin : Character
{
        public Weapon weapon;
        
        public Palladin(string name, Weapon weapon) : base(name)
        {
                this.weapon = weapon;
        }

        public override void PrintStatsInfo()
        {
                Debug.LogFormat("Hail {0} - take up your {1}!", name, weapon.name);
        }
}
