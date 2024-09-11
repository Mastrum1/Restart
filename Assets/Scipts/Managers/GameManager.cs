using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;

    private int _score;
    [SerializeField] private Health healthPlayer;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        healthPlayer.PlayerDead.AddListener(EndGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndGame()
    {
        //END GAME Code
        Debug.Log("THE END");
    }
}
