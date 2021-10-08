using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float movespeed = 300f;
    public Vector3 direction;
    float movement = 0f;
    public Light light;
    int count;
    public GameObject restart;

    public HitSheild getScore;

    private const string highScoreKey = "HighScore";
    [SerializeField] private int highScore = 0;


    public Text txtScore;
    public Text textCount;
    public Text textHigh;
    public Image healthBar;

    public DamagePlayer damn;

    // Update is called once per frame

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        CreatePanelHero();
    }
    void Update() {

        movement = Input.GetAxisRaw("Horizontal");
        Debug.Log(movement);
        if (movement == 1 || movement == -1)
        {
            FindObjectOfType<AudioManager>().Play("Wind");
        }

        if (getScore.Score >= 5)
        {
            Debug.Log("Test");
            ChangePosition();
            getScore.Score = 0;
            count++;
        }

        UpdateHeroPanel();

        if (damn.currentHealth <= 0)
        {

            restart.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        faceMouse();
        transform.RotateAround(Vector3.zero, direction, movement * Time.fixedDeltaTime * -movespeed);
    }
    private void faceMouse() {

        Vector3 dir  = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.AngleAxis(angle, direction);

    }

    void ChangePosition() {

        Debug.Log("ChangePosition");
        light.spotAngle += 15;
        if (transform.localPosition.x <= 0)
        {
            Mathf.Abs(transform.localPosition.x);
        }

        Debug.Log(""+ transform.localPosition.x + ";" + transform.localPosition.y + ";" + transform.localPosition.z);
        Vector3 newpos = new Vector3(Mathf.Abs(transform.localPosition.x),
                                     transform.localPosition.y,
                                     Mathf.Abs(transform.localPosition.z));
        transform.position = newpos + Vector3.right;

        //Debug.Log("" + transform.localPosition.x +";"+ transform.localPosition.y + ";" + transform.localPosition.z);
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void CreatePanelHero()
    {
        Debug.Log("Create Ui done");

        txtScore.text = "5";
        textCount.text = "" + count;
        textHigh.text = "Best: " + highScore.ToString();

    }
    void UpdateHeroPanel()
    {

        int curentScore = 5 - getScore.Score;

        txtScore.text = "" + curentScore;
        textCount.text = "" + count;

        healthBar.fillAmount = damn.currentHealth / damn.maxHealth;

        if (count > highScore)
        {
            highScore = count;
            textHigh.text = "Best: " + highScore.ToString();

            // TODO: Delete me, unless for some odd reason I am needed... But I should not be :D
            PlayerPrefs.SetInt(highScoreKey, highScore);
            PlayerPrefs.Save();
        }

    }
    //void OnDestroy()
    //{
    //    PlayerPrefs.SetInt("highscore", highscore);
    //    PlayerPrefs.Save();
    //}

    private void OnDisable()
    {
        // Set our high score.
        PlayerPrefs.SetInt(highScoreKey, highScore);
        // Save our data.
        PlayerPrefs.Save();

        // TODO: Delete me, for debugging only!
        Debug.Log("I'm being Disabled! The high score is currently: " + highScore);
    }
}
