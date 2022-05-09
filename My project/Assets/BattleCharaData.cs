using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharaData:MonoBehaviour
{
    public int charaID;
    public int level = 1;

    public new string name;
    public int hp;
    public int lp;
    public int bp;
    public int str;
    public int vit;
    public int mgc;
    public int psy;
    public int spd;

    public int HpSosa { get; set; }
    public int LpSosa { get; set; }
    public int BpSosa { get; set; }
    public int strSosa { get; set; }
    public int vitSosa { get; set; }
    public int mgcSosa { get; set; }
    public int psySosa { get; set; }
    public int spdSosa { get; set; }
    bool poisonFlag { get; set; }
    bool blindFlag { get; set; }
    bool sleepFlag { get; set; }
    bool weaknessFlag { get; set; }
    bool confuseFlag { get; set; }
    bool negativeFlag { get; set; }
    bool angerFlag { get; set; }
    bool fearFlag { get; set; }
    bool charmFlag { get; set; }
    bool purgeFlag { get; set; }
    bool stoneFlag { get; set; }
    bool deathFlag { get; set; }
}
