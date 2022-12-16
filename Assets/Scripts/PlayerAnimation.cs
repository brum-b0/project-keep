using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{


    private Animator anim;

    public string[] idleDirs = {"idleNorth", "idleNorthWest", "idleWest", "idleSouthWest", "idleSouth", "idleSouthEast", "idleEast", "idleNorthEast"};
    public string[] runDirs = {"runNorth", "runNorthWest", "runWest", "runSouthWest", "runSouth", "runSouthEast", "runEast", "runNorthEast"};

    int lastDir;
    // Start is called before the first frame update
    void Start() {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SetDirection(Vector2 direction) {

        string[] dirs = null;

        if(direction.magnitude < 0.01) {

            dirs = idleDirs;

        } else {

            dirs = runDirs;
            lastDir = DirToIndex(direction);

        }

        anim.Play(dirs[lastDir]);
    }

    private int DirToIndex(Vector2 direction) { // convert vector2 direction to index of animation array ccw from north

        Vector2 normalDir = direction.normalized;
        float step = 360.0f / 8.0f;
        float halfStep = step / 2.0f;
        float angle = Vector2.SignedAngle(Vector2.up, normalDir);

        angle += halfStep;

        if(angle < 0) {

            angle += 360;

        }

        int index = Mathf.FloorToInt(angle / step);

        return index;

    }
}
