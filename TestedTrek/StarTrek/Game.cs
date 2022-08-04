using System;
using System.Collections.Generic;
using Untouchables;
using StarTrek;

public class Game {
    public static RandomGenerator random = new RandomGenerator();

	private int _energy = 10000;
    private Phaser phaser = new Phaser(random);
    private static Random _generator;
    public static Random generator
    {
        set
        {

            _generator = value;
            random.setRandom(_generator);
        }
        get
        {
            return _generator;
        }
    }

    public int GetEnergyRemaining() {
        
        return _energy;
    }

    private int _torpedos = 8;
    public int Torpedoes {
        set {
            _torpedos = value;
        }
        get {
            return _torpedos;
        }
    }

    public void FireWeapon(WebGadget webgadget) {
        FireWeapon(new Galaxy(webgadget));
    }

    public void FireWeapon(Galaxy galaxy) {
        if (galaxy.Parameter("command").Equals("phaser"))
        {
            RunPhaserCommand(galaxy);

        }
        else if (galaxy.Parameter("command").Equals("photon"))
        {
            RunPhotonCommand(galaxy);
        }
    }

    private void RunPhotonCommand(Galaxy galaxy)
    {
        
        if (_torpedos > 0)
        {
            Klingon enemy = (Klingon)galaxy.Variable("target");
            int distance = enemy.Distance();

            FirePhoton(galaxy, enemy, distance);
        }
        else
        {
            galaxy.WriteLine("No more photon torpedoes!");
        }
    }

    private void FirePhoton(Galaxy galaxy, Klingon enemy, int distance)
    {
        if (DoesTropedoHit(distance))
        {
            TorpedoHit(galaxy, enemy, distance);            
        }
        else
        {
            galaxy.WriteLine("Torpedo missed Klingon at " + distance + " sectors...");
        }
        _torpedos -= 1;
    }

    private  bool DoesTropedoHit(int distance)
    {
        return (random.Rnd(4) + ((distance / 500) + 1) < 7);
    }

    private  void TorpedoHit(Galaxy galaxy, Klingon enemy, int distance)
    {
        TakeDamage(galaxy, enemy, distance);
    }

    private  void TakeDamage(Galaxy galaxy, Klingon enemy, int distance)
    {
        int damage = GetPhotonDamage();
        galaxy.WriteLine("Photons hit Klingon at " + distance + " sectors with " + damage + " units");
        DamageEnemy(galaxy, enemy, damage);
    }

    private static void DamageEnemy(Galaxy galaxy, Klingon enemy, int damage)

    {

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

    private  int GetPhotonDamage()
    {
        return 800 + random.Rnd(50);
    }

    private void RunPhaserCommand(Galaxy galaxy)
    {
        int energyCost = int.Parse(galaxy.Parameter("amount"));
        
        if (_energy >= energyCost)
        {
            FirePhaser(galaxy, energyCost);

        }
        else
        {
            galaxy.WriteLine("Insufficient energy to fire phasers!");
        }
    }

    private void FirePhaser(Galaxy galaxy, int energyCost)
    {
        Klingon enemy = (Klingon)galaxy.Variable("target");
        int distance = enemy.Distance();
        if (phaser.IsWithinPhaserRange(distance))
        {
            phaser.HitEnemyWithPhaser(galaxy, energyCost, enemy, distance);
        }
        else
        {
            galaxy.WriteLine("Klingon out of range of phasers at " + distance + " sectors...");

        }
        _energy -= energyCost;
    }



   }

    


   



