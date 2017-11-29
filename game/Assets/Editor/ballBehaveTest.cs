using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.Audio;

public class ballBehaveTest {

    [SetUp]
    public void SetUp1() {
        ballBehave ball = new ballBehave();
        ball.minAmpVal = 0.05f;
        ball.fileName = 1;
        //ball.freqTolerance = 20;
        ball.minFreq = 200;
        ball.maxFreq = 3000;
        ball.micDuration = 15f;
        ball.minMatchCount = 5;
        ball.numBins = 8;
        ball.relativeAmpByFreq = new float[ball.freqLen];
        int n = ball.relativeAmpByFreq.Length;
    }

	[Test]
	public void BandsTest() {
		// Use the Assert class to test conditions.

		ballBehave ball = new ballBehave();
		ball.freqLen = 8192;
        ////ball.result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        ball.masterMixer = Resources.Load("Master") as AudioMixer;
        //ball.audio = GetComponent<AudioSource>();
        ////ball.pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
		Assert.Greater(ball.freqTolerance,-1);

	}

        [SetUp]
    public void SetUp2() {
        ballBehave ball = new ballBehave();
        ball.minAmpVal = 0.05f;
        ball.fileName = 1;
        ball.freqTolerance = 20;
        ball.minFreq = 200;
        ball.maxFreq = 3000;
        ball.micDuration = 15f;
        ball.minMatchCount = 5;
        ball.numBins = 8;
        ball.relativeAmpByFreq = new float[ball.freqLen];
        int n = ball.relativeAmpByFreq.Length;
    }

	[Test]
	public void audioTest() {
				ballBehave ball = new ballBehave();
		ball.freqLen = 8192;
		//ball.Start();
        //ball.result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        ball.masterMixer = Resources.Load("Master") as AudioMixer;
        //ball.audio = GetComponent<AudioSource>();
        //ball.pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
		Assert.AreEqual(ball.trackModeCount,0);
		
	}

    [SetUp]
    public void SetUp3() {
        ballBehave ball = new ballBehave();
        ball.minAmpVal = 0.05f;
        ball.fileName = 1;
        ball.freqTolerance = 20;
        //ball.minFreq = 200;
        ball.maxFreq = 3000;
        ball.micDuration = 15f;
        ball.minMatchCount = 5;
        ball.numBins = 8;
        ball.relativeAmpByFreq = new float[ball.freqLen];
        int n = ball.relativeAmpByFreq.Length;
    }

    [Test]
    public void FreqTest() {
        // Use the Assert class to test conditions.

        ballBehave ball = new ballBehave();
        ball.freqLen = 8192;
                //ball.result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        ball.masterMixer = Resources.Load("Master") as AudioMixer;
        //ball.audio = GetComponent<AudioSource>();
        //ball.pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
        Assert.Greater(ball.minFreq,-1);

    }
    [SetUp]
    public void SetUp4() {
        ballBehave ball = new ballBehave();
        ball.minAmpVal = 0.05f;
        ball.fileName = 1;
        ball.freqTolerance = 20;
        ball.minFreq = 200;
        //ball.maxFreq = 3000;
        ball.micDuration = 15f;
        ball.minMatchCount = 5;
        ball.numBins = 8;
        ball.relativeAmpByFreq = new float[ball.freqLen];
        int n = ball.relativeAmpByFreq.Length;
    }

    [Test]
    public void MaxFreqTest() {
        // Use the Assert class to test conditions.

        ballBehave ball = new ballBehave();
        ball.freqLen = 8192;
        //ball.updateBallPos();
                //ball.result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        ball.masterMixer = Resources.Load("Master") as AudioMixer;
        //ball.audio = GetComponent<AudioSource>();
        //ball.pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
        Assert.Greater(ball.maxFreq,-1);

    }

    [SetUp]
    public void SetUp5() {
        ballBehave ball = new ballBehave();
        ball.minAmpVal = 0.05f;
        ball.fileName = 1;
        ball.freqTolerance = 20;
        ball.minFreq = 200;
        ball.maxFreq = 3000;
        ball.micDuration = 15f;
        ball.minMatchCount = 5;
        //ball.numBins = 8;
        ball.relativeAmpByFreq = new float[ball.freqLen];
        int n = ball.relativeAmpByFreq.Length;
    }

    [Test]
    public void BinsTest() {
        // Use the Assert class to test conditions.

        ballBehave ball = new ballBehave();
        ball.freqLen = 8192;
                //ball.result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        ball.masterMixer = Resources.Load("Master") as AudioMixer;
        //ball.audio = GetComponent<AudioSource>();
        //ball.pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
        Assert.Greater(ball.numBins,-1);

    }
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

[SetUp]
    public void SetUp6() {
        ballBehave ball = new ballBehave();
        ball.minAmpVal = 0.05f;
        ball.fileName = 1;
        //ball.freqTolerance = 20;
        ball.minFreq = 200;
        ball.maxFreq = 3000;
        ball.micDuration = 15f;
        ball.minMatchCount = 5;
        ball.numBins = 8;
        ball.relativeAmpByFreq = new float[ball.freqLen];
        int n = ball.relativeAmpByFreq.Length;
    }

    [Test]
    public void freqToleranceTest() {
        // Use the Assert class to test conditions.

        ballBehave ball = new ballBehave();
        ball.freqLen = 8192;
                //ball.result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        ball.masterMixer = Resources.Load("Master") as AudioMixer;
        //ball.audio = GetComponent<AudioSource>();
        //ball.pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
        Assert.Greater(ball.freqTolerance,-1);

    }

    [SetUp]
    public void SetUp7() {
        ballBehave ball = new ballBehave();
        ball.minAmpVal = 0.05f;
        ball.fileName = 1;
        ball.freqTolerance = 20;
        ball.minFreq = 200;
        ball.maxFreq = 3000;
        //ball.micDuration = 15f;
        ball.minMatchCount = 5;
        ball.numBins = 8;
        ball.relativeAmpByFreq = new float[ball.freqLen];
        int n = ball.relativeAmpByFreq.Length;
    }

    [Test]
    public void micDurationTest() {
        // Use the Assert class to test conditions.

        ballBehave ball = new ballBehave();
        ball.freqLen = 8192;
                //ball.result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        ball.masterMixer = Resources.Load("Master") as AudioMixer;
        //ball.audio = GetComponent<AudioSource>();
        //ball.pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
        Assert.Greater(ball.micDuration,-1);

    }

    [SetUp]
    public void SetUp8() {
        ballBehave ball = new ballBehave();
        //ball.minAmpVal = 0.05f;
        ball.fileName = 1;
        ball.freqTolerance = 20;
        ball.minFreq = 200;
        ball.maxFreq = 3000;
        ball.micDuration = 15f;
        ball.minMatchCount = 5;
        ball.numBins = 8;
        ball.relativeAmpByFreq = new float[ball.freqLen];
        int n = ball.relativeAmpByFreq.Length;
    }

    [Test]
    public void AmplitudeTest() {
        // Use the Assert class to test conditions.

        ballBehave ball = new ballBehave();
        ball.freqLen = 8192;
                //ball.result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        ball.masterMixer = Resources.Load("Master") as AudioMixer;
        //ball.audio = GetComponent<AudioSource>();
        //ball.pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
        Assert.Greater(ball.minAmpVal,-1);
    }

    [Test]
    public void SessionTest() {
        // Use the Assert class to test conditions.

        ballBehave ball = new ballBehave();
        ball.freqLen = 8192;
                //ball.result = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        ball.masterMixer = Resources.Load("Master") as AudioMixer;
        //ball.audio = GetComponent<AudioSource>();
        //ball.pilot = GameObject.Find ("PilotNote").GetComponent<currNote> ();
        Assert.Greater(ball.sessionCount,-1);
    }
    [SetUp]
    public void SetUp9() {
        ballBehave ball = new ballBehave();
        ball.minAmpVal = 0.05f;
        ball.fileName = 1;
        ball.freqTolerance = 20;
        ball.minFreq = 200;
        ball.maxFreq = 3000;
        ball.micDuration = 15f;
        ball.minMatchCount = 5;
        ball.numBins = 8;
        ball.relativeAmpByFreq = new float[ball.freqLen];
        int n = ball.relativeAmpByFreq.Length;
    }
	[UnityTest]
	public IEnumerator NewEditModeTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
