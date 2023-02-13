using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    //�ڵ�����
    public bool AutoConnect = true;
    public byte Version;

    public static bool isConnetSucess = false;

    [Tooltip("�ѹ濡 ���Ǵ� �ִ� �ο���")]
    public byte MaxPlayers = 40;
    public int playerTTL = -1;

    private void Start()
    {
        if (AutoConnect)
            this.ConnectNow();
    }
    public void ConnectNow()
    {
        NetworkMessage.NetworkMsg = "���� ����...";

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = this.Version + "." + SceneManagerHelper.ActiveSceneBuildIndex;
    }

    #region ** ���� ���� �޼���

    public override void OnConnectedToMaster()
    {
        NetworkMessage.NetworkMsg = "�����ͼ��� ���� �Ϸ�";
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedLobby()
    {
        NetworkMessage.NetworkMsg = "�κ� ����";
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        NetworkMessage.NetworkMsg = "���� Ȯ����...";
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = this.MaxPlayers };
        if (playerTTL >= 0)
            roomOptions.PlayerTtl = playerTTL;

        PhotonNetwork.CreateRoom(null, roomOptions, null);
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        NetworkMessage.NetworkMsg = "���� ����.";
    }

    public override void OnJoinedRoom()
    {
        NetworkMessage.NetworkMsg = "���� ����.";
        isConnetSucess = true;
    }

    #endregion
}


