using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberCollection : MonoBehaviour
{
    public List<Sprite> objects = new List<Sprite>();

    public void CreateBox(Sprite sprite, GameObject box)
    {
        box.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
