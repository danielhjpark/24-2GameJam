using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Vector3 cameraPosition;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    Vector2 mapSize;

    [SerializeField]
    float cameraMoveSpeed;
    float height;
    float width;

    [SerializeField]
    Transform clearCameratr;

    [SerializeField]
    Transform nowTarget;

    [SerializeField]
    public bool stageClear = false;

    [SerializeField]
    public bool sceneDone = false;

    [SerializeField]
    private StageChat stageChat;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        nowTarget = playerTransform;

        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        if(stageClear && nowTarget != clearCameratr && sceneDone == false)
        {
            nowTarget = clearCameratr;
            StartCoroutine(delay());
        }
        else if(sceneDone == true)
        {
            nowTarget = playerTransform;
        }

        LimitCameraArea();
    }

    IEnumerator delay()
    {
        GameManager.Instance.Player.gameObject.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        stageChat.ShowDialogue();
    }
    void LimitCameraArea()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          nowTarget.position + cameraPosition,
                                          Time.deltaTime * cameraMoveSpeed);
        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("씬로드");
        clearCameratr = GameObject.Find("CameraTarget").GetComponent<Transform>();
    }

    //대화 끝났을 때 playerTransform = GameObject.Find("Player").GetComponent<Transform>(); 해줘야 플레이어로 카메라 돌아감.
}