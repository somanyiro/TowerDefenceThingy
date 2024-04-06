using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PathCreation;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemyMovementTests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("EnemyMovementTests");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EnemyMovementTest()
    {
        Enemy enemy = GameObject.FindObjectOfType(typeof(Enemy)) as Enemy;
        enemy.GetComponent<PathFollower>().speed = 20;
        Transform target = GameObject.Find("Target").transform;

        yield return new WaitForSeconds(3);
        
        Assert.LessOrEqual((enemy.transform.position - target.position).magnitude, 0.1f);

    }
}
