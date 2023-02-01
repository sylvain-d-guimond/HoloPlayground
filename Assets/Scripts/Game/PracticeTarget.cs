using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeTarget : MonoBehaviour
{
    public bool Skip { get; set; }

    private void OnDestroy()
    {
        TutorialController.Instance.Destroy(this, Skip);
    }
}
