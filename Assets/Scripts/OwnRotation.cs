using Photon.Pun;
using UnityEngine;

//자전
namespace InGame
{
    public class OwnRotation : Planet, ICommonRotateInfo, IPunInstantiateMagicCallback
    {
        PhotonView pv;

        private void Start()
        {
            SetMyPlanetData();
            pv = this.GetComponent<PhotonView>();
        }

        public void FixedUpdate()
        {
            if (pv.IsMine)
                pv.RPC("SetOwnRotation", RpcTarget.All);
        }

        //행성 Data 확인
        public void SetMyPlanetData()
        {
            foreach (var obj in PlanetContainer.ExistPlanetDic)
            {
                if (obj.Key.Equals(this.gameObject))
                {
                    ownSpeed = obj.Value.ownSpeed;
                    break;
                }
            }
        }

        //자전 설정
        //View 관찰은 한곳에서만 하도록
        [PunRPC]
        public void SetOwnRotation()
            => transform.Rotate(new Vector3(0, ownSpeed, 0) * Time.deltaTime);


        #region * Null Interface
        public void SetOrbitalSpeed()
        {
            throw new System.NotImplementedException();
        }

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
        }

        public void SetOwnSpeed()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
