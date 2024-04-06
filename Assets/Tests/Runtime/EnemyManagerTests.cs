using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Linq;

public class EnemyManagerTests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("ManagerTestScene");
    }
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator WaveSpawnTest()
    {
        yield return new WaitForSeconds(0.8f);

        bool matchesConfig = true;
        Enemy[] enemies = GameObject.FindObjectsOfType(typeof(Enemy)) as Enemy[];
        if (enemies.Length != 3) matchesConfig = false;
        if (enemies.Where(x => x.type == "Alien").ToList().Count != 2) matchesConfig = false;
        if (enemies.Where(x => x.type == "Drone").ToList().Count != 1) matchesConfig = false;
        
        Assert.IsTrue(matchesConfig);
    }
}
