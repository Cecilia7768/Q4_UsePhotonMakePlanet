using System;
using UnityEngine;

public class PlanetInfoSet : MonoBehaviour
{

    public void Awake()
    {
        Init();
    }

    void Init()
    {
        SetListDirection();
        SetPlanetList();
    }


    /// <summary>
    /// ������ �༺�� ������ �̸� �̾Ƶ�
    /// </summary>
    void SetPlanetList()
    {
        for (int i = 0; i < Data.maxPlanetCount; i++)
        {
            string name = Enum.GetName(typeof(PlanetName), i);

            PlanetContainer.SetPlanetList(new Planet(name, GetRanSpeed().Item1,
                 GetRanSpeed().Item2, PlanetContainer.GetDirectionbyIdex(GetRanSpeed().Item3),
                 GetRandomSizePosition().Item1, GetRandomSizePosition().Item2));
        }

        //�ӵ� ���� �̱�
        (float, float, int) GetRanSpeed()
        {
            float own = UnityEngine.Random.Range(50f, 100f);
            float orbital = UnityEngine.Random.Range(20f, 40f);
            int idx = UnityEngine.Random.Range(0, PlanetContainer.GetDirectionCount());
            return (own, orbital, idx);
        }

        //���� ������ �� ��ǥ ����
        (Vector3, Vector3) GetRandomSizePosition()
        {
            float size = UnityEngine.Random.Range(Data.minOrbitalSize, Data.maxOrbitalSize);

            float x = UnityEngine.Random.Range(Data.maxRangeX * -1, Data.maxRangeX);
            float y = UnityEngine.Random.Range(Data.maxRangeY * -1, Data.maxRangeY);
            float z = UnityEngine.Random.Range(Data.maxRangeZ * -1, Data.maxRangeZ);

            return (new Vector3(size, size, size), new Vector3(x, y, z));
        }
    }

    /// <summary>
    /// ���� ���� ������ ���� �̸� ����
    /// </summary>
    void SetListDirection()
    {
        PlanetContainer.SetDirectionList(Vector3.forward);
        PlanetContainer.SetDirectionList(Vector3.right);
        PlanetContainer.SetDirectionList(Vector3.left);
        PlanetContainer.SetDirectionList(Vector3.back);
    }

}
