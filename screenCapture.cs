using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenCapture : MonoBehaviour
{
    /*========READ ME FIRST SPACE COWBOY========*/
    //anything in 'single qutoes' is code/api function

    //Unity runs its code in multiple ways. THe first way is 'void Start()'
    //-which runs code on its first frame/on start up. Use this to initialize shit 
    //The other ones aren't neccesary to know except 'void Update', which is like void start
    //but runs every frame (but it's framerate dependent, so if ur game lags, ur code also lags)

    //Now we got both 'void Start' & 'void Update' out of the way, let look at what this entire code actually does

    /* FIRST take a set frame rate that we choose arbirtraly ( public int frameRate )
       and is sent as parameter to 'Time.captureFramerate'. We do this becuase 'Time.captureFramerate' slows the game
       down to allow another peice of code to capture the frame
       
       SECOND we create File/directory, whatever u wanna call it, which will be the place we can retreive all the captured frames.
       We make a new directory with 'System.IO.Directory.CreateDirectory(foldername)', which is just a regular C# API function.

       THIRD we create some way to activate the code to get the screen capture. I arbitraily choose the spacebar.
       'Input.GetKey()' takes in hardware input (mouse, keyboard, controller, ur mom) and you put '{}' underneath it to run code
       
       FOURTH we tell Unity that once we press space, grab the current frame. You grab frames with 'Application.CaptureScreenshot(name)'
       the 'name' part is jsut he name of the image u want it to have, but it must be formatted correctly, as follows:
                        
                    'string name = string.Format("{0}/{1:D04} shot.png", folder, Time.frameCount);'
         string.Format basically sets the framework of the screen cpature to take place. Here u specify the 
         name of the files u want the screen cap'ted pics to have, as well as the directory, and the frame count)

       
         */


    // The folder to contain our screenshots.
    // If the folder exists we will append numbers to create an empty folder.
    public string folder = "ScreenshotFolder";
    public int frameRate = 25;
    void Start()
    {
        // Set the playback framerate (real time will not relate to game time after this).
        Time.captureFramerate = frameRate;

        // Create the folder
        System.IO.Directory.CreateDirectory(folder);
    }


    void Update()
    {
        if (Input.GetKey("space"))
        {
            // Append filename to folder name (format is '0005 shot.png"')
            string name = string.Format("{0}/{1:D04} shot.png", folder, Time.frameCount);

            // Capture the screenshot to the specified file.
            Application.CaptureScreenshot(name);

            Debug.Log("ScreenCapping");
        }


    }
}