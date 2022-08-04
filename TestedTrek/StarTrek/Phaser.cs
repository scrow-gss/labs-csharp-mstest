using StarTrek;
using System;

public class Phaser
{

    private int _energy = 10000;
    public RandomGenerator Random { get; set; }

    public Phaser(RandomGenerator random)
    {
        Random = random;
    }

   

    public void UseEngery(int amount)
    {
        _energy -= amount;
    }

    public  int GetPhaserDamage(int amount, int distance)
    {

        var damage = amount - (((amount / 20) * distance / 200) + Random.Rnd(200));
        return damage < 1 ? 1 : damage;
    }

    public  void HitEnemyWithPhaser(Galaxy galaxy, int amount, Klingon enemy, int distance)
    {
        int damage = GetPhaserDamage(amount, distance);

        galaxy.WriteLine("Phasers hit Klingon at " + distance + " sectors with " + damage + " units");
        if (damage < enemy.GetEnergy())
        {
            enemy.SetEnergy(enemy.GetEnergy() - damage);
            galaxy.WriteLine("Klingon has " + enemy.GetEnergy() + " remaining");
        }
        else
        {
            galaxy.WriteLine("Klingon destroyed!");
            enemy.Delete();
        }
    }

    public  bool IsWithinPhaserRange(int distance)
    {
        return distance < 4000;
    }
   



}