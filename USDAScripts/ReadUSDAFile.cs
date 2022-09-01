using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ReadUSDAFile : Calories
{
    public int i;
    public string[] entries;
    string[] lines = System.IO.File.ReadAllLines(@"Assets/sr28abbr/RichTextSample.txt");
    /*
    public TextAsset textFile;
    List<string> lines = File.ReadAllLines(textFile.text).ToList();
    */

    void Start(){
        Main();
        ReturnEntryName(i, entries);
        EntryCalories(entries);
    }

    public string ReturnEntryName(int i, string [] entries){
        i=1;
        foreach(string line in lines){
            entries = line.Split('^');
            Calories calories = new Calories();
            calories.number = entries[0];
            calories.name = entries[1];
        }
        return entries[i];
    }

    public int EntryCalories(string[] entries){
        int i = 2;
        int cals = 0;
        foreach(string line in lines){
            entries = line.Split('^');
            Calories calories = new Calories();
            calories.number = entries[0];
            calories.name = entries[1];
            //
            calories.energy = entries[2];
            calories.protein = entries[3];
            calories.lipid = entries[4];
            calories.carb = entries[5];
            //cals = Int32.Parse(entries[i]);
        }
        return cals;
    }

    static void Main()
    {

        string text = System.IO.File.ReadAllText(@"Assets/sr28abbr/RichTextSample.txt");
        string[] lines = System.IO.File.ReadAllLines(@"Assets/sr28abbr/RichTextSample.txt");

        foreach (string line in lines)
        {
            string[] entries = line.Split('^');
            Calories calories = new Calories();
            //TODO: have to split with '~'
            calories.number = entries[0];
            calories.name = entries[1];
            //getting wrong info needs to skip until it reads "lipid", "energy" etc
            calories.energy = entries[2];
            calories.protein = entries[3];
            calories.lipid = entries[4];
            calories.carb = entries[5];
            //cal.Add(calories);


            //Debug.Log(" number : " + entries[0] + " name : " + entries[1] + " | energy : " + entries[2]
            //+ " | protein : " + entries[3] + " | lipid : " + entries[4] + " | carb : " + entries[5]);
        }

        //Debug.Log("Read last line");
        System.Console.ReadKey();
    }
    
    

}
