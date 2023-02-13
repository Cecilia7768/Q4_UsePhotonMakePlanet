using System.Collections;
using TMPro;
using UnityEngine;

public class NetworkMessage : MonoBehaviour
{

    //네트워크 상태 메세지
    private static string networkMsg;
    public static string NetworkMsg
    {
        set
        {
            networkMsg = value;
            isInputMsg = true;
        }
    }

    [SerializeField] GameObject messageObj;
    private static bool isInputMsg = false;

    private void Start() => StartCoroutine(CorSetMessage());

    IEnumerator CorSetMessage()
    {
        while (true)
        {
            yield return Coroutine.Wait0001;
            if (isInputMsg)
            {
                var msg = Instantiate(messageObj, this.transform);
                msg.GetComponent<TMP_Text>().text = networkMsg;
                isInputMsg = false;
                yield return Coroutine.Wait0001;
            }

            if (NetworkManager.isConnetSucess)
            {
                yield return Coroutine.Wait3;

                for (int i = 0; i < this.transform.childCount;)
                {
                    Destroy(this.transform.GetChild(i).gameObject);
                    yield return Coroutine.Wait1;
                }
                yield break;
            }
        }
    }
}
