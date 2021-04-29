using System.Collections;
using UnityEngine;

namespace Assets.teste
{
    public interface IStatsController
    {
        float CurrentHealth { get; set; }
        bool IsAlive { get; }


        

    }
}