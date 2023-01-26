using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Transform EnemyTransform;
    public Rigidbody2D rb;
    public Vector2 movement;
    public float MoveSpeed;
    public GameObject GlobalObject;
    public GlobalControl GlobalControl;
    public GameObject Enemy;
    public GameObject Me;
    public PlayerControl EnemyScript;
    public float AtackRange;
    public float AD;
    public float FisDef;
    public float HP;
    public float AtackSpeed;
    public float AACD;
    public float time;
    public float CDR;
    public float ACC;
    public TextMeshProUGUI HPBarText;
    public string HPBar;
    public string PickedChamp;
    public Sprite Sprite;
    public SpriteRenderer spriteRenderer;
    public GameObject PickedChampGlobal;
    public int PlayerNumber;
    public float Distance;
    public GameObject Player1Token;
    public GameObject Player2Token;
    public GameObject Player3Token;
    public GameObject Player4Token;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public bool CowboySpellActive;
    public float Duration;
    public Animator anim;

    void Start()
    {
        PlayerControlStart();
        
    }
    void Awake()
    {
        switch (PickedChamp)
        {
            case "Cowboy":
                CowboyPicked();
                break;
            case "Monk":
                MonkPicked();
                break;
            case "RatKing":
                RatKingPicked();
                break;
        }
        ACC = 1;
        CDR = 0;
        Duration = 1;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        AACD -= Time.deltaTime;
        CDR -= Time.deltaTime;
        Duration -= Time.deltaTime;
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Player3 = GameObject.Find("Player3");
        Player4 = GameObject.Find("Player4");
        anim.SetFloat("AA", AACD);    
    }
    private void FixedUpdate()
    {
        movement = EnemyTransform.position - transform.position;
        movement = movement.normalized;
        Distance = Vector2.Distance(EnemyTransform.position, transform.position);
        if (Vector3.Distance(EnemyTransform.position, transform.position) > AtackRange)
        {
            MoveChar();
        }
        else
        {
            if (ACC == 1 && AACD < 0)
            {
                float newHP;
                newHP = Enemy.GetComponent<PlayerControl>().HP - AD;
                EnemyScript.SetHP(newHP);
                AACD = AtackSpeed;
            }
        }
        if (CDR < 0 && PickedChamp == "Cowboy")
        {
            CowboySpell();
        }
        if (CowboySpellActive == true)
        {
            ACC = Random.Range(1, 3);
            if (Duration < 0)
            {
                CowboySpellActive = false;
                AtackSpeed = GlobalObject.GetComponent<Cowboy>().AtackSpeed;
                CDR = GlobalObject.GetComponent<Cowboy>().CDR;
                ACC = 1;
            }
        }
        if (HP <= 0)
        {
            if (PlayerNumber == 1 || PlayerNumber == 3)
            {
                GlobalControl.KillScore(0, 1);
            }
            if (PlayerNumber == 2 || PlayerNumber == 4)
            {
                GlobalControl.KillScore(1, 0);
            }
            GlobalControl.SpawnPlayer(PlayerNumber);
            Destroy(Me);
        }
        HPBar = HP.ToString();
        HPBarText.text = HPBar;
    }
    private void MoveChar()
    {
        rb.MovePosition(rb.position + MoveSpeed * Time.deltaTime * movement);
    }
    public void SetHP(float newHP)
    {
        HP = newHP;
    }
    public void PlayerStats(Transform newEnemyTransform, GameObject newMe, GameObject newEnemy, PlayerControl newEnemyScript)
    {
        EnemyTransform = newEnemyTransform;
        Me = newMe;
        Enemy = newEnemy;
        EnemyScript = newEnemyScript;
    }
    public void PlayerControlStart()
    {
        rb = this.GetComponent<Rigidbody2D>();
        AACD = 0.0f;
        time = 1;
    }
    public void CowboyPicked()
    {
            AtackRange = GlobalObject.GetComponent<Cowboy>().AtackRange;
            AD = GlobalObject.GetComponent<Cowboy>().AD;
            FisDef = GlobalObject.GetComponent<Cowboy>().FisDef;
            HP = GlobalObject.GetComponent<Cowboy>().HP;
            MoveSpeed = GlobalObject.GetComponent<Cowboy>().MoveSpeed;
            AtackSpeed = GlobalObject.GetComponent<Cowboy>().AtackSpeed;
            CDR = GlobalObject.GetComponent<Cowboy>().CDR;
            Sprite = GlobalObject.GetComponent<GlobalControl>().CowboySprite;
            spriteRenderer.sprite = Sprite;
    }
    public void MonkPicked()
    {
            AtackRange = GlobalObject.GetComponent<Monk>().AtackRange;
            AD = GlobalObject.GetComponent<Monk>().AD;
            FisDef = GlobalObject.GetComponent<Monk>().FisDef;
            HP = GlobalObject.GetComponent<Monk>().HP;
            MoveSpeed = GlobalObject.GetComponent<Monk>().MoveSpeed;
            AtackSpeed = GlobalObject.GetComponent<Monk>().AtackSpeed;
            CDR = GlobalObject.GetComponent<Monk>().CDR;
            Sprite = GlobalObject.GetComponent<GlobalControl>().MonkSprite;
            spriteRenderer.sprite = Sprite;
    }
    public void RatKingPicked()
    {
            AtackRange = GlobalObject.GetComponent<RatKing>().AtackRange;
            AD = GlobalObject.GetComponent<RatKing>().AD;
            FisDef = GlobalObject.GetComponent<RatKing>().FisDef;
            HP = GlobalObject.GetComponent<RatKing>().HP;
            MoveSpeed = GlobalObject.GetComponent<RatKing>().MoveSpeed;
            AtackSpeed = GlobalObject.GetComponent<RatKing>().AtackSpeed;
            CDR = GlobalObject.GetComponent<RatKing>().CDR;
            Sprite = GlobalObject.GetComponent<GlobalControl>().RatKingSprite;
            spriteRenderer.sprite = Sprite;
    }
    public void PickedChampSelect(string newPickedChamp)
    {
        PickedChamp = newPickedChamp;
    }
    public void PlayerNumberSelect(int newPlayerNumber)
    {
        PlayerNumber = newPlayerNumber;
    }
    public void CowboySpell()
    {
        CowboySpellActive = true;
        AtackSpeed = 0.3f;
        Duration = 3.5f;
        CDR = GlobalObject.GetComponent<Cowboy>().CDR + Duration;
    }
}