using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class cshCallBox : MonoBehaviour
{
    public TMP_Text warningText; // 경고창을 위한 텍스트 UI
    public Button lobbyButton; // 로비로 가는 버튼

    void Start()
    {
        lobbyButton = GameObject.Find("Button").GetComponent<Button>();
        lobbyButton.gameObject.SetActive(false);
        // GameObject.Find를 이용하여 warningText를 찾습니다.
        // 이 때, TMP_Text 컴포넌트가 있는 GameObject의 이름이 "WarningText"이라고 가정했습니다.
        warningText = GameObject.Find("warning").GetComponent<TMP_Text>();

        // 이후의 코드...
        lobbyButton.onClick.AddListener(Lobby);
        // 초기에는 버튼을 비활성화
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") // 충돌한 객체의 태그가 "Player"인 경우
        {
            // 경고창에 메시지 표시
            warningText.text = "You survived!";
            // 충돌하면 버튼을 활성화
            lobbyButton.gameObject.SetActive(true);
        }
    }

    // 로비로 이동하는 함수
    void Lobby()
    {
        Debug.Log("Go to Lobby");
        SceneManager.LoadScene("StartScene");
    }
}
