using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArmaSO", menuName = "ScriptableObject/ArmaSO", order = 1)]

public class ArmaSO : ScriptableObject
{
    [SerializeField] Sprite sprite1;
    [SerializeField] string mensaje;
  
    public Sprite GetSprite()
    {
        return sprite1;
    }
    public void Shoot()
    {
        Debug.Log(mensaje);
    }
}
