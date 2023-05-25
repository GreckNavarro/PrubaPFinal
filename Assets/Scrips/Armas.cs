using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour
{
    private SpriteRenderer sp;
    private Sprite currentsprite;
    [SerializeField] private PlayerControl player;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        currentsprite = player.armas.GetTop().GetSprite();
        sp.sprite = currentsprite;
    }
    public void SetSprite(Sprite sprite)
    {
        currentsprite = sprite;
        sp.sprite = currentsprite;
    }
}
