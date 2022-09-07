using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ReadUSDAFile : Calories
{
    public int i;
    public string[] entries;
    public string[] firstFourString;

    string[] lines = System.IO.File.ReadAllLines(@"Assets/sr28abbr/ABBREV.txt");
    /*
    public TextAsset textFile;
    List<string> lines = File.ReadAllLines(textFile.text).ToList();
    */

    void Start(){
        Main();
        //ReturnEntryName(i, entries);
        //EntryCalories(entries);
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

    public double EntryCalories(string[] entries){
        double cals = 0.0;
        
        
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

        }

        return cals;
    }
    static void Main()
    {

        string filePath = @"Assets/sr28abbr/Sample.txt";
        string text = System.IO.File.ReadAllText(@"Assets/sr28abbr/ABBREV.txt");
        string[] lines = System.IO.File.ReadAllLines(@"Assets/sr28abbr/ABBREV.txt");
        string[] nameList;
        string lower = "";
        List<Item> listName = new List<Item>();
        List<string> nameListActual = new List<string>();

        foreach (string line in lines)
        {
            string[] entries = line.Split('^');
            
            Calories calories = new Calories();
            calories.number = entries[0];
            calories.name = entries[1];
            
            calories.energy = entries[3];
            calories.protein = entries[4];
            calories.lipid = entries[5];
            calories.carb = entries[7];

            string[] testingNameArray = calories.name.Split('~');
            
            foreach(string test in testingNameArray){
                
                lower = test.ToLower();

                int index = lower.IndexOf(",");
                if (index >= 0){
                    lower = lower.Substring(0, index);
                    //Debug.Log(lower);
                }
                
                if(!string.IsNullOrEmpty(lower)){
 
                            string[] final = { lower + ","
                                    + entries[3] + ","
                                    + entries[4] + ","
                                    + entries[5] + ","
                                    + entries[7]
                                    };

                            string finalString = lower + ","
                                    + entries[3] + ","
                                    + entries[4] + ","
                                    + entries[5] + ","
                                    + entries[7];

                            string lowerString = lower;

                             
                             listName.Add(new Item { Name = lowerString, 
                                        Energy = entries[3], Protein = entries[4],
                                        Lipid = entries[5], Carb = entries[7]
                             });
                            //Debug.Log(finalString);     
                }
                else{
                    //Debug.Log("null name");
                }
                
            }
            
                
        }
        
        //Debug.Log("Read last line");

        //List<string> noDupes = nameListActual.Distinct(lower);
            List<Item> distinctItems = listName
                                    .GroupBy(i => i.Name)
                                    .Select(g => g.First())
                                    .ToList();

                            var stuff = distinctItems.Distinct().ToList();
                            foreach(var list in stuff){
                                string[] arrayNameList = { list.Name + ","
                                    + list.Energy + ","
                                    + list.Protein + ","
                                    + list.Lipid + ","
                                    + list.Carb
                                    };

                                string arrayNameString = list.Name + ","
                                    + list.Energy + ","
                                    + list.Protein + ","
                                    + list.Lipid + ","
                                    + list.Carb;

                                nameListActual.Add(arrayNameString);
                                //Debug.Log("array done: " + arrayNameString);

                            }
            string[] arrayNameListDone = nameListActual.ToArray();
            

            //string[] namesThatDistinct = distinctItems.ToArray();
            if(!File.Exists(filePath)){
                File.Create(filePath);
            }
            else{
                File.WriteAllLines(filePath, arrayNameListDone);
            }

        
        System.Console.ReadKey();
    }
    public class Item
    {
        public string Name { get;set; }
        public string Energy { get;set; }
        public string Protein { get;set; }
        public string Lipid { get;set; }
        public string Carb { get;set; }
    }


    
    

}
