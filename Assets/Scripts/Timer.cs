
/// <summary>
/// Simple timer class I wrote back in GXP times
/// </summary>
public class Timer
{
    float waitTime;
    float timeSinceStart = 0;
    public bool finished = false;
    public bool finishedThisFrame = false;
    public float timeLeft = 0;
    public Timer(float waitTime = 1)
    {
        this.waitTime = waitTime;
        Reset();
    }

    public void AdvanceTimer(float delta)
    {
        if (finished)
        {
            if (finishedThisFrame) finishedThisFrame = false;

            return;
        }

        timeSinceStart += delta;
        timeLeft = waitTime - timeSinceStart;
        if (timeSinceStart >= waitTime)
        {
            finished = true;
            finishedThisFrame = true;
            timeLeft = 0;
        }
    }

    public void Reset()
    {
        timeSinceStart = 0;
        finished = false;
        finishedThisFrame = false;
        timeLeft = waitTime;
    }

    public void SetWaitTime(float waitTime)
    {
        this.waitTime = waitTime;
    }

}