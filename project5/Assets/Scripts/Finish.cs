using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI? ?? ??????

public class cshIndoordoorCall : MonoBehaviour
{
    public GameObject player1;
    public GameObject celebrationParticles1; // ???? ??? ?? ??? ???
    public TMP_Text warningText1; // ???? ?? ??? UI
    public Button lobbyButton1; // ?? ??
    public Slider healthSlider1; // ?? ?????
    private bool isAssetCalled1 = false; // ??? ?????? ???? ??? ??
    public static bool isSurvived1 = false; // ?????? ???? ??? ??


    // ? ????? ???? ?? ???
    public static List<GameObject> fires = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        lobbyButton1.gameObject.SetActive(false);
        celebrationParticles1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // ?? ?? ?? ???? ??? ???
    

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            
            warningText1.text = "You survived!"; 
            lobbyButton1.gameObject.SetActive(true); 
            healthSlider1.gameObject.SetActive(false); 
            celebrationParticles1.SetActive(true); 
            isSurvived1 = true;

        }
    }
}