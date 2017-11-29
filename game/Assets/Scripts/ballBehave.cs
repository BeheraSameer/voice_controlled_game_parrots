using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ballBehave : MonoBehaviour
{
    public int freqLen = 8192;
    public AudioMixer masterMixer;
    public AudioSource audio;
    public AudioSource audio2;
    public float[] relativeAmpByFreq;
    public float[] bands;
    public GameObject[] gameObject;
    public int[] maxIndices;
    public int minFreq;
    public int maxFreq;
    public int modeIndex;
    public int freqTolerance;
    public int fileName;
    public int trackModeCount;
    public bool micOn;
	public float micDuration;
	public int minMatchCount;
	public float minAmpVal;
    public int numBins;
	public bool breakMatchWait;
	public int sessionCount;

    public GameManagerScript result;
    public currNote pilot;

    IEnumerator Start()
    {
		// The output was different for android device with different sampling rate. Fix the sampling rate in code to avoid this error.
		AudioSettings.outputSampleRate = 24000;
        minAmpVal = 0.002f;
        fileName = 1;
        freqTolerance = 200;
        minFreq = 200;
        maxFreq = 2000;
		micDuration = 30f;
		minMatchCount = 1;
        numBins = 8;
		sessionCount = 10;
        relativeAmpByFreq = new float[freqLen];
        int n = relativeAmpByFreq.Length;

        result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        int k = 0;
        for (int j = 0; j < relativeAmpByFreq.Length && n > 0; j++)
        {
            k++;
            n /= 2;
        }
        bands = new float[k + 1];
        masterMixer = Resources.Load("Master") as AudioMixer;
		if (masterMixer == null)
			Debug.Log("masterMixer not set");

		for(int sessionIter = 0; sessionIter < sessionCount; sessionIter++) {
			for(int iter = 1; iter <= 8; iter++) {
				micOn = false;
				result.clear();

				for(int iter5 = 1; iter5 <=8 ; iter5++) {
					GameObject.Find("" + iter5).GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.4f);
				}
				// play audio from mp3
				// yield return new WaitForSeconds(5f);
				audio = GetComponent<AudioSource>();
				masterMixer.SetFloat("ToggleSpeaker", 0f);
				audio.clip = (AudioClip)Resources.Load(fileName.ToString());
				audio.Play();
				StartCoroutine(modeHelperAudio());
				// we need to add delay to avoid race condition
				yield return new WaitForSeconds(audio.clip.length + 1f);

				for(int iter5 = (modeIndex + (-1 * freqTolerance)); iter5 <= (modeIndex + freqTolerance) && iter5 >= minFreq && iter5 <= maxFreq; iter5 += freqTolerance) {
					// sum of iter5 and required bin is numBins + 2
					GameObject.Find("" + (numBins + 2 - (iter5 / freqTolerance))).GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
				}
				masterMixer.SetFloat("ToggleSpeaker", -80f);
				// System.Threading.Thread.Sleep(5000);
				audio.clip = Microphone.Start("Built-in Microphone", true, 10, 24000);
				audio.loop = true;
				while (!(Microphone.GetPosition(null) > 0)) { }
				audio.Play();
				// masterMixer.SetFloat("ToggleSpeaker", 0f);

				// tracking Mode and ModeCount for matching continuous frames
				breakMatchWait = false;
				trackModeCount = 0;
				StartCoroutine(modeHelperMic());
				int iter3 = 0;
				while(!breakMatchWait && iter3 < micDuration) {
					yield return new WaitForSeconds(1f);
					iter3 ++;
				}
				Microphone.End(null);
				audio.loop = false;
				result.setNotMatch();
				// we need to wait to display the output
				yield return new WaitForSeconds(1f);
				fileName++;
			}
			fileName = 1;
		}
		// go back to main menu!!!
    }

    IEnumerator modeHelperAudio()
    {
        // the fps is 15
        maxIndices = new int[freqLen];
        InvokeRepeating("updateBallPos", 0.0f, 1.0f / 15.0f);
        yield return new WaitForSeconds(audio.clip.length);
        CancelInvoke();
        int modeVal = 0;
        for (int i = minFreq; i < maxFreq; i++)
        {
            if (modeVal < maxIndices[i])
            {
                modeVal = maxIndices[i];
                modeIndex = i;
            }
        }
		modeIndex = (modeIndex - (modeIndex % 100));
    }

    IEnumerator modeHelperMic()
    {
        // the fps is 15
        maxIndices = new int[freqLen];
        micOn = true;
        InvokeRepeating("updateBallPos", 0.0f, 1.0f / 15.0f);
		int iter4 = 0;
		while(!breakMatchWait && iter4 < micDuration) {
			yield return new WaitForSeconds(1f);
			iter4++;
		}
        CancelInvoke();
        int tmpVal = 0;
        int tmpIndex = 0;
        for (int i = minFreq; i < maxFreq; i++)
        {
            if (tmpVal < maxIndices[i])
            {
                tmpVal = maxIndices[i];
                tmpIndex = i;
            }
        }
    }

    private void updateBallPos()
    {
        // Need to experiment with FFTWindow for filtering
        audio.GetSpectrumData(relativeAmpByFreq, 0, FFTWindow.Rectangular);

        int k = 0;
        int crossover = 2;
        float speed = 2.0f;
        float maxVal = -84f;
        int maxIndex = 0;

        for (int i = minFreq; i < maxFreq; i++)
        {
            if (relativeAmpByFreq[i] > maxVal)
            {
                maxIndex = i;
                maxVal = relativeAmpByFreq[i];
            }
        }

		// Debug.Log("maxVal is" + maxVal);
		if(maxVal > minAmpVal)
			maxIndices[maxIndex]++;
		// Debug.Log("maxIndex is " + maxIndex);
		// Debug.Log("modeIndex is " + modeIndex);

        if (micOn)
        {
            if ((maxVal > minAmpVal) && (maxIndex >= modeIndex + (-1 * freqTolerance)) && (maxIndex < modeIndex + freqTolerance))
            {
                trackModeCount++;
                if (trackModeCount >= minMatchCount)
                {
                    Debug.Log("Freq matched");
                    result.setMatch();
					masterMixer.SetFloat("ToggleSpeaker", 0f);
					audio.clip = (AudioClip)Resources.Load("sq");
					audio.Play();
					// yield return new WaitForSeconds(audio.clip.length + 1f);
					// masterMixer.SetFloat("ToggleSpeaker", -80f);
					breakMatchWait = true;
                    CancelInvoke();
                }
            }
            else
            {
                trackModeCount = 0;
            }
        }
        else
        {
			// Debug.Log("Mic off");
		}
		float posYDiff = 1.339527f/5.0f;
		float posYLast = 4.6f + (1.339527f/2);//4.6f; Setting the initial position of the pilot note
		int binRange = (maxFreq - minFreq) / (numBins*5);
		float posY = (maxIndex - minFreq) / binRange * posYDiff - posYLast;
		pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
		pilot.updatePosition (posY);
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) 
        Application.Quit();
        // Update is also invoked repeatedly with a fixed fps 
        //need to check if we can remove verfiy updateBallPos
    }
	
}
