using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetContainer : MonoBehaviour
{

    //青己 Data List
    private static List<Planet> planetList = new List<Planet>();
    //积己等 青己 Dic
    private static Dictionary<GameObject, Planet> existPlanetDic = new Dictionary<GameObject, Planet>();
    public static Dictionary<GameObject, Planet> ExistPlanetDic
    {
        get { return existPlanetDic; }
    }
    //傍傈 规氢 4辆
    private static List<Vector3> direction = new List<Vector3>();

    #region * 单捞磐俊 立辟窍霸 秦林绰 皋家靛甸
    // 弥辆 积己等 橇府普 + 青己 单捞磐  :: existPlanetDic
    public static void AddExistPlanetDic(GameObject go, Planet p)
    {
        existPlanetDic.Add(go, p);
    }


    // 青己 单捞磐 List :: planetList

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

    //规氢蔼 :: directionList

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
