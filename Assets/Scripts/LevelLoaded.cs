using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoaded : MonoBehaviour
{
    public float bounce_speed;
    public GameObject[] boxes;
    public List<string> letter_names = new List<string>();
    private Sprite newSprite;
    private Lettercollect letter_script;
    private Vector3 default_size = new Vector3(0, 0, 0);
    public float scaling_time;
    
    private void Awake()
    {
        letter_script = GetComponent<Lettercollect>();
    }
    public void Create(int boxesCount)
    {
        int rnd = UnityEngine.Random.Range(0, letter_script.collections.Count);
        for (int i = 0; i < boxesCount; i++)
        {
            StartCoroutine(enumerator(i));
            newSprite = letter_script.collections[rnd].objects[UnityEngine.Random.Range(0, letter_script.collections[rnd].objects.Count)];
            letter_script.collections[rnd].objects.Remove(newSprite); // убираем использованный объект из коллекции объектов
            letter_names.Add(newSprite.name);
            boxes[i].GetComponent<Box>().box_name = newSprite.name; // присваеваем полю box_name текущего объекта массива boxes
            letter_script.CreateBox(newSprite, boxes[i].GetComponent<Box>().ImageBox);
        }

    }
    IEnumerator enumerator(int box_index)
    {
        yield return new WaitForSeconds(box_index * bounce_speed);
        boxes[box_index].transform.localScale = default_size;
        boxes[box_index].SetActive(true);
        boxes[box_index].GetComponent<Animator>().Play("bounce");
        yield return new WaitForSeconds(0.1f);
        boxes[box_index].GetComponent<AudioSource>().Play();

    }

}
