using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField] int enemiesAlive;
    public Canvas PauseCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PauseCanvas.gameObject.SetActive(!PauseCanvas.gameObject.activeInHierarchy);
        }
    }

    public int EnemiesAlive
    {
        get => enemiesAlive;
        set
        {
            enemiesAlive = value;
            if (enemiesAlive <= 0)
            {
                UIManager.Instance.DisplayWinScreen();
            }
        }
    }
    private void Awake()
    {
        SingletonInitializer();
        PauseCanvas.gameObject.SetActive(false);
    }

    private void SingletonInitializer()
    {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
