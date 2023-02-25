using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class LearningCurve : MonoBehaviour
{
    //private Character hero = new Character();

    //private Character heroine = new Character("Agatha");
    Weapon huntingBow = new Weapon("HuntingBow", 105);
    private Transform _camTransform;
    public GameObject directionLight;
    private Transform _lightTransform;
    
    

    //Weapon huntingBow = new Weapon("HuntingBow", 105);
    //Weapon warBow = huntingBow;

    
    //public Character hero = new Character();
    
     //("Hero: {0} - {1} XP", hero.name, hero.exp);

    //LogFormat("Hero: {0} - {1} XP", hero.name, hero.exp);






    // Start is called before the first frame update
    void Start()
    {
        //directionLight = GameObject.Find("Directional Light");
        _lightTransform = directionLight.GetComponent<Transform>();
        
        _camTransform = this.GetComponent<Transform>();
        Debug.Log(_lightTransform.localPosition);

        // Palladin knight = new Palladin("Sir Arthur", huntingBow);
        //
        // knight.PrintStatsInfo();
        // Weapon huntingBow = new Weapon("HuntingBow", 105);
        // Weapon warBow = huntingBow;
        //
        // warBow.name = "Archer";
        // warBow.damage = 35;
        //
        // huntingBow.PrintWeaponStats();
        // warBow.PrintWeaponStats();
        // hero.PrintStatsInfo();
        // heroine.PrintStatsInfo();
        // hero.Reset();
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}