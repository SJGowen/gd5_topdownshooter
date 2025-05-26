using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ScoreManagerX : MonoBehaviour
{
    private int ball1Caught;
    private int ball2Caught;
    private int ball3Caught;
    private int ball1Missed;
    private int ball2Missed;
    private int ball3Missed;

    [SerializeField]
    public TextMeshProUGUI ball1CaughtGUI;
    [SerializeField]
    public TextMeshProUGUI ball2CaughtGUI;
    [SerializeField]
    public TextMeshProUGUI ball3CaughtGUI;
    [SerializeField]
    public TextMeshProUGUI ball1MissedGUI;
    [SerializeField]
    public TextMeshProUGUI ball2MissedGUI;
    [SerializeField]
    public TextMeshProUGUI ball3MissedGUI;

    public int Ball1Caught { get => ball1Caught; private set => ball1Caught = value; }
    public int Ball2Caught { get => ball2Caught; private set => ball2Caught = value; }
    public int Ball3Caught { get => ball3Caught; private set => ball3Caught = value; }
    public int Ball1Missed { get => ball1Missed; private set => ball1Missed = value; }
    public int Ball2Missed { get => ball2Missed; private set => ball2Missed = value; }
    public int Ball3Missed { get => ball3Missed; private set => ball3Missed = value; }

    public Button PlayPauseResume;
    public Toggle MuteSounds;
    public GameObject confettiPrefab;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    private void Start()
    {
        PlayPauseResume.onClick.AddListener(PlayPauseResumeClick);
        Time.timeScale = 0;
    }

    void PlayPauseResumeClick()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PlayPauseResume.GetComponentInChildren<TextMeshProUGUI>().text = "Pause";
        }
        else
        {
            Time.timeScale = 0;
            PlayPauseResume.GetComponentInChildren<TextMeshProUGUI>().text = "Resume";
        }
    }

    public void IncrementBallsCaught(GameObject gameObject)
    {
        if (gameObject.name.StartsWith("Ball 1"))
        { 
            Ball1Caught++;
            ball1CaughtGUI.text = $"{Ball1Caught}";
        }

        if (gameObject.name.StartsWith("Ball 2")) 
        {
            Ball2Caught++;
            ball2CaughtGUI.text = $"{Ball2Caught}";
        }

        if (gameObject.name.StartsWith("Ball 3")) 
        {
            Ball3Caught++;
            ball3CaughtGUI.text = $"{Ball3Caught}";
        }

        PlayAudioEffect(0);
        Instantiate(confettiPrefab, gameObject.transform.position, Quaternion.identity);
    }

    public void IncrementBallsMissed(string ballName)
    {
        if (ballName.StartsWith("Ball 1"))
        {
            Ball1Missed++;
            ball1MissedGUI.text = $"{Ball1Missed}";
        }

        if (ballName.StartsWith("Ball 2"))
        {
            Ball2Missed++;
            ball2MissedGUI.text = $"{Ball2Missed}";
        }

        if (ballName.StartsWith("Ball 3"))
        {
            Ball3Missed++;
            ball3MissedGUI.text = $"{Ball3Missed}";
        }

        PlayAudioEffect(1);
    }

    private void PlayAudioEffect(int audioEffect)
    {
        if (MuteSounds.isOn) return;
        audioSource.clip = audioClips[audioEffect];
        audioSource.PlayOneShot(audioSource.clip);
    }
}
