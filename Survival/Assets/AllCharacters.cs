using Assets.New_fucking_test_to_controller;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllCharacters : MonoBehaviour
{
    public  List<CharClass> characters = new List<CharClass>();
    private void Awake()
    {
        CreateChars();
    }
    void CreateChars()
    {
        characters.Add(
        new CharClass(AttackTypes.SingleRanged,
                      CharTypes.Mage,
                      RaceTypes.Human,
                      EntityTypes.Player,
                      "Mago maneiro",
                      "Cool",
                      20f,
                      5f,
                      0.5f,
                      3f,
                      100f,
                      200f)
                      );
        characters.Add(
        new CharClass(AttackTypes.SingleMelee,
                      CharTypes.Warrior,
                      RaceTypes.Orc,
                      EntityTypes.Enemies,
                      "Warrior maneiro",
                      "Cool",
                      10f,
                      15f,
                      0.5f,
                      3f,
                      200f,
                      100f)
                      );
    }
    public CharClass GetClass(CharTypes classe)
    {
        return characters.First(x => x.Classe == classe);
    }
}
