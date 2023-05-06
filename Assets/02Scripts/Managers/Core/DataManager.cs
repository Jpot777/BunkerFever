﻿using UnityEngine;

[System.Serializable]
public class DataManager
{
    ///<summary>Manager생산할때 만들어짐</summary>
    public void Init()
    {
        GetData();
    }


    public bool UseHaptic
    {
        get => _useHaptic;
        set
        {
            _useHaptic = value;
            ES3.Save<bool>("Haptic", value);
        }
    }
    [SerializeField]
    private bool _useHaptic;

    public bool UseSound
    {
        get => _useSound;
        set
        {
            _useSound = value;
            ES3.Save<bool>("Sound", value);
            Managers.Sound.BgmOnOff(value);
        }
    }
    [SerializeField]
    private bool _useSound;


    private int _monsterNum = 0;
    public int MonsterNum
    {
        get => _monsterNum;
        set
        {
            _monsterNum = value;
            if (_monsterNum > 3)
                _monsterNum = 1;

            ES3.Save<int>("MonsterNum", value);
        }
    }


    public void SaveData()
    {
    }

    public void GetData()
    {
        UseHaptic = ES3.Load<bool>("Haptic", true);
        UseSound = ES3.Load<bool>("Sound", true);
        MonsterNum = ES3.Load<int>("MonsterNum", 1);
    }
}
