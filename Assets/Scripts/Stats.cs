using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public event EventHandler OnStatsChanged;

    public static float stat_min = 0;
    public static float stat_max = 30;

    public enum Type
    {
        Stress,
        Excitement,
        Interest,
        Relaxation,
        Focus,
        Engagement,
    }

    private SingleStat stressStat;
    private SingleStat excitementStat;
    private SingleStat interestStat;
    private SingleStat relaxationStat;
    private SingleStat focusStat;
    private SingleStat engagementStat;

    public Stats(float stressStatValue, float excitementStatValue, float interestStatValue, float relaxationStatValue, float focusStatValue, float engagementStatValue)
    {
        stressStat = new SingleStat(stressStatValue);
        excitementStat = new SingleStat(excitementStatValue);
        interestStat = new SingleStat(interestStatValue);
        relaxationStat = new SingleStat(relaxationStatValue);
        focusStat = new SingleStat(focusStatValue);
        engagementStat = new SingleStat(engagementStatValue);
    }

    private SingleStat GetSingleStat(Type statType)
    {
        switch (statType)
        {
            default:
            case Type.Stress:            return stressStat;
            case Type.Excitement:        return excitementStat;
            case Type.Interest:          return interestStat;
            case Type.Relaxation:        return relaxationStat;
            case Type.Focus:             return focusStat;
            case Type.Engagement:        return engagementStat;
                    ;
        }
    }

    public void SetStatValue(Type statType, float statValue)
    {
        GetSingleStat(statType).SetStatValue(statValue);
        if (OnStatsChanged != null) OnStatsChanged(this, EventArgs.Empty);
    }

    public void IncreaseStatValue(Type statType)
    {
        SetStatValue(statType, GetStatValue(statType) + 1);
    }

    public void DecreaseStatValue(Type statType)
    {
        SetStatValue(statType, GetStatValue(statType) - 1);
    }

    public float GetStatValue(Type statType)
    {
        return GetSingleStat(statType).GetStatValue();

    }

    public float GetStatValueNormalized(Type statType)
    {
        return GetSingleStat(statType).GetStatValueNormalized();

    }

    public class SingleStat
    {
        private float stat;

        public SingleStat(float statValue)
        {
            SetStatValue(statValue);
        }

        public void SetStatValue(float StatValue)
        {
            stat = Mathf.Clamp(StatValue, stat_min, stat_max);
        }

        public float GetStatValue()
        {
            return stat;
        }

        public float GetStatValueNormalized()
        {
            return (float)stat / stat_max;
        }
    }

    

}
