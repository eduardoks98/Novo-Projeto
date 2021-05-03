using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.teste.EnumScript;

public interface IAtributes
{
    public float Health { get; }
    public float Defense { get; }
    public float PhysicPower { get; }
    public float MagicPower { get; }
    public float AttackRate { get; }
    public float Speed { get; }
}
