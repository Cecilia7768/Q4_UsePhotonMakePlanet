using UnityEngine;

//��ü �༺�� ���� Ŭ����
//�ڽĵ� ������ Mono�� ����

namespace InGame
{
    public class Planet : MonoBehaviour
    {
        //�� �༺

        [SerializeField] private static int standartPlanetType;
        public static int StandartPlanetType
        {
            get { return standartPlanetType; }
            set { standartPlanetType = value; }
        }


        protected float ownSpeed;
        protected float orbital;
        protected Vector3 where;
    }
}
