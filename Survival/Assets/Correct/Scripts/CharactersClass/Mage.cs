using Assets.Correct;
using Assets.Correct.Party;
using Assets.Correct.Util;
using System.Collections;
using UnityEngine;

namespace Assets.Correct.Characters
{
    public class Mage : Minion
    {

        public static Mage Create()
        {
            var i = Instantiate(GameAssets.i.Mage, new Vector3(0, 0), Quaternion.identity);

            Mage mage = i.GetComponent<Mage>();
            mage.Setup();
            return mage;
        }

        void Setup()
        {

        }
    }
}