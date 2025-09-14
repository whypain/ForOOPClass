using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Welcome to the Farm!");

        Chicken henry = new Chicken("Henry", hunger: 30, happiness: 20);
        Cow michael = new Cow("Michael", hunger: 40, happiness: 15);

        henry.GetStatus();
        henry.Feed("corn");
        henry.MakeSound();
        henry.Sleep();
        henry.GetStatus();

        Debug.Log("-----");

        michael.GetStatus();
        michael.Feed("hay");
        michael.MakeSound();
        michael.Moo();
        michael.GetStatus();
    }
}
