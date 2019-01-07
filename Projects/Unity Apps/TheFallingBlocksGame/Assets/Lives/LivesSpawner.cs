using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LivesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject LivesUIElementPrefab;
    [SerializeField] private LivesUI livesUI;

    private List<GameObject> livesUIElements = new List<GameObject>();

    private void Start()
    {
        SpawnLives();
        RemoveOneLive();
    }

    public void SpawnLives()
    {
       var livesUILocations = livesUI.GetLivesUILocations();

        for (int i = 0; i < livesUILocations.Count; i++)
        {
            var livesUIElement = Instantiate(LivesUIElementPrefab, transform);
            livesUIElement.name = "Lives " + i;
            livesUIElement.transform.position = livesUILocations[i];
            livesUIElements.Add(livesUIElement);
        }
    }

    public void RemoveOneLive()
    {
        var lastElement = livesUIElements.Last();
        lastElement.GetComponent<Rigidbody>().isKinematic = false;
        livesUIElements.Remove(lastElement);

        Destroy(lastElement, 2f);

    }

}
