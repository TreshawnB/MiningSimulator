using UnityEngine;

public class BasicDescriptionOfwhatidid : MonoBehaviour
{
    //Interact System
    //I did this by adding/creating a script for the player called PlayerPickupSystem
    //The logic goes as follows - The script checks every frame if a empty on the player is coliding with a certain layer
    //then i created another script for the interactible objects called InteractSystem its logic goes as follows - it first finds the Player object 
    //then using the inrange varible from the players script and its own inrange varible to ensure the object is in interact range
    //Then using separate scripts that use the interact system Ex (ShopScript, Pickupable)

    //Implemented the Pickupable system with the already made Inventory system
    //Basicly first the after the slot objects are spawned i add them to an empty slots list (This is done in the InventoryController)
    //Then When an item is picked up assign the slot verison of itsself to a parameter in the function AddItemtoInv and deletes itself
    //then in the AddItemtoInv it makes itsself the current item of the first object in the empty slots list
    //then it instantiates itsself and removes the (Clone) from its name and sets if position
    //After it adds it self to another list called filled slots and removes itself from empty slots

    //Sell System
    //This was very complicated so it will be difficult to explain, ill try my best
    //first in a function called Sortinv() in the InventoryController a dictionary called counts is clear (All Elements inside are removed)
    //then for each object in filled slots it checks if counts already contains a key for it and either add one to the value or creates a new value for it
    //Sortinv() is called very time the shop Ui is opened (This ensure the inventory is always up to date)
    //then in the SpawnMatInfo() function for each pair in counts it instantiates the button for selected sell
    //then it gets the script of the button it just spawn and sets its value to the pair value, then add the button to the MatinfoList list
    //after for each object in the filled slots list it checks if one of the values in counts matches if so it changes the sprite on the button to the sprite on the filled slot object
    //this function is also called every time the Shop ui is opened
    //Now for the selected sell the material info sets itsself to the parameter on the function in the ShopScript called Select_Deselect()
    //In the Select_Deselect() function in a list called Selectedsell it checks if the object in the parameter is already in the list
    //if so it removes it from the list else it added it to the list
    
    //*Not Finished Explaining*
}
