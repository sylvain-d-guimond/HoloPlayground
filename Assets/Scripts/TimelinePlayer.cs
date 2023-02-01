
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    private static float TOLERANCE = 0.001f;
    private PlayableDirector _director;

    public UnityEvent OnFinished;
    public UnityEvent OnFinishedReverse;

    public State After { get; set; }

    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();
    }

    public void Play(float t)
    {
        _director.timeUpdateMode = DirectorUpdateMode.Manual;
        StartCoroutine(CoPlay(t));
    }

    public void Play()
    {
        _director.timeUpdateMode = DirectorUpdateMode.GameTime;
        _director.Play();
    }

    private IEnumerator CoPlay(float speed)
    {
        if (speed < 0)
        {
            _director.time = _director.duration;
        } else
        {
            _director.time = 0;
        }

        while ((speed < 0 && _director.time >0) || (speed > 0 && _director.time < _director.duration))
        {
            yield return null;
            _director.time += Time.deltaTime * speed;
            _director.DeferredEvaluate();
        }

        if (speed < 0)
        {
            _director.time = TOLERANCE;
            _director.Pause();  
            OnFinishedReverse.Invoke();
        }
        else
        {
            _director.time = _director.duration - TOLERANCE;
            OnFinished.Invoke();
        }
        _director.Pause();

        if (After != null)
        {
            After.Active = true;
            After = null;
        }
        _director.DeferredEvaluate();
    }

    public void DoAfter(State state)
    {
        After = state;
    }
}
