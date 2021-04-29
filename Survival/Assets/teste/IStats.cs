using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStats
{
    public float Health { get; }
    public float Defense { get; }
    public float PhysicPower { get; }
    public float MagicPower { get; }
    public float AttackRate { get; }
    public float Speed { get; }
    public int Strength { get; }
    public int Constitution { get; }
    public int Dexterity { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
}
