using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Cloth;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private SaveSetup _saveSetup;
    private string _path = Application.streamingAssetsPath + "/save.txt";

    public int lastLevel;

    public Action<SaveSetup> FileLoaded;

    public SaveSetup Setup
    {
        get { return _saveSetup; }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "Jonatas";
    }

    private void Start()
    {
        Invoke(nameof(Load), .1f);
    }

    #region SAVE
    [NaughtyAttributes.Button]
    private void Save()
    {
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);
        //Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    public void SaveItens()
    {
        _saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).soInt.value;
        _saveSetup.health = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.LIFE_PACK).soInt.value;
    }

    public void SaveName(string text)
    {
        _saveSetup.playerName = text;
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveItens();
    }

    public void SaveCheckPointKey(int key)
    {
        _saveSetup.checkPointKey = key;
        SaveItens();
    }

    public void SaveCurrentLife(float life)
    {
        _saveSetup.playerCurrentLife = life;
    }

    public void CommitSave()
    {
        Save();
    }

    public void SaveEquippedCloth(ClothType clothType)
    {
        _saveSetup.activeClothType = clothType;
    }
    #endregion

    private void SaveFile(string json)
    {
        //Debug.Log(_path);
        File.WriteAllText(_path, json);
    }

    [NaughtyAttributes.Button]
    private void Load()
    {
        string fileLoaded = "";

        if (File.Exists(_path))
        {
            fileLoaded = File.ReadAllText(_path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
            lastLevel = _saveSetup.lastLevel;
        }
        else
        {
            CreateNewSave();
            Save();
        }

        FileLoaded?.Invoke(_saveSetup);
    }

    [NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }

    [NaughtyAttributes.Button]
    private void SaveLevelFive()
    {
        SaveLastLevel(5);
    }
}

[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public float coins;
    public float health;
    public int checkPointKey;
    public float playerCurrentLife;
    public ClothType activeClothType = ClothType.NONE;

    public string playerName;
}