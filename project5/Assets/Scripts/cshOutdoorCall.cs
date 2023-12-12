using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI를 위한 네임스페이스

public class cshOutdoorCall : MonoBehaviour
{
    public GameObject player;
    public GameObject assetToCall; // 설치할 에셋
    public GameObject celebrationParticles; // 축하하는 효과를 위한 파티클 시스템
    public TMP_Text warningText; // 경고창을 위한 텍스트 UI
    public Button lobbyButton; // 로비 버튼
    public Slider healthSlider; // 체력 슬라이드바
    private bool isAssetCalled = false; // 에셋이 호출되었는지 확인하는 플래그 변수
    public static bool isSurvived = false; // 살아남았는지 확인하는 플래그 변수


    // 불 인스턴스를 추적하기 위한 리스트
    public static List<GameObject> fires = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        lobbyButton.gameObject.SetActive(false); // 게임 시작 시 로비 버튼 비활성화
        celebrationParticles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= 32 && !isAssetCalled) // isAssetCalled이 false일 때만 에셋을 생성
        {
            Vector3 assetToCallPosition = player.transform.position + new Vector3(Random.Range(-100f, 100f), Random.Range(-20f, 0f), Random.Range(-100f, 100f));
            GameObject newAsset = Instantiate(assetToCall, assetToCallPosition, Quaternion.identity);
            newAsset.tag = "CallBox";
            newAsset.transform.rotation = Quaternion.Euler(-90f, 0, 0); // 에셋의 x축 회전값을 -90으로 설정

            warningText.text = "Call 119"; // 경고창에 메시지 표시
            StartCoroutine(ClearTextAfterSeconds(5)); // 3초 후에 텍스트를 지우는 코루틴 시작
            isAssetCalled = true; // 에셋을 생성한 후 플래그 변수를 true로 변경
        }
    }

    // 일정 시간 후에 텍스트를 지우는 코루틴
    IEnumerator ClearTextAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds); // 지정된 초만큼 대기
        warningText.text = ""; // 텍스트 지우기
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "CallBox") // 충돌한 객체의 태그가 "AssetTag"인 경우
        {
            warningText.text = "You survived!"; // 경고창에 메시지 표시
            lobbyButton.gameObject.SetActive(true); // 충돌 감지 시 로비 버튼 활성화
            healthSlider.gameObject.SetActive(false); // 체력 슬라이드바 비활성화
            celebrationParticles.SetActive(true); // 축하하는 효과 활성화
            isSurvived = true;

            // 모든 불 인스턴스를 비활성화
            foreach (GameObject fire in fires)
            {
                fire.SetActive(false);
            }
        }
    }
}
