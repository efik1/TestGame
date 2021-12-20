using System.Collections;
using UnityEngine;
using DG.Tweening;


public class Box : MonoBehaviour
{
    [SerializeField] ParticleSystem starsParticle = null;
    public string box_name { get; set; }
    public GameObject ImageBox;
    private Main myCamera_script;

    public void Awake()
    {
        myCamera_script = GameObject.Find("Main Camera").GetComponent<Main>();
    }
    public void OnMouseDown()
    {
        if (box_name == myCamera_script.Find_Text) //отработка тапа на правильный ответ
        {
            StartCoroutine(enumerator()); // запуск корутины
        }
        else //отработка тапа на неправильный ответ
        {
            var imgageBoxMove = DOTween.Sequence(); //последовательность анимаций для реализации easeInBounce эффекта
            imgageBoxMove.Append(ImageBox.transform.DOLocalMoveX(Random.Range(-0.8f,0.8f), 0.4f).SetEase(Ease.InBounce));
            imgageBoxMove.Append(ImageBox.transform.DOLocalMoveX(0, 0.2f).SetEase(Ease.InBounce));
            ImageBox.GetComponent<AudioSource>().Play(); 
        }
    }
    // Корутина для корректного отображения анимаций и звука при тапе на правильный ответ
    IEnumerator enumerator()
    {
        myCamera_script.GetComponent<AudioSource>().Play();
        ImageBox.GetComponent<Animation>().Play("bounceImage");
        starsParticle.Play();
        yield return new WaitForSeconds(0.3f);
        myCamera_script.Controller();
    }
}
