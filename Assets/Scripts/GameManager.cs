using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public TalkManager talkManager;
    public MoveScene sceneManager;

    [SerializeField]
    public Player Player;

    [SerializeField]
    public int Stage = 0;


    public static GameManager Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if(instance == null)
                {
                    Debug.Log("no singleton obj");
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(Player == null)
        {
            GameObject player =  GameObject.FindWithTag("Player");
            Player = player.GetComponent<Player>();
        }
    }
}
