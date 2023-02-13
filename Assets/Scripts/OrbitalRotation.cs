using Photon.Pun;
using UnityEngine;


//����
namespace InGame
{
    public class OrbitalRotation : Planet, ICommonRotateInfo, IPunInstantiateMagicCallback
    {
        [SerializeField] float _orbitalSpeed;
        private void Start()
        {
            SetMyPlanetData();
        }
        public void FixedUpdate()
        {
            OrbitRotation();
        }

        public void OrbitRotation()
        {
            if (PlanetCreat.Standard != null)
                this.transform.RotateAround(PlanetCreat.Standard.position, where, orbital * Time.deltaTime);
        }

        //�༺ Data Ȯ��
        public void SetMyPlanetData()
        {
            foreach (var obj in PlanetContainer.ExistPlanetDic)
            {
                if (obj.Key.Equals(this.gameObject))
                {
                    orbital = obj.Value.orbitalSpeed;
                    where = obj.Value.where;
                    break;
                }
            }
        }

        #region * Null Interface
        public void SetOwnRotation()
        {
            throw new System.NotImplementedException();
        }

        public void SetOwnSpeed()
        {
            throw new System.NotImplementedException();
        }

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
        }

        public void SetOrbitalSpeed()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}