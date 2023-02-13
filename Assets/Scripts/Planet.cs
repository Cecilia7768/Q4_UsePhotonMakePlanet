using UnityEngine;

//전체 행성에 대한 클래스
//자식들 때문에 Mono를 가짐

namespace InGame
{
    public class Planet : MonoBehaviour
    {
        //주 행성

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
