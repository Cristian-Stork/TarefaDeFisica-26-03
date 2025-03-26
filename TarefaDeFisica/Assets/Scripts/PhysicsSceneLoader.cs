using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsSceneLoader : MonoBehaviour
{
    public string physicsSceneName;
    public float physicsSceneTimeScale = 1;
    private PhysicsScene physicScene;

    // Start is called before the first frame update
    void Start()
    {
        LoadSceneParameters param = new LoadSceneParameters(LoadSceneMode.Additive, LocalPhysicsMode.Physics3D);
        Scene scene = SceneManager.LoadScene(physicsSceneName, param);
        physicScene = scene.GetPhysicsScene();
    }

    private void FixedUpdate()
    {
        if (physicScene != null)
        {
            physicScene.Simulate(Time.fixedDeltaTime * physicsSceneTimeScale);
        }
    }
}
