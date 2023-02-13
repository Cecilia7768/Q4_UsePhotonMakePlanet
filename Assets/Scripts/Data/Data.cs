using UnityEngine;
//각종 Data

public enum PlanetName
{
    None = -1,

    Sun,
    Blue,
    Green,
    Navy,
    Orange,
    Purple,
    Red,
    Yellow,

    Max,
}
public static class Data
{
    //주 행성 크기
    public const int standardSize = 5;

    //최대 생성 행성 갯수
    public const int maxPlanetCount = 8;

    //주 행성과의 거리
    public const float maxRangeX = 12f;
    public const float maxRangeY = 12f;
    public const float maxRangeZ = 12f;

    //공전 행성 사이즈 범위
    public const float minOrbitalSize = 1f;
    public const float maxOrbitalSize = 2f;

    //카메라 위치
    public const float cameraX = 0;
    public const float cameraY = 0;
    public const float cameraZ = 30;
}
public struct Planet
{
    //행성 이름 (포톤 생성함수 매개변수 때문에 필요함)
    public string name;
    //자전 속도
    public float ownSpeed;
    //공전 속도
    public float orbitalSpeed;
    //공전 방향
    public Vector3 where;
    //행성 크기
    public Vector3 size;
    //주행성이 아닐 떄 주행성과의 거리
    public Vector3 distance;
    public Planet(string _name, float own, float orbital, Vector3 where, Vector3 _size, Vector3 _distance)
    {
        this.name = _name;
        this.ownSpeed = own;
        this.orbitalSpeed = orbital;
        this.where = where;
        this.size = _size;
        this.distance = _distance;
    }
}

