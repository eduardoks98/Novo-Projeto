using Assets.Correct;
using Assets.Correct.Party;
using Assets.Correct.Util;
using System.Collections;
using UnityEngine;

namespace Assets.Correct.Characters
{
    public class Warrior : Minion
    {

        public static Warrior Create()
        {
            var i = Instantiate(GameAssets.i.Warrior, new Vector3(0, 0), Quaternion.identity);

            Warrior warrior = i.GetComponent<Warrior>();
            warrior.Setup();
            return warrior;
        }

        void Setup()
        {

        }
    }
}