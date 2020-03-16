using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int rows;
    private int cols;
    private int[] numbers;
    private int pairs = 0;

    public float offsetX = 4f;
    public float offsetY = 5f;

    [SerializeField] private main_card OriginalCard;
    [SerializeField] private Sprite[] images;

    GameObject panel;

    private void Start()
    {
        panel = GameObject.Find("Panel");
        panel.SetActive(false);

        Vector3 startPos = OriginalCard.transform.position;

        int size = 0;
        switch (StaticClass.CrossSceneInformation)
        {
            case 1:
                cols = 2;
                rows = 2;
                size = rows * cols;
                pairs = size / 2;

                numbers = new int[] { 0, 0, 1, 1 };
                OriginalCard.transform.localScale = new Vector3(0.4f, 0.4f, 1);
                startPos = new Vector3(-1.5f, -2.25f, -1);
                StaticClass.CrossSceneInformation = 0;
                break;
            case 2:
                cols = 4;
                rows = 2;
                size = rows * cols;
                pairs = size / 2;
                numbers = new int[] { 0, 0, 1, 1, 2, 2, 3, 3 };
                OriginalCard.transform.localScale = new Vector3(0.3f, 0.3f, 1);
                startPos = new Vector3(-4.5f, -2.25f, -1);

                offsetX = 3.7f;
                offsetY = 4f;

                StaticClass.CrossSceneInformation = 0;
                break;
            case 3:
                cols = 4;
                rows = 4;
                size = rows * cols;
                pairs = size / 2;
                numbers = new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
                OriginalCard.transform.localScale = new Vector3(0.2f, 0.2f, 1);
                startPos = new Vector3(-4f, -3.5f, -1);

                offsetX = 3.5f;
                offsetY = 2.25f;

                StaticClass.CrossSceneInformation = 0;
                break;
            default:

                break;
        }

        numbers = ShuffleArray(numbers);

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                main_card card;

                if (i == 0 && j == 0)
                {
                    card = OriginalCard;
                }
                else
                {
                    card = Instantiate(OriginalCard) as main_card;
                }

                int index = j * cols + i;
                int id = numbers[index];
                card.ChangeCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;

                card.transform.position = new Vector3(posX, posY, startPos.z);


            }
        }

    }



    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];

        for (int i = 0; i < newArray.Length; i++)
        {
            int temp = newArray[i];
            int rand_num = UnityEngine.Random.Range(i, newArray.Length);
            newArray[i] = newArray[rand_num];
            newArray[rand_num] = temp;
        }

        return newArray;
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown("space"))
    //    {
    //        SceneManager.LoadScene("Menu");
    //    }
    //}


    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Finish()
    {
        // panel = GameObject.Find("Panel");
        panel.SetActive(true);
    }


    //-------------------------------------------------------------------------------

    private main_card firstCart;
    private main_card secondCart;

    private int count_pairs = 0;

    private int score = 0;
    [SerializeField] private TextMesh scoreLabel;

    public bool canReveal
    {
        get { return secondCart == null; }
    }

    public void CardRelevated(main_card card)
    {
        if (firstCart == null)
        {
            firstCart = card;
        }
        else
        {
            secondCart = card;
            StartCoroutine(checkedMatch());
        }
    }

    private IEnumerator checkedMatch()
    {
        if (firstCart.id == secondCart.id)
        {
            score += 10;
            scoreLabel.text = "Score: " + score;

            count_pairs++;

            yield return new WaitForSeconds(0.5f);

            firstCart.gameObject.SetActive(false);
            secondCart.gameObject.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            firstCart.UnReveal();
            secondCart.UnReveal();

            score -= 2;
            scoreLabel.text = "Score: " + score;
        }
        firstCart = null;
        secondCart = null;


        ChechFinish();
    }

    private void ChechFinish()
    {
        if (count_pairs == pairs)
        {
            Finish();
        }
    }

    //------------------------------------------------------------------------
    // public InputMaster controls;
    private InputAction actionOnBut;
    [SerializeField] private InputActionAsset buttonInputAcction;

    void Awake()
    {
        var buttonAcction = buttonInputAcction.FindActionMap("RestartGame");
        actionOnBut = buttonAcction.FindAction("Restart");
        actionOnBut.performed += _ => Check();
        Debug.Log("We pres this button: " + actionOnBut.name);
        //controls..startAction.performed += _ => Check();
    }

    void Check()
    {
        Debug.Log("We pres this button");
        SceneManager.LoadScene("Menu");
    }

    private void OnEnable()
    {
        actionOnBut.Enable();
    }

    private void OnDisable()
    {
        actionOnBut.Disable();
    }

}

