using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CollectionObjects
{
    public List<Sprite> objects;
}
public class Lettercollect : MonoBehaviour
{
    public List<CollectionObjects> collections;
    

    public void CreateBox(Sprite sprite, GameObject box)
    {
        if (sprite.name == "7" || sprite.name == "8")
        {
            box.GetComponent<SpriteRenderer>().sprite = sprite;
            box.GetComponent<Transform>().Rotate(0, 0, -90);
        }
        else
        {
            box.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
