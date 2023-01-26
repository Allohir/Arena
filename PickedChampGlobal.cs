using UnityEngine;

public class PickedChampGlobal : MonoBehaviour
{
    [SerializeField]
    private static PickedChampGlobal Instance;
    private string PickedChamp1;
    private string PickedChamp2;
    private string PickedChamp3;
    private string PickedChamp4;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void SetChampPicked(string NewPickedChamp1, string NewPickedChamp2, string NewPickedChamp3, string NewPickedChamp4)
    {
        PickedChamp1 = NewPickedChamp1;
        PickedChamp2 = NewPickedChamp2;
        PickedChamp3 = NewPickedChamp3;
        PickedChamp4 = NewPickedChamp4;
    }
}
