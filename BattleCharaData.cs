using UnityEngine;

public abstract class BattleCharaData : MonoBehaviour, IBasicAction
{ public int charaID;



    public int level{get;set;}


    public charadata charadata1;
    public string Name{get;set;}
    public string job;
   public Skill[] useSkills=new Skill[11];
    public UserDatawithSkillData userDatawithSkillData;
    public Equipment sobiWeapon{get;set;}
     public Equipment sobiMainBogu{get;set;}
    public Equipment sobiSubBogu{get;set;}
    public Equipment accessory{get;set;}
    public GameObject[] buttonSet = new GameObject[11];
   
    public GameObject battleManager;
    public BattleManager1 battleManager1;
    public GameObject canvas;
public IBasicAction[] playerData;
public IBasicAction[] enemyData;
public IBasicAction[] memberData;
    public int memberNumber;
    public int seiko;



    private int maxHp;
   
    public bool ActionEnd { get; set; }
   
    public int MemberNumber
    {
        get; set;
    }
    public Vector2 charaPos
    {
        get; set;
    }
    public int MaxHpSet
    {
        set
        {
            if (maxHp+value < 0)
            {
                maxHp = 1;
            }
            else if (maxHp+value > 9999)
            {
                maxHp = 9999;
            }
            else
            {
                maxHp += value;
            }
        }
        get
        {
            return maxHp;
        }
    }

    private int hp;

    public int HpSet
    {
        set
        {
            if (hp - value <= 0)
            {
                hp = 0;
                lp--;
            }
            else if (hp - value > maxHp)
            {
                hp = maxHp;
            }
            else
            {
                hp -= value;
            }

        }
        get
        {
            return hp;
        }
    }

    private int maxLp;
    public int MaxLpSet
    {
        set
        {
            if (maxLp+value < 0)
            {
                maxLp = 1;
            }
            else if (maxLp+value > 99)
            {
                maxLp = 99;
            }
            else { maxLp += value; };
        }
        get { return maxLp; }
    }
    private int lp;
    public int LpSet
    {
        set
        {
            if (lp-value > maxLp)
            {
                lp = maxLp;
            }

            else if (lp <= 0)
            {//死亡
            Destroy(this);
            }
            else
            {
                lp -= value;
            }
        }
        get
        {
            return lp;
        }
    }

    private int maxBp;

    public int MaxBpSet
    {
        set
        {
            if (maxBp+value < 0)
            {
                maxBp = 1;
            }
            else if (maxBp+value > 255)
            {
                maxBp = 255;
            }
            else { maxBp += value; };
        }
        get { return maxBp; }
    }
    private int bp;
    public int BpSet
    {
        set
        { if(sobiSubBogu.Name=="魔王の盾")
        {
            value*=2;
        }
            if (bp-value > maxBp)
            {
                bp = maxBp;
            }

            else if (bp-value < 0)
            {
                bp = 0;
            }
            else
            {
                bp -= value;
            }

        }
        get
        {
            return bp;
        }
    }

    private int str;
    public int StrSet
    {
        set
        {
            if (str+value < 1)
            {
                str = 1;
            }
            else if (str+value > 255)
            {
                str = 255;
            }
            else
            {
                str += value;
            }
        }
        get
        {
            return str;
        }
    }

    private int vit;
    public int VitSet
    {
        set
        {
            if (vit+value < 1)
            {
                vit = 1;
            }
            else if (str+value > 255)
            {
                vit = 255;
            }
            else
            {
                vit += value;
            }
        }
        get
        {
            return vit;
        }
    }

    private int mgc;
    public int MgcSet
    {
        set
        {
            if (mgc+value < 1)
            {
                mgc = 1;
            }
            else if (mgc+value > 255)
            {
                mgc = 255;
            }
            else
            {
                mgc += value;
            }
        }
        get
        {
            return mgc;
        }
    }

    private int psy;
    public int PsySet
    {

        set
        {
            if (psy+value < 1)
            {
                psy = 1;
            }
            else if (psy+value > 255)
            {
                psy = 255;
            }
            else
            {
                psy += value;
            }

        }
        get
        {
            return psy;
        }
    }

    private int spd;
    public int SpdSet
    {
        set
        {
            if (spd+value < 1)
            {
                spd = 1;
            }
            else if (spd+value > 99)
            {
                spd = 99;
            }
            else
            {
                spd += value;
            }
        }
        get { return spd; }
    }
    public void ParameterHenka()
    {   //正常値よりも小さい
       if(maxHp<StandardMaxHp)
       {
          int p=(int)(maxHp*Random.Range(1.01f,0.02f));
          //正常値より大きくなったなら
          if(p>StandardMaxHp)
          {
              maxHp=StandardMaxHp;
          }
          else{
              maxHp=p;
          }
       }
       //正常値よりも大きい
       if(maxHp>StandardMaxHp)
       {
           int p=(int)(maxHp/Random.Range(1.01f,0.02f));
           //正常値よりも小さくなったなら
          if(p<StandardMaxHp)
          {
              maxHp=StandardMaxHp;
          }
          else{
              maxHp=p;
          }
       }
       if(maxBp<StandardMaxBP)
       {
          int p=(int)(maxBp*Random.Range(1.01f,0.02f));
          //正常値より大きくなったなら
          if(p>StandardMaxBP)
          {
              maxBp=StandardMaxBP;
          }
          else{
              maxBp=p;
          }
       }
       if(maxBp>StandardMaxBP)
       {
            int p=(int)(maxBp/Random.Range(1.01f,0.02f));
           //正常値よりも小さくなったなら
          if(p<StandardMaxBP)
          {
              maxBp=StandardMaxBP;
          }
          else{
              maxBp=p;
          }
       }
       if(maxLp<StandardMaxLp)
       {
           int p=(int)(maxLp*Random.Range(1.01f,0.02f));
          //正常値より大きくなったなら
          if(p>StandardMaxLp)
          {
              maxLp=StandardMaxLp;
          }
          else{
              maxLp=p;
          }
       }
       if(maxLp>StandardMaxLp)
       {
           int p=(int)(maxLp/Random.Range(1.01f,0.02f));
          //正常値より小さくなったなら
          if(p<StandardMaxLp)
          {
              maxLp=StandardMaxLp;
          }
          else{
              maxLp=p;
          }
       }
       if(str<StandardStr)
       {
           int p=(int)(str*Random.Range(1.01f,0.02f));
           if(p>StandardStr)
           {
               str=StandardStr;
           }
           else{
               str=p;
           }
       }
       if(str>StandardStr)
       {
           int p=(int)(str/Random.Range(1.01f,0.02f));
           if(p<StandardStr)
           {
               str=StandardStr;
           }
           else{
               str=p;
           }
       }
       if(vit<StandardVit)
       {
            int p=(int)(vit*Random.Range(1.01f,0.02f));
            if(p>StandardVit)
            {
                vit=StandardVit;
            }
            else
            {
                vit=p;
            }
       }
       if(vit>StandardVit)
       {
           int p=(int)(vit/Random.Range(1.01f,0.02f));
            if(p<StandardVit)
            {
                vit=StandardVit;
            }
            else
            {
                vit=p;
            }
       }
      
       if(mgc<StandardMgc)
       {
           int p=(int)(mgc*Random.Range(1.01f,0.02f));
            if(p>StandardMgc)
            {
                mgc=StandardMgc;
            }
            else
            {
                mgc=p;
            }
       }
       if(mgc<StandardMgc)
       {
           int p=(int)(mgc/Random.Range(1.01f,0.02f));
            if(p>StandardMgc)
            {
                mgc=StandardMgc;
            }
            else
            {
                mgc=p;
            }
       }
        if(psy<StandardPSy)
       {
           int p=(int)(mgc*Random.Range(1.01f,0.02f));
            if(p>StandardPSy)
            {
                psy=StandardPSy;
            }
            else
            {
                psy=p;
            }
       }
       if(psy>StandardPSy)
       {
           int p=(int)(mgc/Random.Range(1.01f,0.02f));
            if(p<StandardPSy)
            {
                psy=StandardPSy;
            }
            else
            {
                psy=p;
            }
       }
        if(spd<StandardSpd)
       {
           int p=(int)(spd*Random.Range(1.01f,0.02f));
            if(p>StandardSpd)
            {
                spd=StandardSpd;
            }
            else
            {
                spd=p;
            }
       }
       if(spd>StandardSpd)
       {
           int p=(int)(spd/Random.Range(1.01f,0.02f));
            if(p<StandardSpd)
            {
                spd=StandardSpd;
            }
            else
            {
                spd=p;
            }
       }
    }

    public int MaxBP2
    {
        set{
            float r= Random.Range(1.05f,0.1f);
             maxBp*=(int)r;
        }
    }
    public int MaxHp2{
        set{
            float r= Random.Range(1.05f,0.1f);
             maxHp*=(int)r;
        }
    }
    public int MaxLp2{
        set{
            float r= Random.Range(1.05f,0.1f);
             maxLp*=(int)r;
        }
    }
    public int Str2{
        set{
            float r= Random.Range(1.05f,0.1f);
             str*=(int)r;
        }
    }
   
    public int Vit2
    {
        set{
            float r= Random.Range(1.05f,0.1f);
            vit*=(int)r;
        }
    }
    public int Mgc2
    {
        set{
            float r= Random.Range(1.05f,0.1f);
             mgc*=(int)r;
        }
    }
    public int Psy2{
        set{
            float r= Random.Range(1.05f,0.1f);
            psy*=(int)r;
        }
    }
    public int Spd2{
        set{
            float r= Random.Range(1.05f,0.1f);
             spd*=(int)r;
        }
    }
     public int StandardMaxHp{get;set;}
    public int StandardMaxBP{get;set;}
    public int StandardMaxLp{get;set;}
    public int StandardStr{get;set;}
    public int StandardVit{get;set;}
    public int StandardMgc{get;set;}
    public int StandardPSy{get;set;}
    public int StandardSpd{get;set;}
    public bool PoisonFlag { get; set; }
    public void PoisonEffect()
    {
        if (PoisonFlag == true)
        {
            HpSet = MaxHpSet / 8;
        }
    }
    bool stunFlag;
    public bool StunFlag 
    { 
        set{
             stunFlag=value;
              ActionEnd=true;
        }
        get{return stunFlag;}
    }
    public bool BlindFlag { get; set; }

    public bool SleepFlag { get; set; }
    public bool WeaknessFlag { get; set; }
    public bool ConfuseFlag { get; set; }
    public bool NegativeFlag { get; set; }
    public bool AngerFlag { get; set; }
    public bool FearFlag { get; set; }
    public bool CharmFlag { get; set; }
    public bool PurgeFlag { get; set; }
    public bool StoneFlag { get; set; }
    public bool DeathFlag 
    {get;set; }
    private int fire;
    public int Fire
    {
        set
        {
            if (fire-value < -100)
            {
                fire = -100;
            }
            else if (fire-value > 500)
            {
                fire = 500;
            }
            else
            {
                fire = value;
            }
        }

        get
        {
            return fire;
        }
    }
    private int water;
    public int Water
    { set
        {
            if (water-value <-100)
            {
                water = -100;
            }
            else if (water-value > 500)
            {
                water = 500;

            }
            else
            {
                water = value;
            }
        }
        get
        {
            return water;

        }
    }
    private int wind;
    public int Wind
    {
        set
        {
            if (wind -value<-100)
            {
                wind = 0;
            }
            else if (wind-100 > 500)
            {
                wind = 500;

            }
            else
            {
                wind += value;
            }
        }
        get
        {
            return wind;

        }
    }
    private int earth;
    public int Earth {
        set {
            if (earth-value <-100)
            {
                earth =-100;
            }
            else if (earth-value > 500)
            {
                earth = 500;

            }
            else
            {
                earth += value;
            }
        }
        get
        {
            return earth;

        }
    }
    private int light1;
    public int Light
    {
        set
        {
            if (light1-value <- 100)
            {
                light1 = -100;
            }
            else if (light1-value >500)
            {
                light1 = 500;

            }
            else
            {
                light1 += value;
            }
        }
        get { return light1; }
    }
    private int stun;
    public  int Stun 
    { set
    {
        if(stun-value<0)
        {
            stun=0;
        }
        else{
            stun-=value;
        }
    }
    get {
        return stun;
    }
    }
   
    private int dark;
    public int Dark
    {
        set
        {
            if (dark < -100)
            {
                dark = -100;
            }
            else if (dark > 500)
            {
                dark = 500;

            }
            else
            {
                dark += value;
            }
        }
        get { return dark; }
    }
  
   private int poison;
    public int Poison 
    {
        set
    {
        if(poison-value<0)
        {
            poison=0;
        }
        else poison-=value;
    }
        get{
            return poison;
     }
    }
    private int blind;
     public int Blind 
    {
        set
    {
        if(blind-value<0)
        {
            blind=0;
        }
        else blind-=value;
    }
        get{
            return blind;
        }
     }
    private int sleep;
     public int Sleep
    {
        set
    {
        if(sleep-value<0)
        {
            sleep=0;
        }
        else sleep-=value;
    }
        get{
            return sleep;
        }
     }
    private int weakness;
    public int Weakness
    {
    set{
        if(weakness-value<0)
        {
            weakness=0;
        }
        else
        {
            {
                weakness-=value;
            }
        }
       
    }
    get{
        return weakness;
    }
    }
    private int confuse;
    public int Confuse 
    { set{
        if(confuse-value<0)
        {
            confuse=0;
        }
        else{
            confuse-=value;
        }
      
        } 
    get{return confuse;}
    }
    private int negative;
    public int Negative 
    { set{
        if(negative-value<0)
        {
            negative=0;
        }
        else{
            negative-=value;
        }
      
        } 
    get{return negative;}
    }
    private int anger;
    public int Anger 
     { set{
        if(anger-value<0)
        {
            anger=0;
        }
        else{
            anger-=value;
        }
      
        } 
    get{return anger;}
    }
    private int paralysis;
    public int Paralysis { set{
        if(paralysis-value<0)
        {
            paralysis=0;
        }
        else{
            paralysis-=value;
        }
      
        } 
    get{return paralysis;}
    }
    public bool ParalysisFlag { get; set; }
    
    private int fear;
    public int Fear 
     { set{
        if(fear-value<0)
        {
            fear=0;
        }
        else{
            fear-=value;
        }
      
        } 
    get{return fear;}
    }
    private int charm;
    public int Charm 
     { set{
        if(charm-value<0)
        {
            charm=0;
        }
        else{
            charm-=value;
        }
      
        } 
    get{return charm;}
    }
    private int purge;
    public int Purge  { set{
        if(purge-value<0)
        {
            purge=0;
        }
        else{
            purge-=value;
        }
      
        } 
    get{return purge;}
    }
   private int stone;
    public int Stone 
     { set{
        if(stone-value<0)
        {
            stone=0;
        }
        else{
            stone-=value;
        }
      
        } 
    get{return stone;}
    }
    public int death;
    public int Death 
     { set{
        if(death-value<0)
        {
            death=0;
        }
        else{
            death-=value;
        }
      
        } 
    get{return death;}
    }
    
    //速度補正なし
    public virtual int SokudochiA(int n)
    {
        return (n + 2) * (n + 2) / 32 * Random.Range(24, 32);

    }
    //速度補正+
    public virtual int SokudochiB(int n)
    {
        return (n + 3) * (n + 3) / 32 * Random.Range(30, 40);
    }
    //速度補正++
    public virtual int SokudochiC(int n)
    {
        return (n + 4) * (n + 4) / 32 * Random.Range(36, 48);
    }
    //速度補正-
    public virtual int SokudochiD(int n)
    {
        return (n + 2) + (n + 2) / 32 * Random.Range(16, 20);
    }

    //速度補正--
    public virtual int SokudochiE(int n)
    {
        return (n + 1) * (n + 1) / 32 * Random.Range(4, 12);
    }

    public virtual int AttackG(int a)
    {
        return (a + 2) * (a + 2) / 16 + 20;
    }

    public virtual int AttackF(int a)
    {
        return (a + 3) * (a + 3) / 12 + 20;
    }

    public virtual int AttackE(int a)
    {
        return (a + 4) * (a + 4) / 8 + 20;
    }
    public virtual int AttackD(int a)
    {
        return (a + 5) * (a + 5) / 6 + 20;
    }
    public virtual int AttackC(int a)
    {
        return (a + 6) * (a + 6) / 4 + 20;
    }
    public virtual int AttackB(int a)
    {
        return (a + 8) * (a + 8) / 2 + 20;
    }
    public virtual int AttackA(int a)
    {
        return (a + 10) * (a + 10) + 20;
    }
    public virtual int AttackS(int a)
    {
        return (a + 12) * (a + 12) * 2 + 20;
    }
    public virtual double NormalDefence(int a)
    {
        return a * a * a + 780 * a * a - 3 * 260 * 260 * a + 1;
    }

    public virtual bool MeichuKeisan(int a, int b, int c)
    {
        //a:味方の技の基本命中率
        //b:味方の素早さ
        //c:敵の素早さ
        int d = (a + b - c);
        if(a==-1)
        {
            return true;
        }
        if (BlindFlag == true)
        {
            d /= 2;
        }
        if (d >= 100)
        {
            //命中
            return true;
        }
        else if (d <= 0)
        {
            //失敗
            return false;
        }
        else
        {
            int e = Random.Range(0, 99);
            if (e <= d)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    void start()
    {
        battleManager = GameObject.FindWithTag("BattleManager");
        battleManager1=battleManager.GetComponent<BattleManager1>();
        
        canvas = GameObject.FindWithTag("Canvas");
        foreach(Skill skill in useSkills)
        {
            
            skill.skillUser=this.gameObject;
        }
    }
    public void MemberDataGet()
    {
        int x=MemberCount.PlayerCount();
        int y=MemberCount.EnemyCount();
        int z=MemberCount.AllMemberCount();
        for(int i=0;i<x;i++)
        {
            playerData[i]=battleManager1.battleCharaDatas[i];
        }
        for(int i=0;i<y;i++){
            enemyData[i]=battleManager1.battleEnemyDatas[i];
        }
        for(int i=0;i<z;i++){
            memberData[i]=battleManager1.battleEnemyDatas[i];
        }
    }
    public virtual void DataCopy()
    {
        {
        MaxHpSet = charadata1.Majutsushi[level].hp;
        
        if(sobiWeapon!=null)
        {
            MaxHpSet=sobiWeapon.maxHpPlus;
           
        }

        if(sobiMainBogu!=null) 
        {
            MaxHpSet=sobiMainBogu.maxHpPlus;
        }
        if(sobiSubBogu!=null)
        {
            MaxHpSet=sobiSubBogu.maxHpPlus;
        }
        if(accessory!=null)
        {
            MaxHpSet=accessory.maxHpPlus;
        }
        StandardMaxHp=MaxHpSet;
        HpSet =MaxHpSet;

        MaxBpSet = charadata1.Majutsushi[level].bp;
        if(sobiWeapon!=null)
        {
            MaxBpSet=sobiWeapon.maxBpPlus;
        }

        if(sobiMainBogu!=null) 
        {
            MaxBpSet=sobiMainBogu.maxBpPlus;
        }
        if(sobiSubBogu!=null)
        {
            MaxBpSet=sobiSubBogu.maxBpPlus;
        }
        if(accessory!=null)
        {
            MaxBpSet=accessory.maxBpPlus;
        }
        StandardMaxBP=MaxBpSet;
        BpSet =MaxBpSet;
        MaxLpSet = charadata1.Majutsushi[level].lp;
        if(sobiWeapon!=null)
        {
            MaxLpSet=sobiWeapon.maxLpPlus;
        }

        if(sobiMainBogu!=null) 
        {
            MaxLpSet=sobiMainBogu.maxLpPlus;
        }
        if(sobiSubBogu!=null)
        {
            MaxLpSet=sobiSubBogu.maxLpPlus;
        }
        if(accessory!=null)
        {
            MaxLpSet=accessory.maxLpPlus;
        }
        StandardMaxLp=MaxLpSet;
        LpSet = MaxLpSet;
        StrSet = charadata1.Majutsushi[level].str;
       
        if(sobiMainBogu!=null) 
        {
            StrSet=sobiMainBogu.StrPlus;
        }
        if(sobiSubBogu!=null)
        {
            StrSet=sobiSubBogu.StrPlus;
        }
        if(accessory!=null)
        {
            StrSet=accessory.StrPlus;
        }
        StandardStr=StrSet;
        VitSet = charadata1.Majutsushi[level].vit;
        if(sobiWeapon!=null)
        {
            VitSet=sobiWeapon.StrPlus;
        }
        if(accessory!=null)
        {
            VitSet=accessory.VitPlus;
        }
        StandardVit=VitSet;
        MgcSet = charadata1.Majutsushi[level].mgc;
        if(sobiMainBogu!=null) 
        {
            MgcSet=sobiMainBogu.MgcPlus;
        }
        if(sobiSubBogu!=null)
        {
            MgcSet=sobiSubBogu.MgcPlus;
        }
        if(accessory!=null)
        {
            MgcSet=accessory.MgcPlus;
        }
        StandardMgc=MgcSet;
        PsySet = charadata1.Majutsushi[level].psy;
        if(sobiWeapon!=null) 
        {
            PsySet=sobiWeapon.PsyPlus;
        }
       
        if(accessory!=null)
        {
            PsySet=accessory.PsyPlus;
        }
        StandardPSy=PsySet;
        SpdSet = charadata1.Majutsushi[level].spd;
         if(sobiWeapon!=null)
        {
            SpdSet=sobiWeapon.SpdPlus;
        }

        if(sobiMainBogu!=null) 
        {
            SpdSet=sobiMainBogu.SpdPlus;
        }
        if(sobiSubBogu!=null)
        {
            SpdSet=sobiSubBogu.SpdPlus;
        }
        if(accessory!=null)
        {
            SpdSet=accessory.SpdPlus;
        }
        StandardSpd=SpdSet;
        Fire = charadata1.Majutsushi[level].fire;
         if(sobiWeapon!=null)
        {
            Fire=sobiWeapon.Fire;
        }

        if(sobiMainBogu!=null) 
        {
            Fire=sobiMainBogu.Fire;
        }
        if(sobiSubBogu!=null)
        {
            Fire=sobiSubBogu.Fire;
        }
        if(accessory!=null)
        {
            Fire=accessory.Fire;
        }
        Water = charadata1.Majutsushi[level].water;
        {
             if(sobiWeapon!=null)
        {
            Water=sobiWeapon.Water;
        }

        if(sobiMainBogu!=null) 
        {
            Water=sobiMainBogu.Water;
        }
        if(sobiSubBogu!=null)
        {
            Water=sobiSubBogu.Water;
        }
        if(accessory!=null)
        {
            Water=accessory.Water;
        }
        }
        Wind=charadata1.Majutsushi[level].wind;
         {
             if(sobiWeapon!=null)
        {
            Wind=sobiWeapon.Wind;
        }

        if(sobiMainBogu!=null) 
        {
            Wind=sobiMainBogu.Wind;
        }
        if(sobiSubBogu!=null)
        {
            Wind=sobiSubBogu.Wind;
        }
        if(accessory!=null)
        {
            Wind=accessory.Wind;
        }
        }
        Earth = charadata1.Majutsushi[level].earth;
         {
             if(sobiWeapon!=null)
        {
            Earth=sobiWeapon.Earth;
        }

        if(sobiMainBogu!=null) 
        {
            Earth=sobiMainBogu.Earth;
        }
        if(sobiSubBogu!=null)
        {
            Earth=sobiSubBogu.Earth;
        }
        if(accessory!=null)
        {
            Earth=accessory.Earth;
        }
        }
        Light = charadata1.Majutsushi[level].light1;
        {
             if(sobiWeapon!=null)
        {
            Light=sobiWeapon.Light;
        }

        if(sobiMainBogu!=null) 
        {
            Light=sobiMainBogu.Light;
        }
        if(sobiSubBogu!=null)
        {
            Light=sobiSubBogu.Light;
        }
        if(accessory!=null)
        {
            Light=accessory.Light;
        }
        }
        Dark = charadata1.Majutsushi[level].dark;
        {
             if(sobiWeapon!=null)
        {
            Dark=sobiWeapon.Dark;
        }

        if(sobiMainBogu!=null) 
        {
            Dark=sobiMainBogu.Dark;
        }
        if(sobiSubBogu!=null)
        {
            Dark=sobiSubBogu.Dark;
        }
        if(accessory!=null)
        {
            Dark=accessory.Dark;
        }
        }
        Stun=charadata1.Majutsushi[level].stun;
        {
             if(sobiWeapon!=null)
        {
            Stun=sobiWeapon.Stun;
        }

        if(sobiMainBogu!=null) 
        {
            Stun=sobiMainBogu.Stun;
        }
        if(sobiSubBogu!=null)
        {
            Stun=sobiSubBogu.Stun;
        }
        if(accessory!=null)
        {
            Stun=accessory.Stun;
        }
        }
        Poison= charadata1.Majutsushi[level].poison;
        {
             if(sobiWeapon!=null)
        {
            Poison=sobiWeapon.Poison;
        }

        if(sobiMainBogu!=null) 
        {
            Poison=sobiMainBogu.Poison;
        }
        if(sobiSubBogu!=null)
        {
            Poison=sobiSubBogu.Poison;
        }
        if(accessory!=null)
        {
            Poison=accessory.Poison;
        }
        }
        Blind = charadata1.Majutsushi[level].blind;
        {
             if(sobiWeapon!=null)
        {
            Blind=sobiWeapon.Blind;
        }

        if(sobiMainBogu!=null) 
        {
            Blind=sobiMainBogu.Blind;
        }
        if(sobiSubBogu!=null)
        {
            Blind=sobiSubBogu.Blind;
        }
        if(accessory!=null)
        {
            Blind=accessory.Blind;
        }
        }
        Sleep = charadata1.Majutsushi[level].sleep;
        {
             if(sobiWeapon!=null)
        {
            Sleep=sobiWeapon.Sleep;
        }

        if(sobiMainBogu!=null) 
        {
            Sleep=sobiMainBogu.Sleep;
        }
        if(sobiSubBogu!=null)
        {
            Sleep=sobiSubBogu.Sleep;
        }
        if(accessory!=null)
        {
            Sleep=accessory.Sleep;
        }
        }
        Weakness = charadata1.Majutsushi[level].weakness;
        {
             if(sobiWeapon!=null)
        {
            Weakness=sobiWeapon.Weakness;
        }

        if(sobiMainBogu!=null) 
        {
            Weakness=sobiMainBogu.Weakness;
        }
        if(sobiSubBogu!=null)
        {
            Weakness=sobiSubBogu.Weakness;
        }
        if(accessory!=null)
        {
            Weakness=accessory.Weakness;
        }
        }
        Negative = charadata1.Majutsushi[level].negative;
        {
             if(sobiWeapon!=null)
        {
            Negative=sobiWeapon.Negative;
        }

        if(sobiMainBogu!=null) 
        {
            Negative=sobiMainBogu.Negative;
        }
        if(sobiSubBogu!=null)
        {
            Negative=sobiSubBogu.Negative;
        }
        if(accessory!=null)
        {
            Negative=accessory.Negative;
        }
        }
        Anger = charadata1.Majutsushi[level].anger;
        {
             if(sobiWeapon!=null)
        {
            Anger=sobiWeapon.Anger;
        }

        if(sobiMainBogu!=null) 
        {
            Anger=sobiMainBogu.Anger;
        }
        if(sobiSubBogu!=null)
        {
            Anger=sobiSubBogu.Anger;
        }
        if(accessory!=null)
        {
            Anger=accessory.Anger;
        }
        }
        Confuse= charadata1.Majutsushi[level].confuse;
        {
             if(sobiWeapon!=null)
        {
            Confuse=sobiWeapon.Confuse ;
        }

        if(sobiMainBogu!=null) 
        {
            Confuse=sobiMainBogu.Confuse;
        }
        if(sobiSubBogu!=null)
        {
            Confuse=sobiSubBogu.Confuse;
        }
        if(accessory!=null)
        {
            Confuse=accessory.Confuse;
        }
        }
        Paralysis=charadata1.Majutsushi[level].paralysis;
        {
             if(sobiWeapon!=null)
        {
            Paralysis=sobiWeapon.Paralysis;
        }

        if(sobiMainBogu!=null) 
        {
            Paralysis=sobiMainBogu.Paralysis;
        }
        if(sobiSubBogu!=null)
        {
            Paralysis=sobiSubBogu.Paralysis;
        }
        if(accessory!=null)
        {
            Paralysis=accessory.Paralysis;
        }
        }
        Fear= charadata1.Majutsushi[level].fear;
        {
             if(sobiWeapon!=null)
        {
            Fear=sobiWeapon.Fear;
        }

        if(sobiMainBogu!=null) 
        {
            Fear=sobiMainBogu.Fear;
        }
        if(sobiSubBogu!=null)
        {
            Fear=sobiSubBogu.Fear;
        }
        if(accessory!=null)
        {
            Fear=accessory.Fear;
        }
        }
        Charm= charadata1.Majutsushi[level].charm;
        {
             if(sobiWeapon!=null)
        {
            Charm=sobiWeapon.Charm;
        }

        if(sobiMainBogu!=null) 
        {
            Charm=sobiMainBogu.Charm;
        }
        if(sobiSubBogu!=null)
        {
            Charm=sobiSubBogu.Charm;
        }
        if(accessory!=null)
        {
            Charm=accessory.Charm;
        }
        }
        Purge= charadata1.Majutsushi[level].purge;
        {
             if(sobiWeapon!=null)
        {
            Purge=sobiWeapon.Purge;
        }

        if(sobiMainBogu!=null) 
        {
            Purge=sobiMainBogu.Purge;
        }
        if(sobiSubBogu!=null)
        {
            Purge=sobiSubBogu.Purge;
        }
        if(accessory!=null)
        {
            Purge=accessory.Purge;
        }
        }
        Stone= charadata1.Majutsushi[level].stone;
        {
             if(sobiWeapon!=null)
        {
            Stone=sobiWeapon.Stone;
        }

        if(sobiMainBogu!=null) 
        {
            Stone=sobiMainBogu.Stone;
        }
        if(sobiSubBogu!=null)
        {
            Stone=sobiSubBogu.Stone;
        }
        if(accessory!=null)
        {
            Stone=accessory.Stone;
        }
        }
        Death= charadata1.Majutsushi[level].death;
        {
             if(sobiWeapon!=null)
        {
            Death=sobiWeapon.Death;
        }

        if(sobiMainBogu!=null) 
        {
            Death=sobiMainBogu.Death;
        }
        if(sobiSubBogu!=null)
        {
            Death=sobiSubBogu.Death;
        }
        if(accessory!=null)
        {
            Death=accessory.Death;
        }
        }
    }
    }
    public abstract void ActionChoose();
   public Skill this[int i]
   {
      set{
          useSkills[i]=value;
      }
      get{
          return useSkills[i];
      }
   }
   
   
    public Skill reservedSkill { get; set; }
    public void TargetChoose(int a)
    {

    }   
    public virtual bool AttackCharaHosei(int damage ,ref IBasicAction userData2,ref StatusHosei statusHosei2)
    {
    foreach(IBasicAction ibasicAction in userData2.reservedSkill.targetDataList)
         {
             bool seiko= ibasicAction.reservedSkill.KakushuDefenceHosei(damage,ref userData2,ref statusHosei2);
              if(seiko==false)
              {  
                   return false;  
                   
              }
         }
        
        return true;
    }
    public virtual bool DeffenceCharaHosei(int damage ,ref IBasicAction userData2 ,ref StatusHosei statusHosei2)
    {
        if(damage<0)
             {
                 HpSet=damage;
                 return true;
             }
        else 
            {
                Fire=userData2.Fire;
                 damage*=Fire/100;
                 Water=userData2.Water;
                damage*=Water/100;
                Wind=userData2.Wind;
                  damage*=Wind/100;
               Earth=userData2.Earth;
                 damage*=Earth/100;
                 Light=userData2.Light;
                 damage*=Light/100;
                Dark=userData2.Dark;
                damage*=Dark/100;
             
        
             int b=userData2.SpdSet;
              int c=SpdSet;
              int a=statusHosei2.meichu;
             if(MeichuKeisan(a,b,c)==true && damage>0)
            {
                   for(int i=0; i<playerData.Length;i++)
                        {
                           if(playerData[i].reservedSkill is Deflect deflect && statusHosei2.range==0 && statusHosei2.taisho==0 && statusHosei2.tokushu==0)
                             {
                                 bool kaihi= deflect.Defflect2(damage);
                                  if(kaihi==true)
                                     {
                                       return false;
                                    }
                             
                            }

                        }
                             switch(userData2.reservedSkill.TypeSet)
                               {   case 0:
                                    damage=(int)(damage*NormalDefence(VitSet));
                                     HpSet=damage;
                                   break;
            
                                  case 1:
                                 damage=(int)(damage*NormalDefence(PsySet));
                                HpSet=damage;
                                  break;
                             } 
            
             }
        else
        {
            return false;
        }
    
        if(userData2.Death>=100)
        {
            DeathFlag=true;
            return true;
        }
        else if(userData2.Death>0){
            int r=Random.Range(0,99);
            if(userData2.Death>r)
            {
                DeathFlag=true;
                return true;
             
            }
        }
        if(userData2.Stone>=100)
        {
            StoneFlag=true;
            return true;
        }
        else if(userData2.Stone>0)
        {
            int r=Random.Range(0,99);
            if(userData2.Stone>r)
            {
                StoneFlag=true;
                return true;
            }
            
        }
            if(userData2.Purge>=100)
        {
            PurgeFlag=true;
            return true;
           
        }
        else if(userData2.Purge>0)
        {
            int r=Random.Range(0,99);
            if(userData2.Purge>r)
            {
                PurgeFlag=true;
                return true;
            }
            
        }
        if(userData2.Stun>=100)
        {
            StunFlag=true;
            
        }
        else if(userData2.Stun>0)
        {
            int r=Random.Range(0,99);
            if(userData2.Stun>r)
            {
                StunFlag=true;
               
            }
            
        }
         if(userData2.Paralysis>=100)
        {
            ParalysisFlag=true;
            
        }
        else if(userData2.Paralysis>0)
        {
            int r=Random.Range(0,99);
            if(userData2.Paralysis>r)
            {
                ParalysisFlag=true;
               
            }
            
        }
        if(userData2.Sleep>=100)
        {
            SleepFlag=true;
        }
        else if(userData2.Sleep>0)
        {   int r=Random.Range(0,99);
            if(userData2.Sleep>r)
            {
                SleepFlag=true;
            }
        }
         if(userData2.Confuse>=100)
        {
            ConfuseFlag=true;
            
        }
        else if(userData2.Confuse>0)
        {
            int r=Random.Range(0,99);
            if(userData2.Confuse>r)
            {
                ConfuseFlag=true;
               
            }
            
        }
         if(userData2.Anger>=100)
        {
            AngerFlag=true;
            
        }
        else if(userData2.Anger>0)
        {
            int r=Random.Range(0,99);
            if(userData2.Anger>r)
            {
                AngerFlag=true;
               
            }
            
        }
         if(userData2.Negative>=100)
        {
            StunFlag=true;
            
        }
        else if(userData2.Negative>0)
        {
            int r=Random.Range(0,99);
            if(userData2.Negative>r)
            {
                NegativeFlag=true;
               
            }
            
        }
         if(userData2.Fear>=100)
        {
            StunFlag=true;
            
        }
        else if(userData2.Fear>0)
        {
            int r=Random.Range(0,99);
            if(userData2.Fear>r)
            {
                FearFlag=true;
               
            }
            
        }
         if(userData2.Charm>=100 && ConfuseFlag==false)
        {
            CharmFlag=true;
            
        }
        else if(userData2.Charm>0 && ConfuseFlag==false)
        {
            int r=Random.Range(0,99);
            if(userData2.Charm>r)
            {
                CharmFlag=true;
               
            }
            
        }
       return true;
            }
    }
    public virtual int SokudochiCharaHosei(int speed ,ref IBasicAction userData2, ref StatusHosei statusHosei2)
    {
        return AttackA(speed);
    }
   
}


