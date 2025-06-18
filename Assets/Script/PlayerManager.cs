using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private int playerSanity = 100;
    [SerializeField] private int loopCount = 0;

    [Header("Game State")]
    [SerializeField] private string currentLocation = "dark_room";
    [SerializeField] private bool hasDiary = false;

    [SerializeField] private List<string> playerInventory = new List<string>();
    public int PlayerHealth { get { return playerHealth; } set { playerHealth = value; } }
    public int PlayerSanity { get { return playerSanity; } set { playerSanity = value; } }
    public int LoopCount { get { return loopCount; } set { loopCount = value; } }
    public string CurrentLocation { get { return currentLocation; } set { currentLocation = value; } }
    public bool HasDiary { get { return hasDiary; } set { hasDiary = value; } }
    public List<string> PlayerInventory { get { return playerInventory; } }


    void Start()
    {

    }

    void Update()
    {
        if (playerSanity < 30)
        {
            // Lógica para Sanidade
        }

    }

    public void ChangeHealth(int amount)
    {
        playerHealth += amount;
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        if (playerHealth <= 0)
        {
            // Lógica para Game Over ou reiniciar
        }
    }
    public void ChangeSanity(int amount)
    {
        playerSanity += amount;
        playerSanity = Mathf.Clamp(playerSanity, 0, 100);
        if (playerSanity <= 0)
        {
            // Lógica para um evento de sanidade 
        }
    }

    public void AddToInventory(string itemName)
    {
        if (!playerInventory.Contains(itemName))
        {
            playerInventory.Add(itemName);
        }
    }

    private List<string> diaryMessages = new List<string>()
    {
        "Mensagem 0 (ou valor padrão)",
        "Mensagem 1",
        "Mensagem 2",
        "Mensagem 3"
    };
    
    public void IncrementLoopCount()
    {
        loopCount++;
        UpdateDiaryContent();
        ChangeSanity(-10);
        // Lógica para atualizar o diário ou eventos do loop
    }

    public void UpdateDiaryContent()
    {
        if (loopCount >= 0 && loopCount < diaryMessages.Count)
        {
            string currentMessage = diaryMessages[loopCount];
            // Lógica para exibir currentMessage no diário
        }
        else
        {
            // Lógica para lidar com loopCount fora do range 
        }
    }
}
