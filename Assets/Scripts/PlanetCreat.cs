using Photon.Pun;
using UnityEngine;

public class PlanetCreat : MonoBehaviour
{
    #region Variable
    [Header("�׿� �༺�� ���� ��ġ")]
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

    //���༺ ����
    [PunRPC]
    void SetStandard()
    {
        if (standard == null)
        {
            if (!InGame.Planet.StandartPlanetType.Equals(0))
                InGame.Planet.StandartPlanetType = Random.Range(1, PlanetContainer.GetExistPlanetListCount());

            //�� �༺ ����            
            GameObject newPlanet = PhotonNetwork.Instantiate(PlanetContainer.GetPlanetListName(InGame.Planet.StandartPlanetType), this.transform.localPosition, Quaternion.identity, 0);
            newPlanet.transform.parent = this.transform;
            newPlanet.transform.localScale = new Vector3(Data.standardSize, Data.standardSize, Data.standardSize);
            //������ �Ǵ� ��ġ ����
            standard = newPlanet.transform;
            //������ �༺ ����
            PlanetContainer.AddExistPlanetDic(newPlanet, PlanetContainer.GetPlanetListData(InGame.Planet.StandartPlanetType));
        }

        //�ٸ� �༺ ����
        CreateNewPlanet();

    }

    //��Ÿ �༺�� ����
    void CreateNewPlanet()
    {
        for (int i = 0; i < Data.maxPlanetCount; i++)
        {
            if (!i.Equals(InGame.Planet.StandartPlanetType))
            {
                var newPlanet = PhotonNetwork.Instantiate(PlanetContainer.GetPlanetListName(i), othersParent.localPosition
                    , Quaternion.identity, 0);
                newPlanet.transform.parent = othersParent;

                //���� �༺ ���� �Ÿ� ����
                newPlanet.transform.position = standard.position + PlanetContainer.GetPlanetListData(i).distance;
                //���� �༺ ���� ������ ����
                // float size = Random.Range(Data.minOrbitalSize, Data.maxOrbitalSize);
                newPlanet.transform.localScale = PlanetContainer.GetPlanetListData(i).size;

                //������ �༺ ����
                PlanetContainer.AddExistPlanetDic(newPlanet, PlanetContainer.GetPlanetListData(i));
            }
        }
    }
}
