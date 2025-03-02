using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField] int enemiesAlive;

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
