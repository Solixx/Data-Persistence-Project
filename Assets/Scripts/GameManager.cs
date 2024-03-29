using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int highScore;
    public string playerName;
    public string highPlayerName;
    public List<UserData> usuarios = new List<UserData>();

    public int score_1;
    public string player_1;
    public int score_2;
    public string player_2;
    public int score_3;
    public string player_3;
    public int score_4;
    public string player_4;
    public int score_5;
    public string player_5;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        LoadUserData();
    }

    [Serializable]
    public class UserData
    {
        public string highPlayerName;
        public int highScore;
        public UserData(string name, int score)
        {
            highPlayerName = name;
            highScore = score;
        }
        
    }

    public void SaveUserData()
    {
        usuarios.Add(new UserData( highPlayerName, highScore));
        FileHandler.SaveToJSON<UserData>(usuarios, "savefile.js");

    }
    
    public void LoadUserData()
    {
        usuarios = FileHandler.ReadListFromJSON<UserData> ("savefile.js");
        foreach (UserData user in usuarios)
        {
            if (user.highScore > highScore)
            {
                highPlayerName = user.highPlayerName;
                highScore = user.highScore;
                score_1 = user.highScore;
                player_1 = user.highPlayerName;
            }
            // Maybe this is not the best way but it defines the best high scores.
            if (user.highScore > score_2 && user.highScore < score_1)
            {
                score_2 = user.highScore;
                player_2 = user.highPlayerName;
            }
            if (user.highScore > score_3 && user.highScore < score_2)
            {
                score_3 = user.highScore;
                player_3 = user.highPlayerName;
            }
            if (user.highScore > score_4 && user.highScore < score_3)
            {
                score_4 = user.highScore;
                player_4 = user.highPlayerName;
            }
            if (user.highScore > score_5 && user.highScore < score_4)
            {
                score_5 = user.highScore;
                player_5 = user.highPlayerName;
            }
        }
        
        
        Debug.Log($"{score_1}, {score_2}, {score_3}, {score_4}, {score_5}");
    }

    

}
