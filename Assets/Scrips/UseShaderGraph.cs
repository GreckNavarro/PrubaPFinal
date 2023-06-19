using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseShaderGraph : MonoBehaviour
{
    [SerializeField] List<Texture2D> textures;
    [SerializeField] Material materialQuad;

    private void Start()
    {
        materialQuad.SetTexture("_Texture", textures[0]);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            materialQuad.SetTexture("_Texture", textures[1]);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            materialQuad.SetTexture("_Texture", textures[2]);
        }
    }
}
