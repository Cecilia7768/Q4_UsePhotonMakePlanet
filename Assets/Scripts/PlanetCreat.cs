using Photon.Pun;
using UnityEngine;

public class PlanetCreat : MonoBehaviour
{
    #region Variable
    [Header("弊寇 青己甸 积己 困摹")]
    [SerializeField] Transform othersParent;
    [SerializeField] private static Transform standard = null;

    public static PhotonView pv;
    public static GameObject LocalPlayerInstance;
    public static Transform Standard
    {
        get { return standard; }
    }

    #endregion
    private void Start() => Init();

    void Init()
    {
        pv = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
            pv.RPC("SetStandard", RpcTarget.All);
    }

    //林青己 积己
    [PunRPC]
    void SetStandard()
    {
        if (standard == null)
        {
            if (!InGame.Planet.StandartPlanetType.Equals(0))
                InGame.Planet.StandartPlanetType = Random.Range(1, PlanetContainer.GetExistPlanetListCount());

            //林 青己 积己            
            GameObject newPlanet = PhotonNetwork.Instantiate(PlanetContainer.GetPlanetListName(InGame.Planet.StandartPlanetType), this.transform.localPosition, Quaternion.identity, 0);
            newPlanet.transform.parent = this.transform;
            newPlanet.transform.localScale = new Vector3(Data.standardSize, Data.standardSize, Data.standardSize);
            //扁霖捞 登绰 困摹 汲沥
            standard = newPlanet.transform;
            //积己等 青己 焊包
            PlanetContainer.AddExistPlanetDic(newPlanet, PlanetContainer.GetPlanetListData(InGame.Planet.StandartPlanetType));
        }

        //促弗 青己 积己
        CreateNewPlanet();

    }

    //扁鸥 青己甸 积己
    void CreateNewPlanet()
    {
        for (int i = 0; i < Data.maxPlanetCount; i++)
        {
            if (!i.Equals(InGame.Planet.StandartPlanetType))
            {
                var newPlanet = PhotonNetwork.Instantiate(PlanetContainer.GetPlanetListName(i), othersParent.localPosition
                    , Quaternion.identity, 0);
                newPlanet.transform.parent = othersParent;

                //傍傈 青己 罚待 芭府 汲沥
                newPlanet.transform.position = standard.position + PlanetContainer.GetPlanetListData(i).distance;
                //傍傈 青己 罚待 荤捞令 汲沥
                // float size = Random.Range(Data.minOrbitalSize, Data.maxOrbitalSize);
                newPlanet.transform.localScale = PlanetContainer.GetPlanetListData(i).size;

                //积己等 青己 焊包
                PlanetContainer.AddExistPlanetDic(newPlanet, PlanetContainer.GetPlanetListData(i));
            }
        }
    }
}
