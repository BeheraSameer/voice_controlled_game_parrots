﻿using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ballBehaveTest {

	[Test]
	public void BandsTest() {
		// Use the Assert class to test conditions.

		ballBehave ball = new ballBehave();
		ball.freqLen = 8192;
		//ball.Start();
		Assert.Greater(ball.bands.Length,0);

	}

	[Test]
	public void audioTest() {
				ballBehave ball = new ballBehave();
		ball.freqLen = 8192;
		//ball.Start();
		//Assert.Greater(ball.trackModeCount,0);
		
	}




	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator NewEditModeTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
