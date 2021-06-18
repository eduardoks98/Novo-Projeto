using System;
using System.Collections;
using UnityEngine;

namespace Assets.teste
{
    public class Warrior : IStat
    {
        public int Strength { get => 11; set => Debug.Log("Cant alter Warrior stat"); }
        public int Constitution { get => 11; set => Debug.Log("Cant alter Warrior stat"); }
        public int Dexterity { get => 11; set => Debug.Log("Cant alter Warrior stat"); }
        public int Intelligence { get => 11; set => Debug.Log("Cant alter Warrior stat"); }
        public int Wisdom { get => 11; set => Debug.Log("Cant alter Warrior stat"); }
        public int Charisma { get => 11; set => Debug.Log("Cant alter Warrior stat"); }
    }
}
