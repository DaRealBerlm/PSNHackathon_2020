using UnityEngine;

public class MeditationManager : MonoBehaviour
{
    private bool isMeditating = false;
    private float time = 0f;

    private AudioClip[] music = null;
    private AudioSource audioSource = null;
    private int currentIndex = 0;

    public GameObject skipButton = null;
    public GameObject stopButton = null;

    private void Awake()
    {
        music = DataHandler.instance.music;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isMeditating) time += Time.deltaTime/60f;
    }

    public void ToggleMeditation()
    {
        isMeditating = !isMeditating;
        skipButton.SetActive(isMeditating);
        stopButton.SetActive(isMeditating);

        if (isMeditating)
        {
            currentIndex = Random.Range(0, music.Length);
            audioSource.PlayOneShot(music[currentIndex]);
            print($"Playing song at index {currentIndex}");
        }
        else
        {
            audioSource.Stop();
            DataHandler.instance.UpdateMeditation((int)time);
        }
    }

    public void SwitchSong()
    {
        int r = Random.Range(0, music.Length);
        while (currentIndex == r) r = Random.Range(0, music.Length); // Generate a new number, which has to be different from before
        currentIndex = r;   
        audioSource.Stop();
        audioSource.PlayOneShot(music[currentIndex]);
        print($"Swithcing song to index {currentIndex}");
    }

    public void GoBack()
    {
        if (isMeditating)ToggleMeditation();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
