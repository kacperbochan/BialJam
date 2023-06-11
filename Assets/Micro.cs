using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    public bool isActive = false;
    public bool wasActive = false;

    private string selectedDevice;
    private AudioSource audioSource;
    public float volume { get; private set; }

    private float[] volumeHistory = new float[3] { 0, 0, 1 };
    private bool currentHigh = false;
    private float elapsed = 0f;
    private int count = 0;
    private int sampleIndex = 0;

    private int[] chant = new int[3] { 0, 0, 0 };
    private int chantIndex = 0;

    void Start()
    {
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
            if (elapsed >= 1f)
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

                volumeHistory[sampleIndex] = volume > 4 ? 1 : 0;
                sampleIndex = (sampleIndex + 1) % 3;

                if (volumeHistory.Sum() / 3 > 5)
                {
                    if (currentHigh == false)
                    {
                        count = 0;
                        currentHigh = true;
                    }
                    else
                        count++;

                    if (count == 4)
                    {
                        Debug.Log("RunaDu¿a");
                        chant[chantIndex++] = 1;
                    }
                    else if (count == 8)
                    {
                        //tu zawraca na 0 i jak ktoœ bêdzie dalej g³oœny, to dotrze do 3 i bêdzie liczone jako dalsza czêœæ.
                        count = 0;
                    }
                }
                else if (chantIndex > 0)
                {
                    if (currentHigh == true)
                    {
                        count = 0;
                        currentHigh = false;
                    }
                    else
                        count++;

                    if (count == 3)
                    {
                        chant[chantIndex++] = 1;
                        Debug.Log("RunaMa³a");
                    }
                    else if (count == 8)
                    {
                        //tu zawraca na 0 i jak ktoœ bêdzie dalej cichy, to dotrze do 3 i bêdzie liczone jako dalsza czêœæ.
                        count = 0;
                    }
                }

                if (chantIndex == 3)
                {
                    Debug.Log("Spell Cast");
                    chantIndex = 0;
                }

                elapsed = 0f;
            }
        
        }
        else if (wasActive)
        {
            wasActive = false;

            volumeHistory = new float[3] { 0, 0, 1 };
            currentHigh = false;
            elapsed = 0f;
            count = 0;
            sampleIndex = 0;

            chant = new int[3] { 0, 0, 0 };
            chantIndex = 0;
        }
    }
}
