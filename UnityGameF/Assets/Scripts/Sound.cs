using UnityEngine;

public class Sound : MonoBehaviour
{
    /// <summary>
    /// Sounds of game events.
    /// </summary>
    AudioSource sound;

    /// <summary>
    /// The start melogy.
    /// </summary>
    AudioClip audioStart;

    /// <summary>
    /// The move melogy.
    /// </summary>
    AudioClip audioMove;

    /// <summary>
    /// The win melogy.
    /// </summary>
    AudioClip audioSolved;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        sound = GetComponent<AudioSource>();

        audioStart = Resources.Load<AudioClip>("start");
        audioMove = Resources.Load<AudioClip>("move");
        audioSolved = Resources.Load<AudioClip>("solved");
    }

    /// <summary>
    /// Play the start melogy.
    /// </summary>
    public void PlayStart()
    {
        sound.PlayOneShot(audioStart);
    }

    /// <summary>
    /// Play the move melogy.
    /// </summary>
    public void PlayMove()
    {
        sound.PlayOneShot(audioMove);
    }

    /// <summary>
    /// Play the win melogy.
    /// </summary>
    public void PlaySolved()
    {
        sound.PlayOneShot(audioSolved);
    }
}
