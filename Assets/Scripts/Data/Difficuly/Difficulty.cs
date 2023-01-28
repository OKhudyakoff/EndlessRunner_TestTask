using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "Data/Difficulty")]
public class Difficulty : ScriptableObject
{
    [SerializeField]
    private float multiplier;
    [SerializeField]
    private float playerStartSpeed;
    [SerializeField]
    private float accelerationTime;

    public float GetMultiplier() => multiplier;
    public float GetPlayerStartSpeed() => playerStartSpeed;
    public float GetAccelerationTime() => accelerationTime;
}
