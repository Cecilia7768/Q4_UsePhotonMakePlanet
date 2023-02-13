using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetContainer : MonoBehaviour
{

    //�༺ Data List
    private static List<Planet> planetList = new List<Planet>();
    //������ �༺ Dic
    private static Dictionary<GameObject, Planet> existPlanetDic = new Dictionary<GameObject, Planet>();
    public static Dictionary<GameObject, Planet> ExistPlanetDic
    {
        get { return existPlanetDic; }
    }
    //���� ���� 4��
    private static List<Vector3> direction = new List<Vector3>();

    #region * �����Ϳ� �����ϰ� ���ִ� �޼ҵ��
    // ���� ������ ������ + �༺ ������  :: existPlanetDic
    public static void AddExistPlanetDic(GameObject go, Planet p)
    {
        existPlanetDic.Add(go, p);
    }


    // �༺ ������ List :: planetList

    public static void SetPlanetList(Planet p)
    {
        planetList.Add(p);
    }

    public static int GetExistPlanetListCount()
    {
        return planetList.Count;
    }

    public static string GetPlanetListName(int idx)
    {
        return planetList[idx].name;
    }
    public static Planet GetPlanetListData(int idx)
    {
        return planetList[idx];
    }

    //���Ⱚ :: directionList

    public static void SetDirectionList(Vector3 v)
    {
        direction.Add(v);
    }
    public static int GetDirectionCount()
    {
        return direction.Count;
    }
    public static Vector3 GetDirectionbyIdex(int idx)
    {
        return direction[idx];
    }
    #endregion

}
