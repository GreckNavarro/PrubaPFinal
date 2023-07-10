using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArmaSO", menuName = "ScriptableObject/ArmaSO", order = 1)]

public class ArmaSO : ScriptableObject
{
    [SerializeField] Sprite sprite1;
    [SerializeField] int proyectiles;
    [SerializeField] int tiempo;
    [SerializeField] GameObject prefabBullet;
    [SerializeField] int damage;
    [SerializeField] GameObject player;
    private PlayerControl playerc;
    private float distance = 10;

    public int GetProyectil()
    {
        return proyectiles;
    }
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
        if (proyectiles == 1)
        {
            GameObject bullet = Instantiate(prefabBullet, playerc.GetPositionDisparador().transform.position, playerc.GetPositionDisparador().transform.rotation);
            bullet.GetComponent<Bullet>().SetArma(tiempo);
            bullet.GetComponent<Bullet>().SetDamage(damage);

        }
        else if (proyectiles == 3)
        {
            GameObject bullet = Instantiate(prefabBullet, playerc.GetPositionDisparador().transform.position, playerc.GetPositionDisparador().transform.rotation);
            bullet.GetComponent<Bullet>().SetArma(tiempo);
            bullet.GetComponent<Bullet>().SetDamage(damage);
            GameObject bullet1 = Instantiate(prefabBullet, playerc.GetPositionDisparador().transform.position, playerc.GetPositionDisparador().transform.rotation);
            bullet1.GetComponent<Bullet>().SetArma(tiempo);
            bullet1.GetComponent<Bullet>().SetDamage(damage);
            GameObject bullet2 = Instantiate(prefabBullet, playerc.GetPositionDisparador().transform.position, playerc.GetPositionDisparador().transform.rotation);
            bullet2.GetComponent<Bullet>().SetArma(tiempo);
            bullet2.GetComponent<Bullet>().SetDamage(damage);

            bullet1.transform.Rotate(0, 0, -15);
            bullet2.transform.Rotate(0, 0, 15);
        }
        else if (proyectiles == 0)
        {

            Vector2 direccion = playerc.DireccionShot();
            RaycastHit2D[] raycast = Physics2D.RaycastAll(playerc.GetPositionDisparador().transform.position, direccion, distance);
            Debug.DrawRay(playerc.GetPositionDisparador().transform.position, direccion * distance, Color.red);

            for (int i = 0; i < raycast.Length; i++)
            {
                if (raycast[i].collider.gameObject.tag == "Enemy")
                {
                    raycast[i].collider.gameObject.GetComponent<ControladorEnemy>().RecibirDaño(damage);
                }
                if (raycast[i].collider.gameObject.tag == "Boss")
                {
                    raycast[i].collider.gameObject.GetComponent<BossController>().RecibirDaño(damage);
 
                }
            }

        }

    }
}
