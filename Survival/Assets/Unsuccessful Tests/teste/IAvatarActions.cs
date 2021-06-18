using System.Collections;
using UnityEngine;
using static Assets.teste.EnumScript;

namespace Assets.teste
{
    public interface IAvatarActions
    {
        JobChoose JobController { get; set; }
        Faction Faction { get; set; }
        AvatarState State { get; set; }

        float HealthValue { get; set; }
        bool IsAlive { get; }




    }
}