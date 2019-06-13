
using System;

public abstract class Target : ITarget
{
    private int health;
    private readonly int experience;

    public Target(int health, int experience)
    {
        this.health = health;
        this.experience = experience;
    }

    public int Health
    {
        get { return this.health; }
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException($"{this.GetType().Name} is dead.");
        }

        this.health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.experience;
    }

    public bool IsDead()
    {
        return this.health <= 0;
    }
}

