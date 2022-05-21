using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    bool isLessTimeOn = false;
    public int points;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    AudioSource audioSource;
    public AudioClip pauseClip;
    public AudioClip resumeClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    MusicManager musicManager;
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }

        audioSource = GetComponent<AudioSource>();
        musicManager = GetComponentInChildren<MusicManager>();

        Debug.Log("Time" + timeToEnd + "s");
        InvokeRepeating("Stoper", 2, 1);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PlayClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    public void PauseGame()
    {
        musicManager.OnGamePaused();
        PlayClip(pauseClip);
        Debug.LogWarning("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        musicManager.OnGameResumed();
        PlayClip(resumeClip);
        Debug.LogWarning("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public bool IsGamePaused()
    {
        return gamePaused;
    }

    public void LessTimeOn()
    {
        isLessTimeOn = true;
        musicManager.Pitch(1.5f);
    }

    public void LessTimeOff()
    {
        musicManager.Pitch(1f);
    }
    void Stoper()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");

        if (timeToEnd <= 20 && !isLessTimeOn)
        {
            isLessTimeOn = true;
            LessTimeOn();
        }
        if (timeToEnd > 20 && isLessTimeOn)
        {
            isLessTimeOn = false;
            LessTimeOff();
        }
        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame == true)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke("Stopper");
        musicManager.OnGamePaused();
        if (win)
        {
            PlayClip(winClip);
            Debug.Log("You win! Reload?");
        }

        else
        {
            PlayClip(loseClip);
            Debug.Log("You lose! Reload?");
        }
    }
    public void AddPoints(int point)
    {
        points += point;
    }
    public void AddTime(int time)
    {
        timeToEnd += time;
    }
    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stoper");
        InvokeRepeating("Stoper", freeze, 1);
    }
    public void AddKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Red:
                redKey++;
                break;
            case KeyColor.Green:
                greenKey++;
                break;
            case KeyColor.Gold:
                goldKey++;
                break;
        }
    }
}
