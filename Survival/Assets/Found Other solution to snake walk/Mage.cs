using System.Collections;
using UnityEngine;

namespace Assets.Found_Other_solution_to_snake_walk
{
    public class Mage : Minion
    {
        public static Mage Create()
        {
            var mage = Instantiate(GameAssets.i.Mage, new Vector3(0,0), Quaternion.identity);

            Mage maguinho = mage.GetComponent<Mage>();
            return maguinho;
        }

    }
}