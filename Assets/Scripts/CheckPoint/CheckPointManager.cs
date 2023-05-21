using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public int lastCheckPointKey = 0;

    public List<CheckPointBase> checkPoints;

    public bool HasCheckPoint()
    {
        return lastCheckPointKey > 0;
    }

    public void SaveCheckPoint(int i)
    {
        if (i > lastCheckPointKey)
        {
            lastCheckPointKey = i;
            SaveManager.Instance.SaveCheckPointKey(i);
            SaveManager.Instance.SaveCurrentLife(Player.Instance.healthBase.CurrentLife);
            SaveManager.Instance.SaveItens();
            SaveManager.Instance.CommitSave();
        }
    }

    public Vector3 GetPosition()
    {
        var checkPoint =  checkPoints.Find(i => i.key == lastCheckPointKey);
        return checkPoint.transform.position;
    }
}
