using System.Collections;
using UnityEngine;
using static Assets.teste.EnumScript;

namespace Assets.teste
{
    public interface IAvatarActions
    {
        IAtributes Atributes { get; set; }
        Faction Faction { get; set; }

        float HealthValue { get; set; }
        bool IsAlive { get; }


        

    }
}