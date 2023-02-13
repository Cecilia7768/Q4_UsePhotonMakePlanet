using Photon.Pun;
using System.Collections;
using UnityEngine;

#region * 모노싱글톤
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;

                if (instance == null)
                {
                    instance = new GameObject(typeof(T).ToString(), typeof(T)).AddComponent<T>();
                }
            }

            return instance;
        }
    }
}

#endregion
public class Manager : MonoSingleton<Manager>
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject networkManager;
    PhotonView pv;

    private void Start()
    {
        pv = this.GetComponent<PhotonView>();

        Screen.SetResolution(1280, 1024, false);
    }


    public void Connect() => StartCoroutine(CheckConnected());
    IEnumerator CheckConnected()
    {
        //연결 성공될때까지 대기
        while (!NetworkManager.isConnetSucess)
            yield return Coroutine.Wait01;

        var manager = this.GetComponent<PlanetCreat>();
        while (manager.enabled == false)
        {
            yield return Coroutine.Wait01;
            manager.enabled = true;
        }
        if (pv.IsMine)
            pv.RPC("SetCamera", RpcTarget.All);

    }

    public void OnNetworkManager()
    {
        networkManager.GetComponent<NetworkManager>().enabled = true;
    }

    //모든 행성이 다보이도록 주 행성 기준 카메라 위치 리셋팅 
    [PunRPC]
    void SetCamera() => StartCoroutine(SetMainCamera());
    IEnumerator SetMainCamera()
    {
        //마스터 클라이언트라면 첫 셋팅
        while (PlanetCreat.Standard == null)
            yield return Coroutine.Wait01;

        if (PhotonNetwork.IsMasterClient)
        {
            mainCamera.transform.position =
            new Vector3(PlanetCreat.Standard.position.x, PlanetCreat.Standard.position.y, Data.cameraZ);
        }
    }
}
