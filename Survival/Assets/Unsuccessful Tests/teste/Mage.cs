using System;
using System.Collections;
using UnityEngine;

namespace Assets.teste
{
    public class Mage : IStat
    {
        public int Strength { get => 10; set => Debug.Log("Cant alter Mage stat"); }
        public int Constitution { get => 10; set => Debug.Log("Cant alter Mage stat"); }
        public int Dexterity { get => 10; set => Debug.Log("Cant alter Mage stat"); }
        public int Intelligence { get => 10; set => Debug.Log("Cant alter Mage stat"); }
        public int Wisdom { get => 10; set => Debug.Log("Cant alter Mage stat"); }
        public int Charisma { get => 10; set => Debug.Log("Cant alter Mage stat"); }

    }
}