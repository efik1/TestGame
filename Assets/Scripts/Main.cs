using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Main : MonoBehaviour
{
    public string Find_Text { get; private set; }
    public GameObject textbox;
    public GameObject[] levels;
    public GameObject restart;
    private int Click_Count = 0;
    private string letters;    

    private void Awake()
    {
        Controller();
        textbox.GetComponent<Text>().DOFade(1, 0.7f);
    }
    //метод загружающий текующий уровень
    public void Controller()
    {
        //Проверка прохождения последнего уровня и вызов соответствующих методов
        if (Click_Count == 3)
        {
            levels[Click_Count - 1].SetActive(false);
            textbox.SetActive(false);
            restart.SetActive(true);
            print(letters);
        }
        //Загрузка уровней
        else
        {
            for (int i = 0; i < levels.Length; i++)
            {
                if (i != Click_Count) levels[i].SetActive(false); textbox.SetActive(false);
            }
            CreateLevel(levels[Click_Count]);
            Click_Count++;
        }
        Destroy(GameObject.Find("Button"));
    }
    //Метод для создания уровня, принимающий в качестве агрумента экземпляр класса GameObject из списка levels
    public void CreateLevel(GameObject level)
    {
        LevelLoaded script_lvlLoaded = level.GetComponent<LevelLoaded>();
        int lvl_size = script_lvlLoaded.boxes.Length;

        //включение элментов уровня
        level.SetActive(true);
        textbox.SetActive(true);

        //вызов метода из класса LevelLoaded для генерации данных в уровне
        script_lvlLoaded.Create(lvl_size);

        //Выбор задания из набора объектов на уровне
        Find_Text = script_lvlLoaded.boxes[Random.Range(0, script_lvlLoaded.boxes.Length - 1)].GetComponent<Box>().box_name.ToString();

        //проверка задания на павтор в данной игровой сессии
        if (letters == "" && letters.Contains(Find_Text.ToString()))
        {
            Find_Text = "";
            Find_Text = script_lvlLoaded.boxes[Random.Range(0, script_lvlLoaded.boxes.Length - 1)].GetComponent<Box>().box_name.ToString();
            textbox.GetComponent<Text>().text = "Find " + Find_Text;
            letters += Find_Text;
        }
        else
        {
            textbox.GetComponent<Text>().text = "Find " + Find_Text;
            letters += Find_Text;
        }
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Application.Quit();
    }
}
