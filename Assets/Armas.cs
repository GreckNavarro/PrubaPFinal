using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{
    private SpriteRenderer sp;
    private Sprite currentsprite;
    private PlayerControl player;
    private Pilas.StackP<ArmaSO> armas;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();

    }
    public void SetSprite(Sprite sprite)
    {
        currentsprite = sprite;
        sp.sprite = currentsprite;
    }
}
