using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class GlobalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerControl Player1Script;
    public PlayerControl Player2Script;
    public PlayerControl Player3Script;
    public PlayerControl Player4Script;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public Transform Player1Transform;
    public Transform Player2Transform;
    public Transform Player3Transform;
    public Transform Player4Transform;
    private Vector3 Dist1to2;
    private Vector3 Dist1to4;
    private Vector3 Dist3to2;
    private Vector3 Dist3to4;
    private float Distance1to2;
    private float Distance1to4;
    private float Distance3to2;
    private float Distance3to4;
    private PlayerControl newEnemyScript;
    private GameObject newMe;
    private GameObject newEnemy;
    private Transform newEnemyTransform;
    public GameObject Player1Token;
    public GameObject Player2Token;
    public GameObject Player3Token;
    public GameObject Player4Token;
    public GameObject Canvas;
    public Sprite CowboySprite;
    public Sprite MonkSprite;
    public Sprite RatKingSprite;
    private string newPickedChamp;
    public GameObject PickedChampGlobal;
    public int newPlayerNumber;
    public TextMeshProUGUI Team1Score;
    public TextMeshProUGUI Team2Score;
    private string Score1;
    private string Score2;
    private int KillScore1;
    private int KillScore2;
    public TextMeshProUGUI TimerTextField;
    public float time;
    private string TimerText;

    void Start()
    {
        CreateTokensAndNewScripts();
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }
    private void FixedUpdate()
    {
        InfoUpdate();
        DistanceCalculate();
        EnemyFinding1();
        EnemyFinding2();
        EnemyFinding3();
        EnemyFinding4();
    }
    public void CreateTokensAndNewScripts()
    {
        Player1Token = Instantiate(Player1, Canvas.transform);
        Player2Token = Instantiate(Player2, Canvas.transform);
        Player3Token = Instantiate(Player3, Canvas.transform);
        Player4Token = Instantiate(Player4, Canvas.transform);
        Player1.SetActive(false);
        Player2.SetActive(false);
        Player3.SetActive(false);
        Player4.SetActive(false);
        Player1Script = Player1Token.GetComponent<PlayerControl>();
        Player2Script = Player2Token.GetComponent<PlayerControl>();
        Player3Script = Player3Token.GetComponent<PlayerControl>();
        Player4Script = Player4Token.GetComponent<PlayerControl>();
        Player1Transform = Player1Token.transform;
        Player2Transform = Player2Token.transform;
        Player3Transform = Player3Token.transform;
        Player4Transform = Player4Token.transform;
    }
    public void Awake()
    {
        PickedChampGlobal = GameObject.Find("PickedChampGlobal");
        time = 60;
        OldStats();
        
    }
    public void OldStats()
    {
        newEnemyTransform = Player2Transform;
        newMe = Player1;
        newEnemy = Player2;
        newEnemyScript = Player2Script;
        newPlayerNumber = 1;
        Player1Script.PlayerNumberSelect(newPlayerNumber);
        Player1Script.PickedChampSelect(newPickedChamp);
        Player1Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        newEnemyTransform = Player1Transform;
        newMe = Player2;
        newEnemy = Player1;
        newEnemyScript = Player1Script;
        newPlayerNumber = 2;
        Player2Script.PickedChampSelect(newPickedChamp);
        Player2Script.PlayerNumberSelect(newPlayerNumber);
        Player2Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        newEnemyTransform = Player4Transform;
        newMe = Player3;
        newEnemy = Player4;
        newEnemyScript = Player4Script;
        newPlayerNumber = 3;
        Player3Script.PickedChampSelect(newPickedChamp);
        Player3Script.PlayerNumberSelect(newPlayerNumber);
        Player3Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        newEnemyTransform = Player3Transform;
        newMe = Player4;
        newEnemy = Player3;
        newEnemyScript = Player3Script;
        newPlayerNumber = 4;
        Player4Script.PickedChampSelect(newPickedChamp);
        Player4Script.PlayerNumberSelect(newPlayerNumber);
        Player4Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
    }
    public void DistanceCalculate()
    {
        
        Dist1to2 = Player1Transform.position - Player2Transform.position;
        Dist1to4 = Player1Transform.position - Player4Transform.position;
        Dist3to2 = Player3Transform.position - Player2Transform.position;
        Dist3to4 = Player3Transform.position - Player4Transform.position;
        Distance1to2 = Dist1to2.magnitude;
        Distance1to4 = Dist1to4.magnitude;
        Distance3to2 = Dist3to2.magnitude;
        Distance3to4 = Dist3to4.magnitude;
    }
    public void SpawnPlayer(int PlayerNumber)
    {
        if (PlayerNumber == 1)
        {
            Player1Token = Instantiate(Player1, Canvas.transform);
            Player1Token.SetActive(true);
        }
        if (PlayerNumber == 2)
        {
            Player2Token = Instantiate(Player2, Canvas.transform);
            Player2Token.SetActive(true);
        }
        if (PlayerNumber == 3)
        {
            Player3Token = Instantiate(Player3, Canvas.transform);
            Player3Token.SetActive(true);
        }
        if (PlayerNumber == 4)
        {
            Player4Token = Instantiate(Player4, Canvas.transform);
            Player4Token.SetActive(true);
        }
    }
    public void KillScore(int Team1, int Team2)
    {
        KillScore1 += Team1;
        KillScore2 += Team2;
        Score1 = KillScore1.ToString();
        Score2 = KillScore2.ToString();
        Team1Score.text = Score1;
        Team2Score.text = Score2;
    }
    public void EnemyFinding1()
    {
        if (Distance1to2 <= Distance1to4)
        {
            newEnemy = Player2Token;
            newEnemyScript = Player2Token.GetComponent<PlayerControl>();
            newEnemyTransform = Player2Token.transform;
            newMe = Player1Token;
            Player1Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        }
        if (Distance1to2 > Distance1to4)
        {
            newEnemy = Player4Token;
            newEnemyScript = Player4Token.GetComponent<PlayerControl>();
            newEnemyTransform = Player4Token.transform;
            newMe = Player1Token;
            Player1Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        }
    }
    public void EnemyFinding2()
    {
        if (Distance1to2 <= Distance3to2)
        {
            newEnemy = Player1Token;
            newEnemyScript = Player1Token.GetComponent<PlayerControl>();
            newEnemyTransform = Player1Token.transform;
            newMe = Player2Token;
            Player2Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        }
        if (Distance1to2 > Distance3to2)
        {
            newEnemy = Player3Token;
            newEnemyScript = Player3Token.GetComponent<PlayerControl>();
            newEnemyTransform = Player3Token.transform;
            newMe = Player2Token;
            Player2Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        }
    }
    public void EnemyFinding3()
    {
        if (Distance3to2 <= Distance3to4)
        {
            newEnemy = Player2Token;
            newEnemyScript = Player2Token.GetComponent<PlayerControl>();
            newEnemyTransform = Player2Token.transform;
            newMe = Player3Token;
            Player3Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        }
        if (Distance3to2 > Distance3to4)
        {
            newEnemy = Player4Token;
            newEnemyScript = Player4Token.GetComponent<PlayerControl>();
            newEnemyTransform = Player4Token.transform;
            newMe = Player3Token;
            Player3Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        }
    }
    public void EnemyFinding4()
    {
        if (Distance1to4 <= Distance3to4)
        {
            newEnemy = Player1Token;
            newEnemyScript = Player1Token.GetComponent<PlayerControl>();
            newEnemyTransform = Player1Token.transform;
            newMe = Player4Token;
            Player4Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        }
        if (Distance1to4 > Distance3to4)
        {
            newEnemy = Player3Token;
            newEnemyScript = Player3Token.GetComponent<PlayerControl>();
            newEnemyTransform = Player3Token.transform;
            newMe = Player4Token;
            Player4Script.PlayerStats(newEnemyTransform, newMe, newEnemy, newEnemyScript);
        }
    }
    public void InfoUpdate()
    {
        Player1Transform = Player1Token.transform;
        Player2Transform = Player2Token.transform;
        Player3Transform = Player3Token.transform;
        Player4Transform = Player4Token.transform;
        Player1Script = Player1Token.GetComponent<PlayerControl>();
        Player2Script = Player2Token.GetComponent<PlayerControl>();
        Player3Script = Player3Token.GetComponent<PlayerControl>();
        Player4Script = Player4Token.GetComponent<PlayerControl>();
    }
    public void Timer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            TimerText = time.ToString("0");
            TimerTextField.text = TimerText;
        }
        else
        {
            TimerTextField.text = "00";
            Destroy(Player1Token.GetComponent<PlayerControl>());
            Destroy(Player2Token.GetComponent<PlayerControl>());
            Destroy(Player3Token.GetComponent<PlayerControl>());
            Destroy(Player4Token.GetComponent<PlayerControl>());
        }
    }
}

