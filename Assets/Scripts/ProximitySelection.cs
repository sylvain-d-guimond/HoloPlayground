using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProximitySelection : MonoBehaviour
{
    public Transform Selector;

    public List<SelectionChoice> Choices;

    public GameObject SelectionPrefab;
    public bool Billboard = true;

    private GameObject selectorInstance;
    private SelectionChoice currentSelection;

    private void Start()
    {
        if (SelectionPrefab.scene == null)  
            selectorInstance = Instantiate(SelectionPrefab);
        else
            selectorInstance = SelectionPrefab;
    }

    private void Update()
    {
        if (Choices.Count > 0)
        {
            var nearest = Choices[0];
            var nearestDistance = float.MaxValue;

            foreach (var choice in Choices) {

                var distance = (choice.Choice.position - Selector.position).sqrMagnitude;

                if (distance < nearestDistance) {
                    nearestDistance = distance;
                    nearest = choice;
                }
            }
            
            selectorInstance.transform.position = nearest.Choice.position;
            if (Billboard) selectorInstance.transform.rotation = Camera.main.transform.rotation;
            currentSelection = nearest;
        }
    }

    public void Select()
    {
        currentSelection.Action.Invoke();
    }
}

[Serializable]
public class SelectionChoice
{
    public Transform Choice;
    public UnityEvent Action;
}
