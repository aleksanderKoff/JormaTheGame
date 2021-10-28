using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileText : MonoBehaviour
{
     private TextMeshProUGUI text;
     PlayerMovement move;
     GameObject player;
     ReactionProblemCheck randomizer;
     string[] values;

     bool direction;

     //Convert string to KeyCode
    KeyCode Convert(string key)
    {
        KeyCode keyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), key);
        return keyCode;
    }

    // Start is called before the first frame update
    void Start()
    {
        direction = (Random.value < 0.5);
        player = GameObject.FindGameObjectWithTag("Player");
        randomizer = GameObject.FindGameObjectWithTag("Trigger").GetComponent<ReactionProblemCheck>();
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        text = GetComponent<TextMeshProUGUI>();
        values = randomizer.AbcRandomizer();
        text.text = values[1];
    }

    // Update is called once per frame
    void Update()
    {
        Boundaries();
        DodgeProjectile(direction);
    }

    void Boundaries()
    {
        if (player.transform.position.x < 559.0f)
        {
            direction = false;
        }
        if (player.transform.position.x > 570.0f)
        {
            direction = true;
        }
    }

    void DodgeProjectile(bool direction)
    {
        if (Input.GetKeyDown(Convert(values[1])) && direction == true)
        {
            move.DodgeLeft();
            Debug.Log("Dodged");
        }
        if (Input.GetKeyDown(Convert(values[1])) && direction == false)
        {
            move.DodgeRight();
            Debug.Log("Dodged");
        }
    }

    
}