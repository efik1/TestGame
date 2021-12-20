using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Fade;

    private void Awake()
    {
        Fade.GetComponent<Image>().DOFade(0.5f, 1);
    }
    //перезапуск сцены (метод перезагрузки игры)
    public void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
