using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Picker : MonoBehaviour
{
    [SerializeField]
    private string PickedChamp1;
    private string PickedChamp2;
    private string PickedChamp3;
    private string PickedChamp4;
    private int PickNumber;
    private GameObject Cowboy;
    private GameObject Monk;
    private GameObject RatKing;
    private GameObject LeftPick;
    private GameObject RightPick;
    private GameObject Play;
    private PickedChampGlobal PickedChampGlobal;

    // Start is called before the first frame update
    void Start()
    {
        RightPick.SetActive(false);
        Play.SetActive(false);
    }

    public void PickedCowboy()
    {
            switch (PickNumber)
        {
            case 1:
                PickedChamp1 = "Cowboy";
                PickNumber++;
                RightPick.SetActive(true);
                LeftPick.SetActive(false);
                break;
            case 2:
                PickedChamp1 = "Cowboy";
                PickNumber++;
                RightPick.SetActive(false);
                LeftPick.SetActive(true);
                break;
            case 3:
                PickedChamp1 = "Cowboy";
                PickNumber++;
                RightPick.SetActive(true);
                LeftPick.SetActive(false);
                break;
            case 4:
                PickedChamp1 = "Cowboy";
                Play.SetActive(true);
                PickEnd();
                break;
        }
    }
    public void PickedMonk()
    {
        switch (PickNumber)
        {
            case 1:
                PickedChamp1 = "Monk";
                PickNumber++;
                RightPick.SetActive(true);
                LeftPick.SetActive(false);
                break;
            case 2:
                PickedChamp1 = "Monk";
                PickNumber++;
                RightPick.SetActive(false);
                LeftPick.SetActive(true);
                break;
            case 3:
                PickedChamp1 = "Monk";
                PickNumber++;
                RightPick.SetActive(true);
                LeftPick.SetActive(false);
                break;
            case 4:
                PickedChamp1 = "Monk";
                Play.SetActive(true);
                PickEnd();
                break;
        }
    }
    public void PickedRatKing()
    {
        switch (PickNumber)
        {
            case 1:
                PickedChamp1 = "RatKing";
                PickNumber++;
                RightPick.SetActive(true);
                LeftPick.SetActive(false);
                break;
            case 2:
                PickedChamp1 = "RatKing";
                PickNumber++;
                RightPick.SetActive(false);
                LeftPick.SetActive(true);
                break;
            case 3:
                PickedChamp1 = "RatKing";
                PickNumber++;
                RightPick.SetActive(true);
                LeftPick.SetActive(false);
                break;
            case 4:
                PickedChamp1 = "RatKing";
                Play.SetActive(true);
                PickEnd();
                break;
        }
    }
    public void PlayPressed()
    {
        SceneManager.LoadScene("Arena");
    }
    public void PickEnd()
    {
        Cowboy.GetComponent<Button>().interactable = false;
        Monk.GetComponent<Button>().interactable = false;
        RatKing.GetComponent<Button>().interactable = false;
        PickedChampGlobal.SetChampPicked(PickedChamp1, PickedChamp2, PickedChamp3, PickedChamp4);
    }    
}