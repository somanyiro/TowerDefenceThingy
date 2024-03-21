using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemyManagerTests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("TestScene");
    }
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EnemyManagerTestsWithEnumeratorPasses()
    {
        //Assert.NotNull(EnemyManager.Instance);
        yield return null;
    }
}
