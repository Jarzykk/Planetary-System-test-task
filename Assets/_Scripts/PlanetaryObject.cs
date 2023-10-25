using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlanetaryObject : MonoBehaviour
{
    [SerializeField] private PlanetType _planetType;

    private void Start()
    {
        PlanetData planetData = PlanetDataHolder.Instance.GetPlanetData(_planetType);
        
        Debug.Log(planetData.PlanetType);
    }
}
