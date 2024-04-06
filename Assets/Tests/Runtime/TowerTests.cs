using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Linq;
using PathCreation;

public class TowerTests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("TowerTestScene");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SingleTargetDamageTest()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType(typeof(Enemy)) as Enemy[];
        var enemyHealths = enemies.Select(x => x.Health).ToList();
        
        var laserTower = GameObject.FindObjectsOfType(typeof(Tower)).Single(x => (x as Tower).towerName == "Laser") as Tower;
        
        laserTower.transform.position = Vector3.zero;

        yield return new WaitForSeconds(3);
        
        Assert.IsTrue(enemies.Where(x => x.Health < enemyHealths[enemies.ToList().IndexOf(x)]).Count() == 1);//if only one enemy has taken damage
        
        laserTower.transform.position = new Vector3(0, 0, 100);
    }
    
    [UnityTest]
    public IEnumerator MultiTargetDamageTest()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType(typeof(Enemy)) as Enemy[];
        var enemyHealths = enemies.Select(x => x.Health).ToList();
        
        var shockTower = GameObject.FindObjectsOfType(typeof(Tower)).Single(x => (x as Tower).towerName == "Shock") as Tower;
        
        shockTower.transform.position = Vector3.zero;

        yield return new WaitForSeconds(3);
        
        Assert.IsTrue(enemies.All(x => x.Health < enemyHealths[enemies.ToList().IndexOf(x)]));//if all enemies have taken damage
        
        shockTower.transform.position = new Vector3(0, 0, 100);
    }

    [UnityTest]
    public IEnumerator SlowEffectTest()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType(typeof(Enemy)) as Enemy[];
        var enemySpeeds = enemies.Select(x => x.GetComponent<PathFollower>().speed).ToList();
        
        var jammerTower = GameObject.FindObjectsOfType(typeof(Tower)).Single(x => (x as Tower).towerName == "Jammer") as Tower;
        
        jammerTower.transform.position = Vector3.zero;

        yield return new WaitForSeconds(3);
        
        Assert.IsTrue(enemies.All(x => x.GetComponent<PathFollower>().speed < enemySpeeds[enemies.ToList().IndexOf(x)]));//if all enemies have slowed down
        
        jammerTower.transform.position = new Vector3(0, 0, 100);
    }
}
