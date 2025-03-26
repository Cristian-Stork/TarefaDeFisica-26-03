using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransferManager : MonoBehaviour
{
    public string targetSceneName = "AlternateScene";
    public string targetSceneName2 = "MainScene";
    public KeyCode transferKey = KeyCode.T;

    public List<GameObject> itens;
    public GameObject ponte;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(transferKey))
        {
            MoveObjectToAnotherScene();
        }

        Debug.Log(gameObject.scene.name);
    }

    void MoveObjectToAnotherScene()
    {
        Scene targetScene;

        if (gameObject.scene.name == targetSceneName2)
        {
            targetScene = SceneManager.GetSceneByName(targetSceneName);
        }
        else
        {
            targetScene = SceneManager.GetSceneByName(targetSceneName2);
        }

        if (targetScene != null)
        {
            SceneManager.MoveGameObjectToScene(gameObject, targetScene);
            SceneManager.MoveGameObjectToScene(ponte, targetScene);
            Debug.Log($"Objeto {gameObject.name} movido para a cena {targetSceneName}");

            for (int i = 0; i <= itens.Count; i++)
            {
                if (itens[i] == null)
                {
                    itens.RemoveAt(i);
                }

                SceneManager.MoveGameObjectToScene(itens[i], targetScene);
            }
        }
        else
        {
            Debug.LogError($"Cena {targetSceneName} não encontrada! ");
        }
    }
}
