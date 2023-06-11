using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    public bool isActive = true;
    public bool wasActive = false;

    private string selectedDevice;
    private AudioSource audioSource;
    public float volume;

    public float[] volumeHistory = new float[3] { 0, 0, 0 };
    public bool currentHigh = false;
    public float elapsed = 0f;
    public int count = 0;
    public int sampleIndex = 0;

    public List<GameObject> Words;
    public int chantIndex = 0;

    void Start()
    {

        ClearChant();

        // SprawdŸ, czy s¹ dostêpne mikrofony
        if (Microphone.devices.Length <= 0)
        {
            Debug.LogWarning("MicrophoneInput: No microphones found");
            return;
        }

        selectedDevice = Microphone.devices[0];
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(selectedDevice, true, 1, AudioSettings.outputSampleRate);
    }

    void Update()
    {
        if(isActive)
        {
            wasActive = true; 

            elapsed += Time.deltaTime * 5f;
            if (elapsed >= 1f && chantIndex != 2) 
            {
                int sampleSize = 64;
                float[] samples = new float[sampleSize];
                audioSource.clip.GetData(samples, Microphone.GetPosition(selectedDevice));
                float sum = 0;
                foreach (float sample in samples)
                {
                    sum += Mathf.Abs(sample);
                }

                volume = sum / sampleSize * 100;

                volumeHistory[sampleIndex] = volume > 8 ? 1 : 0;
                sampleIndex = (sampleIndex + 1) % 2;

                if (volumeHistory.Sum() == 2)
                {
                    count++;

                    if (count == 1)
                    {
                        ShowRune(0);
                        chantIndex++;
                    }
                    else if (count == 4)
                    {
                        ShowRune(1);
                        chantIndex++;
                        Debug.Log("ting sound");
                    }
                }
                else if (chantIndex > 0)
                {
                    count++;
                    if (count == 4)
                    {
                        ShowRune(2);
                        chantIndex++;
                        Debug.Log("ting sound");
                    }
                }
                else
                {
                    count = 0;
                }

                if (chantIndex == 2)
                {
                    Invoke("ClearChant", 1);                  
                }

                elapsed = 0f;
            }
        
        }
        else if (wasActive)
        {
            wasActive = false;

            volumeHistory = new float[3] { 0, 0, 0 };
            currentHigh = false;
            elapsed = 0f;
            count = 0;
            sampleIndex = 0;

            ClearChant();
            chantIndex = 0;
        }
    }

    private void ShowRune(int pos)
    {
        foreach (Transform child in Words[pos].transform)
        {
            child.gameObject.gameObject.SetActive(true);
        }
    }

    private void ClearChant()
    {
        for (int i = 0; i < Words.Count; i++)
        {
            foreach (Transform child in Words[i].transform)
            {
                child.gameObject.gameObject.SetActive(false);
            }
        }
        chantIndex = 0; count = 0;
    }

    IEnumerator waiter()
    {

        //Wait for 4 seconds
        yield return new WaitForSecondsRealtime(4);


        //Wait for 2 seconds
        yield return new WaitForSecondsRealtime(2);

    }
}
