using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    [SerializeField] AudioClip audioClip;
    [SerializeField] public string buffer;
    [SerializeField] public float maxTimeDif = 1;
    private string validPattern ="ASSIST";
    private float timeDif;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        timeDif = maxTimeDif;
    
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.PlayOneShot(audioClip);
            spriteRenderer.enabled = false;
            Invoke("LoadFirstLevel", 0.5f);
        }

        timeDif -= Time.deltaTime;
        if (timeDif <= 0)
        {
            buffer = "";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            addToBuffer("A");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            addToBuffer("S");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            addToBuffer("I");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            addToBuffer("T");
        }
        checkPatterns();
       
    }

    void addToBuffer(string c)
    {
        timeDif = maxTimeDif;
        buffer += c;
    }
    void checkPatterns()
    {
        if (buffer == validPattern)
        {
            SceneManager.LoadScene(27);
            buffer = "";
        }
        //else if(buffer.EndsWith(validPatterns[0])  // for other codes 
    }

    private void LoadFirstLevel()
    {
        
        SceneManager.LoadScene(1);
    }
}
