using UnityEngine;

public class HowtoCreateNewOre : MonoBehaviour
{
    //This was created by Treshawn Bolton Contact me at ItsTre8r@gmail.com or (352) 258-3508

    //Step by Step how to easily create new functional ore types

    //First create or find a ore sprite and a ore drop sprite (I suggest right clicking the ore sprite i created and pressing the REVEAL IN FINDER button)
    //Then Press the file and duplicate it and drag the new duplicated file to downloads
    //The sprites were made on a website called piskel (All you have to do is search piskel on google and it should show up)
    //Then on the piskel website click "File/Import" button, then Under IMPORT FROM PICTURE press Browse images and find the file you just duplicated
    //once you import the image you can change it however you like once you done locate the "Export" button then go to "PNG" then download
    //The Import the in unity, click the object and change the "Filter Mode" to "Point (no filter)"

    //After you have the sprites you want to use go the Ore types - RegularRock and double click the Rock prefab until it opens 
    //Then in the Rock Prefab click and copy the rock Object in the Hiearchy, then click the arrow (<) at the top of the Hiearchy to go back to the regular scene
    //Once your back in the scene Paste the rock object
    //Now do this for each of the RockBit prefabs, then go to the UI folder and do the same for both of the Slots (their named "Rock Bits" and "Shiny Rock Bits")
    
    //Once you have all of these objects in the regular scene go to the Rock object and rename it to the new ore you are creating
    //Also Rename the RockBits and the ShinyRockBits objects aswell be sure to not include Spaces so it doesnt get confusing later
    //Then Rename the Rock bits and the Shiny Rock Bits objects here you can include space (Note however you name these it how it will show up when selling)
    //After in the Hierarchy new object you just create and ensure it is the drop (the RockBits/ShinyRockBits objects) click the arrow on the object and click the "Sprite" in the Hierarchy
    //Then in the Inspectior open the Sprite Renderer Componet and click the circle next to the "Sprite" (Or you could just go to the sprite you imported and drag it atop the black bar)
    //Do this for each of the drops 

    //Then repeat this process for each of the Slot objects (the Shiny Rock Bits and Rock Bits) 
    //Do this by click the arrow again and selecting the "ItemC" and change the "Source Image" in the "Image" componet 
    //Change this image to the same to the drop sprite (This is how it will look in the inventory)

    //Now that you have all of the images/sprites change select the Slot related object and drag them into the ore types folder
    //Create a new folder (right click an empty area, move your mouse to create and press "Folder")
    //Name it to the new ore you created then create a new folder inside that folder and name it UI then drag the prefabs you made into it
    //Then in the scene delete the prefabs (ONLY IN THE SCENE, NOT THE ACTUAL PREFABS)

    //Now Click the drop related objects and click the "Pickupable(Script)" componet and change the "Itemininv" to the Slot prefab you just made
    //Do this for both of the drop then made them into prefabs and delete them from the scene

    //Now for the last step click the ore object and in its "Minable(Script)" componet change the "Objects To Spawn" to the drop prefabs you just created (I recomend putting multiple of the less valuble drop to increase the chance of it spawning)
    //If you want the ore to drop more or less change the Min amount and Max Amount
    //Also Change the health (Each click does 10 damage without any upgrade)

    //Now make the ore object into a prefab and move it to an empty area in the scene (Unless a Spawn Script Is Implemented)
    
    //For the last part of this find the "ShopScript" and open it
    //in the "CountSellSelectedValue" function go to the last if statement and duplicate(Copy and paste) the entire statement under it
    //Change whatevers in the "" in this selected.GetComponent<MaterialInfoScript>().Name == "    " to what you name the Slot objects
    //do this for both the slot objects
    //Then in the SellSelectedvalue =+ SellSelectedvalue + selected.GetComponent<MaterialInfoScript>().Amount * ?;
    //Change whatever the number is to what you want each of the drops to be worth
    //Then your done!!
}
