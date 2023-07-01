
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _currentLifesText;

    private int _currentLifes = 10;


    private void OnEnable()
    {
        EndDestination.OnEndDestinationReached += ActualizeText;
        EndDestination.OnEndDestinationReached += checkIfLoose;
        _currentLifesText.text = $"Lives:{_currentLifes.ToString()}";
    }

    private void ActualizeText()
    {
       
        _currentLifesText.text = $"Lives:{_currentLifes.ToString()}";
    }

    private void OnDisable()
    {
        EndDestination.OnEndDestinationReached -= ActualizeText;
        EndDestination.OnEndDestinationReached -= checkIfLoose;


    }

    private void checkIfLoose()
    {
        _currentLifes--;

        if (_currentLifes <= 0)
        {
            SceneManager.LoadScene("MENU");
        }
    }
    
}
