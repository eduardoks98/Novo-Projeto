using System.Collections;
using UnityEngine;

namespace Assets.Found_Other_solution_to_snake_walk
{
    public class Mage : Minion
    {
        public static Mage Create()
        {
            var mage = Instantiate(pfText, transform.position, Quaternion.identity);

            Mage maguinho = mage.GetComponent<Mage>();
            maguinho.Setup();
            return maguinho;
        }

        public void Setup()
        {

        }
    }
}