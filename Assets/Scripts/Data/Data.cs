using UnityEngine;
//���� Data

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
    //�� �༺ ũ��
    public const int standardSize = 5;

    //�ִ� ���� �༺ ����
    public const int maxPlanetCount = 8;

    //�� �༺���� �Ÿ�
    public const float maxRangeX = 12f;
    public const float maxRangeY = 12f;
    public const float maxRangeZ = 12f;

    //���� �༺ ������ ����
    public const float minOrbitalSize = 1f;
    public const float maxOrbitalSize = 2f;

    //ī�޶� ��ġ
    public const float cameraX = 0;
    public const float cameraY = 0;
    public const float cameraZ = 30;
}
public struct Planet
{
    //�༺ �̸� (���� �����Լ� �Ű����� ������ �ʿ���)
    public string name;
    //���� �ӵ�
    public float ownSpeed;
    //���� �ӵ�
    public float orbitalSpeed;
    //���� ����
    public Vector3 where;
    //�༺ ũ��
    public Vector3 size;
    //���༺�� �ƴ� �� ���༺���� �Ÿ�
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

