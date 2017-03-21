using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player : MonoBehaviour {

    public string name;
    public int points;
    public string id = "1";

    public void setScore(int score) {
        this.points = score;
    }

    public void setPlayerName(string playerName) {
        this.name = playerName;
    }
}
