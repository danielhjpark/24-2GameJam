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
        }
        else if(sceneDone == true)
        {
            nowTarget = playerTransform;
        }
            LimitCameraArea();
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
        Debug.Log("���ε�");
        clearCameratr = GameObject.Find("CameraTarget").GetComponent<Transform>();
    }

    //��ȭ ������ �� playerTransform = GameObject.Find("Player").GetComponent<Transform>(); ����� �÷��̾�� ī�޶� ���ư�.
}