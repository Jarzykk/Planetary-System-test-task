using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlanetData", menuName = "GameData/Planet Data", order = 51)]
public class PlanetData : ScriptableObject
{
    [SerializeField] private double _minMass;
    [SerializeField] private double _maxMass;
    [SerializeField] private float _minRadius;
    [SerializeField] private float _maxRadius;
    [SerializeField] private MassClass _massClass;

    public double MinMass => _minMass;
    public double MaxMass => _maxMass;
    public float MinRadius => _minRadius;
    public float MaxRadius => _maxRadius;
    public MassClass MassClass => _massClass;
}
