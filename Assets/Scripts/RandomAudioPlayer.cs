using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float minDelay = 2f;
    [SerializeField] private float maxDelay = 5f;

    private float timer;

    void Start()
    {
        SetRandomTimer();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            PlaySound();
            SetRandomTimer();
        }
    }

    void SetRandomTimer()
    {
        timer = Random.Range(minDelay, maxDelay);
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}