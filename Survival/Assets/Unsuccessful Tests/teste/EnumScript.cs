using System.Collections;
using UnityEngine;

namespace Assets.teste
{
    public class EnumScript : MonoBehaviour
    {
        public enum Faction { Goblins, Avatares};

        public enum Contract { Mage, Warrior};

        public enum AvatarState { Idle, Walk, Follow, Seek, Hide, Attack, Block, Die };
    }
}