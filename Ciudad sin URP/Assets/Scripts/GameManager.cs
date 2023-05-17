using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public GameState State;

	public static event Action<GameState> OnGameStateChanged;
	
	public int frame;
	
	void Awake(){
		instance = this;
        Debug.Log("Saliste del videojuego");
    }

	public void UpdateGameState(GameState newState){
		State = newState;

		switch (newState)
        {
             case GameState.Inicio:

                break;
            case GameState.Rodrigo:
                
                break;
            case GameState.WillyRex: 
                
                break;
            case GameState.Alberto:
                
                break;
            case GameState.NPCCasero:
                
                break;
            case GameState.Chema:
                
                break;
            case GameState.Marisa:
                
                break;
            case GameState.oceloteVentana:
                
                break;
            case GameState.Victoria:
                
                break;
            case GameState.Perder:
                
                break;
            case GameState.Llave:
                
                break;
            case GameState.Nft:
                
                break;
            case GameState.Nino:
                
                break;
             case GameState.globo:
                
                break;
        
            default:
            	throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
                break;
        }

        OnGameStateChanged?.Invoke(newState);
	}

	public enum GameState {
		Inicio,
		Rodrigo,
		WillyRex,
		Alberto,
		NPCCasero,
		Chema,
		Marisa,
		oceloteVentana,
		Victoria,
		Perder,
		Llave,
		Nft,
		Nino,
		globo
	}


	public void Start()
	{
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        Debug.Log("Let him cook");
        yield return new WaitUntil(() => frame >= 2000);
        Debug.Log("Go to menu");
        iniciojuego();
        tpmenu();
    }

	void Update()
    {
        if (frame <= 2000)
        {
            Debug.Log("Frame: " + frame);
            frame++;
        }
    }

	private void iniciojuego(){
        UpdateGameState(GameState.Inicio);
    }

    public void tpmenu()
    {
    	//System.Threading.Thread.Sleep(5000); //Attempt of a wait script  
        SceneManager.LoadScene("Scene Menu"); //Cargo la escena de inicio
    }
}
