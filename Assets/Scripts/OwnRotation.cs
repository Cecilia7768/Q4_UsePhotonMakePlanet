using Photon.Pun;
using UnityEngine;

//����
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

        //�༺ Data Ȯ��
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

        //���� ����
        //View ������ �Ѱ������� �ϵ���
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
