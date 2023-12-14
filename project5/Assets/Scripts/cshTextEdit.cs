using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class cshTextEdit : MonoBehaviour
{
    public GameObject player; //TextMeshPro 텍스트
    public TMP_Text posy;
    public Vector3 pos;

    public void Update() // 무브먼트 업데이트
    {
        pos = player.gameObject.transform.position;
        posy.text = pos.y.ToString();
    }

}