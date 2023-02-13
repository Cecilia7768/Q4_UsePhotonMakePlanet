using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;

public class UISet : MonoBehaviour
{
    [SerializeField] GameObject createUI;
    [SerializeField] TMP_Text ishost;

    public TMP_Dropdown drop;

    private void Start()
    {
        StartCoroutine(CorConnectCheck());
    }

    //주 행성선택 UI event
    public void OnClickDrop() => InGame.Planet.StandartPlanetType = drop.value;
    public void OnClickConnect()
    {
        Manager.Instance.Connect();
    }

    //UI 때문에 미리 네트웍 연결해둠
    //연결했을때 내가 마스터면 주 행성을 고를수있는 선택권이 주어짐
    IEnumerator CorConnectCheck()
    {
        Manager.Instance.OnNetworkManager();

        while (!PhotonNetwork.IsConnected || PhotonNetwork.MasterClient == null)
            yield return Coroutine.Wait0001;


        if (PhotonNetwork.IsMasterClient)
        {
            ishost.gameObject.SetActive(true);
            ishost.text = "Host";
            createUI.SetActive(true);
        }
    }
}
