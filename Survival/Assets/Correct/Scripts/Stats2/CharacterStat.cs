using Assets.Correct.Scripts.Stats2;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterStat
{
    public float BaseValue;

    public virtual float Value
    {
        get
        {
            if (isDirty|| BaseValue!=lastBaseValue)
            {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    protected bool isDirty = true;
    protected float _value;
    protected float lastBaseValue = float.MinValue;

    protected readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifers;

   public CharacterStat()
    {
        this.statModifiers = new List<StatModifier>();
        StatModifers = statModifiers.AsReadOnly();
    }

    public CharacterStat(float baseValue) :this()
    {
        this.BaseValue = baseValue;
    }

    public virtual void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    
    public virtual bool RemoveModifier(StatModifier mod)
    {
        if (statModifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;

        for (int i = statModifiers.Count-1; i >= 0; i--)
        {
            if (statModifiers[i].Source == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }
    protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;

        return 0;
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];
            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.Value;
                if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.Type == StatModType.PercentMult)
            {
                finalValue *= 1 + mod.Value;
            }
        }
        return (float)Math.Round(finalValue, 1);
    }
}
