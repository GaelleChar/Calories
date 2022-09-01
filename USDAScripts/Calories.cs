using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Calories : MonoBehaviour {
    public string number {get; set; }
    public string name {get; set; }
    //
    public string energy {get; set; }
    public string protein{get; set; }
    public string lipid{get; set; }
    public string carb{get; set; }

    
    public string ReturnEntryName(int i, string[] entryName){
        return entryName[i];
        
    }
    public int EntryCalories(string[] entryName){
        int i = 1;
        int cals = Int32.Parse(entryName[i]) + Int32.Parse(entryName[i + 1]) + Int32.Parse(entryName[i + 2]) + Int32.Parse(entryName[i + 3]);
        return cals;

    }
    public Calories(){
    }

}