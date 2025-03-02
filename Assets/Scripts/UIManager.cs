using System;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set;}

    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI timeText;
    
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Player player;
    
    private float elapsedTime;
    void Awake()
    {
        SingletonInitializer();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimeText();
    }

    private void SingletonInitializer()
    {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    private void UpdateTimeText()
    {
        int truncatedTime = Mathf.FloorToInt(elapsedTime);
        int time = Mathf.Clamp(truncatedTime, 0, 999);
        timeText.text = time.ToString();
    }

    public void UpdateUIText()
    {
        lifeText.text = "Life:" + player.Life.ToString();
    }

    public void DisplayWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void DisplayLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
