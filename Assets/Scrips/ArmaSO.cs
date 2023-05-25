using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArmaSO", menuName = "ScriptableObject/ArmaSO", order = 1)]

public class ArmaSO : ScriptableObject
{
    [SerializeField] Sprite sprite1;
    [SerializeField] string mensaje;
    [SerializeField] GameObject prefabBullet;
    [SerializeField] GameObject player;
    private PlayerControl playerc;
  
    public void SetPlayer(PlayerControl playere)
    {
        playerc = playere.GetComponent<PlayerControl>();
    }
    public Sprite GetSprite()
    {
        return sprite1;
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(prefabBullet, playerc.GetPositionArma().transform.position, playerc.GetPositionArma().transform.rotation);
        bullet.GetComponent<Bullet>().SetPlayer(playerc);
    }
}
