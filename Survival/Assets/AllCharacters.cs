using Assets.New_fucking_test_to_controller;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllCharacters : MonoBehaviour
{
    public List<CharClass> characters = new List<CharClass>();
    private void Awake()
    {
        CreateChars();
    }
    void CreateChars()
    {
        characters.Add(
new CharClass(AttackTypes.SingleRanged, // Attack Type
                CharTypes.Mage, //Class name
                RaceTypes.Human,//Race type
                EntityTypes.Player, //if is controlable for the player or a botin game
                "Mago maneiro", // cool name
                "Cool", // cool descriction
                20f, //attack power
                5f, //defense power
                1f, //attack speed
                5f, //attack range
                3f, //move speed
                100f, // max health
                200f) //max mana
                );
        characters.Add(
 new CharClass(AttackTypes.SingleMelee, // Attack Type
               CharTypes.Warrior, //Class name
               RaceTypes.Human,//Race type
               EntityTypes.Enemies, //if is controlable for the player or a botin game
               "Warrior maneiro", // cool name
               "Cool", // cool descriction
               5f, //attack power
               20f, //defense power
               1.5f, //attack speed
               1f, //attack range
               3.2f, //move speed
               200f, // max health
               100f) //max mana
               );
    }
    public CharClass GetClass(CharTypes classe)
    {
        return characters.First(x => x.Classe == classe);
    }
}
