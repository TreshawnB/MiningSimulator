using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//Script Has been change by Treshawn Bolton Contact ItsTre8r@gmail.com for help/questions

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;

    //List used for Inventory management
    public List<GameObject> EmptySlots = new List<GameObject>();
    public List<GameObject> FilledSlots = new List<GameObject>();

    //Script for spawning the selected sell buttons
    public List<GameObject> MatinfoList = new List<GameObject>();
    public GameObject MatInfo;

    //keeps a list of each unqiue ore type
    private Dictionary<string, int> counts = new Dictionary<string, int>();

    //Slider that hold all of the MatInfo game objects
    public Transform SliderContent;

    void Start()
    {
        // Creates inventory slots
        for (int i = 0; i < slotCount; i++)
        {
            //set the object just created to a gameobject in the script
            GameObject slot = Instantiate(slotPrefab, inventoryPanel.transform);

            //add that gameobject just created to the empty slots list so we can add something to it later
            EmptySlots.Add(slot);
        }
    }

    //This function is called in the Pickupable script and add the game object that called it to the slots current item then remove that slot from the empty slots list to the filled slots list
    public void AddItemtoInv(GameObject item)
    {
        //Checks if empty slots list has at least one slot (Prevents overlapping slots)
        if (EmptySlots.Count > 0)
        {
            //sets the first object in the list to slot Obj
            GameObject slotObj = EmptySlots[0];
            //gets slot Objs script and sets it to slot
            Slot slot = slotObj.GetComponent<Slot>();

            // Spawns the acutal item in the slot and sets it to spawnedItem
            GameObject spawnedItem = Instantiate(item);

            // Remove (Clone) from the name so we can display it later in the sell
            spawnedItem.name = item.name;

            // sets the spawned item to the child of the acutal slot
            spawnedItem.transform.SetParent(slotObj.transform, false);

            //makes the slots current slot item the spawned item (Important for the drag item script)
            slot.currentItem = spawnedItem;

            //Adds to the Filled Slot list and removes from Empty Slots list
            FilledSlots.Add(slotObj);
            EmptySlots.RemoveAt(0);
        }
    }
    //sorts the Inventory every time the shop ui is opened
    public void Sortinv()
    {
        //checks if Filled slots is less than 0 if false contitnues the rest of the function
        if (FilledSlots.Count <= 0) return;

        //removes every thing from counts dictionary
        counts.Clear();

        foreach (GameObject obj in FilledSlots)
        {
            //Sets the current element in the filled slots list to slot and gets its script
            Slot slot = obj.GetComponent<Slot>();

            //makes sure the current item is actually their
            if (slot.currentItem == null)
                continue;

            //Gets the Obj in the filled slots list name
            string itemName = slot.currentItem.name;

            //checks if the this is the first time the name occurs in the dictionary
            if (counts.ContainsKey(itemName))
            {
                counts[itemName]++;
                //adds to the count if item is already existing
            }
            else
            {
                counts[itemName] = 1;
                //creates new count
            }
        }
    }

    //Using the dictionary this spawn the buttons for the sell (Called when the shop Ui is opened and closed)
    public void SpawnMatInfo()
    {
        //checks if the dictionary has atleast 1 
        if (counts.Count <= 0) return;

        foreach (KeyValuePair<string, int> pair in counts)
        {
            //spawns the sell button
            GameObject material = Instantiate(MatInfo, SliderContent);

            //gets the object just spawned and gets its script
            MaterialInfoScript matScript = material.GetComponent<MaterialInfoScript>();

            //sets the scripts name and amount to the value in the dictionary 
            matScript.Amount = pair.Value;
            matScript.Name = pair.Key;

            //adds this game object to a list
            MatinfoList.Add(material);

            //changes the icon by matching item name
            foreach (GameObject slotObj in FilledSlots)
            {
                //gets the script on the filled slot
                Slot slot = slotObj.GetComponent<Slot>();

                //checks if the current item isnt nothing and if its name is the same as the stored value in the dictionary
                if (slot.currentItem != null && slot.currentItem.name == pair.Key)
                {
                    //gets the slots child that holds the sprite (name is very Important)
                    Transform iconTransform = slot.currentItem.transform.Find("ItemC");

                    if (iconTransform != null)
                    {
                        //creates a new image and sets it to the child of the slot
                        Image iconImage = iconTransform.GetComponent<Image>();

                        if (iconImage != null)
                        {
                            //gets the componet on the material object and set its sprite to the childs sprite (name is very Important)
                            material.transform.Find("MatIcon").GetComponent<Image>().sprite = iconImage.sprite;
                        }
                    }

                    break;
                }
            }
        }
    }
    //Removes all Filled SLots from the list (Called when sell all is clicked)
    public void RemoveAllFilledSlots()
    {
        if (FilledSlots.Count > 0)
        {
            foreach (GameObject filled in FilledSlots)
            {
                if (filled != null)
                {
                    Slot slot = filled.GetComponent<Slot>();

                    if (slot.currentItem != null)
                    {
                        //deletes the slots current item
                        Destroy(slot.currentItem);
                    }

                    //makes the slots current item null
                    slot.currentItem = null;

                    for (int i = filled.transform.childCount - 1; i >= 0; i--)
                    {
                        //deletes the actual game object on the slot
                        Destroy(filled.transform.GetChild(i).gameObject);
                    }
                }
            }

            EmptySlots.AddRange(FilledSlots);
            //adds all the slots in the filled slots list to the empty slots list
            FilledSlots.Clear();
            //removes everything i the filled slots list
            counts.Clear();
        }
    }

    //removes all the filled slots that are selected (Called when selled selected is clicked)
    public void RemoveSpeficFilledSlots(string Objecttoremove)
    {
        for (int i = FilledSlots.Count - 1; i >= 0; i--)
        {
            GameObject filled = FilledSlots[i];

            if (filled != null)
            {
                Slot slot = filled.GetComponent<Slot>();

                if (slot.currentItem != null &&
                    slot.currentItem.name == Objecttoremove)
                {
                    Destroy(slot.currentItem);

                    slot.currentItem = null;

                    for (int c = filled.transform.childCount - 1; c >= 0; c--)
                    {
                        Destroy(filled.transform.GetChild(c).gameObject);
                    }

                    EmptySlots.Add(filled);
                    FilledSlots.RemoveAt(i);
                    Debug.Log(counts);
                }
            }
        }
        counts.Clear();
    }
}