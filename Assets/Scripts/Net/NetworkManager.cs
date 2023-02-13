using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    //자동연결
    public bool AutoConnect = true;
    public byte Version;

    public static bool isConnetSucess = false;

    [Tooltip("한방에 허용되는 최대 인원수")]
    public byte MaxPlayers = 40;
    public int playerTTL = -1;

    private void Start()
    {
        if (AutoConnect)
            this.ConnectNow();
    }
    public void ConnectNow()
    {
        NetworkMessage.NetworkMsg = "연결 시작...";

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = this.Version + "." + SceneManagerHelper.ActiveSceneBuildIndex;
    }

    #region ** 연결 관련 메세지

    public override void OnConnectedToMaster()
    {
        NetworkMessage.NetworkMsg = "마스터서버 연결 완료";
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedLobby()
    {
        NetworkMessage.NetworkMsg = "로비 입장";
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        NetworkMessage.NetworkMsg = "서버 확인중...";
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = this.MaxPlayers };
        if (playerTTL >= 0)
            roomOptions.PlayerTtl = playerTTL;

        PhotonNetwork.CreateRoom(null, roomOptions, null);
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        NetworkMessage.NetworkMsg = "연결 끊김.";
    }

    public override void OnJoinedRoom()
    {
        NetworkMessage.NetworkMsg = "연결 성공.";
        isConnetSucess = true;
    }

    #endregion
}


