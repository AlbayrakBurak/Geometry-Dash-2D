using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    private const string AttemptKey = "Attempt";
    private static GameManager _instance;

    public TMP_Text textMeshPro;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        InitializeAttempts();
    }

    private void InitializeAttempts()
    {
        int currentAttempt = PlayerPrefs.GetInt(AttemptKey, 0);
        SetAttempts(currentAttempt);
    }

    private void SetAttempts(int attempts)
    {
        PlayerPrefs.SetInt(AttemptKey, attempts);
        UpdateTextMesh(attempts);
    }

    private void UpdateTextMesh(int attempts)
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = ("Attempt " + attempts);
        }
    }

    public void IncreaseAttempts()
    {
        int currentAttempts = GetAttempts();
        currentAttempts++;
        SetAttempts(currentAttempts);
    }

    public int GetAttempts()
    {
        return PlayerPrefs.GetInt(AttemptKey, 0);
    }
}