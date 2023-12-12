using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class cshTextEdit : MonoBehaviour
{
    public TMP_Text textSpeed; //TextMeshPro 텍스트
    public Vector3 pos;

    public void Update() // 무브먼트 업데이트
    {
        pos = this.gameObject.transform.position;
        textSpeed.text = pos.y.ToString();
    }

}
