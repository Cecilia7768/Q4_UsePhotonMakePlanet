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

    //�� �༺���� UI event
    public void OnClickDrop() => InGame.Planet.StandartPlanetType = drop.value;
    public void OnClickConnect()
    {
        Manager.Instance.Connect();
    }

    //UI ������ �̸� ��Ʈ�� �����ص�
    //���������� ���� �����͸� �� �༺�� �����ִ� ���ñ��� �־���
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
