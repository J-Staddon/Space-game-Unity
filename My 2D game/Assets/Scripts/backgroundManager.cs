using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundManager : MonoBehaviour
{
    public float parralax = 2f;

    void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Material mat = sr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;

        mat.mainTextureOffset = offset;
    }
}
