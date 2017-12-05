using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    public GameObject grid;

    // furniture
    public GameObject rug;
    public GameObject chair;
    public GameObject sheet;
    public GameObject pillow_square;

    // pillows
    public GameObject pillow1;
    public GameObject pillow2;
    public GameObject pillow3;
    public GameObject pillow4;
    public GameObject pillow5;
    public GameObject pillow6;

    // UI elements
    public GameObject instructions;
    public GameObject spacePicker;
    public GameObject pillowPicker;
    public GameObject chairPicker;
    public GameObject rugPicker;
    public GameObject pictureViewer;

    // selection state
    public string state = "introduction";
    public string prevState = "rug";

    // index of selectors
    private int[] index_furniture = { 0, 0 };
    private int[] index_pillow = { 0, 0 };
    private int[] index_chair = { 0, 0 };
    private int[] index_rug = { 0, 0 };
    private int[] index_space = { 0, 0 };

    // Use this for initialization
    void Start () {

        // deactivate all room components
        grid.SetActive(false);
        rug.SetActive(false);
        chair.SetActive(false);
        sheet.SetActive(false);
        pillow_square.SetActive(false);

        // Deactive the canvas
        spacePicker.SetActive(false);
        pictureViewer.SetActive(false);

    }

	// Update is called once per frame
	void Update () {

	}

    public void ButtonContinue() {
        // continue the instructions

        // deactivate the instructions
        instructions.SetActive(false);

        // activate the grid
        grid.SetActive(true);

        // show the furniture picking screen
        rugPicker.SetActive(true);

        state = "rug";
    }

    private void MovefurnitureSelection(GameObject selection)
    {
        int col = (index_rug[1] + 1) % 2;
        int row = index_rug[0];

        if (col == 0)
        {
            row = (row + 1) % 2;
        }

        index_rug[0] = row;
        index_rug[1] = col;


        float x = ((col - 1) * 110.0f) + 55.0f;
        float y = (row - 1) * 110.0f;

        selection.transform.localPosition = new Vector3(x, y, 0.0f);
    }

    private void MovechairSelection(GameObject selection)
    {
        int col = (index_chair[1] + 1) % 3;

        float x = (col - 1) * 110.0f;
        
        index_chair[1] = col;
        
        selection.transform.localPosition = new Vector3(x, 0, 0.0f);
    }


    private void MoverugSelection(GameObject selection)
    {
        int col = (index_rug[1] + 1) % 2;
        int row = index_rug[0];

        if (col == 0)
        {
            row = (row + 1) % 2;
        }

        index_rug[0] = row;
        index_rug[1] = col;

        float x = ((col - 1) * 110.0f) + 55.0f;
        float y = 55.0f;

        if(row == 1){
            y = -55.0f;
        }
           

        selection.transform.localPosition = new Vector3(x, y, 0.0f);
    }

    private void MovespaceSelection(GameObject selection)
    {
        int col = (index_space[1] + 1) % 3;
        int row = index_space[0];

        if(col == 1 && row == 1)
        {
            col = 2;
        }

        if (col == 0)
        {
            row = (row + 1) % 3;
        }

        Debug.Log(row);
        Debug.Log(col);

        float x = ((col - 1) * 110.0f);
        float y = (row - 1) * -110.0f;

        index_space[0] = row;
        index_space[1] = col;

        selection.transform.localPosition = new Vector3(x, y, 0.0f);
    }

    private void MovepillowSelection(GameObject selection)
    {
        int col = (index_pillow[1] + 1) % 2;
        int row = index_pillow[0];

        if (col == 0)
        {
            row = (row + 1) % 3;
        }

        float x = ((col - 1) * 110.0f) + 55.0f;
        float y = (row - 1) * -110.0f;

        index_pillow[0] = row;
        index_pillow[1] = col;

        selection.transform.localPosition = new Vector3(x, y, 0.0f);
    }
    
    private void GetSelectionPosition()
    {
        int row = 0;
        int col = 0;

        switch (state)
        {
            case "rug":
                row = index_rug[0];
                col = index_rug[1];
                Debug.Log(row);
                Debug.Log(col);

                if (row == 0 && col == 0)
                {
                    rug.SetActive(true);
                    GameObject.Find("Rug_Square_2").gameObject.SetActive(false);
                    GameObject.Find("Rug_Square_3").gameObject.SetActive(false);
                    GameObject.Find("Rug_Square_4").gameObject.SetActive(false);
                    prevState = "Rug_Square_1";
                }
                else if (row == 0 && col == 1)
                {
                    rug.SetActive(true);
                    GameObject.Find("Rug_Square_3").gameObject.SetActive(false);
                    GameObject.Find("Rug_Square_2").gameObject.SetActive(false);
                    GameObject.Find("Rug_Square_1").gameObject.SetActive(false);
                    prevState = "Rug_Square_4";

                }
                else if (row == 1 && col == 0)
                {
                    rug.SetActive(true);
                    GameObject.Find("Rug_Square_4").gameObject.SetActive(false);
                    GameObject.Find("Rug_Square_2").gameObject.SetActive(false);
                    GameObject.Find("Rug_Square_1").gameObject.SetActive(false);
                    prevState = "Rug_Square_3";

                }
                else if (row == 1 && col == 1)
                {
                    rug.SetActive(true);
                    GameObject.Find("Rug_Square_1").gameObject.SetActive(false);
                    GameObject.Find("Rug_Square_3").gameObject.SetActive(false);
                    GameObject.Find("Rug_Square_4").gameObject.SetActive(false);
                    prevState = "Rug_Square_2";

                }

                rugPicker.SetActive(false);

                state = "chair";

                chairPicker.SetActive(true);

                break;

            case "chair":
                col = index_chair[1];

                switch (col)
                {
                    case 0:
                        chair.SetActive(true);
                        GameObject.Find("Chair_Red").gameObject.SetActive(false);
                        GameObject.Find("Chair_Modern").gameObject.SetActive(false);
                        prevState = "Chair_Yellow";
                        break;

                    case 1:
                        chair.SetActive(true);
                        GameObject.Find("Chair_Yellow").gameObject.SetActive(false);
                        GameObject.Find("Chair_Modern").gameObject.SetActive(false);
                        prevState = "Chair_Red";
                        break;

                    case 2:
                        chair.SetActive(true);
                        GameObject.Find("Chair_Red").gameObject.SetActive(false);
                        GameObject.Find("Chair_Yellow").gameObject.SetActive(false);
                        prevState = "Chair_Modern";
                        break;
                }

                chairPicker.SetActive(false);

                state = "space";

                spacePicker.SetActive(true);

                break;

            case "pillow":
                row = index_pillow[0];
                col = index_pillow[1];

                if (row == 0 && col == 0)
                {
                    pillow_square.SetActive(true);
                    pillow2.SetActive(false);
                    pillow3.SetActive(false);
                    pillow4.SetActive(false);
                    pillow5.SetActive(false);
                    pillow6.SetActive(false);
                    prevState = "pillow_square";
                }
                else if (row == 0 && col == 1)
                {
                    pillow_square.SetActive(true);
                    pillow1.SetActive(false);
                    pillow3.SetActive(false);
                    pillow4.SetActive(false);
                    pillow5.SetActive(false);
                    pillow6.SetActive(false);
                    prevState = "pillow_square";
                }
                else if (row == 1 && col == 0)
                {
                    pillow_square.SetActive(true);
                    pillow1.SetActive(false);
                    pillow2.SetActive(false);
                    pillow4.SetActive(false);
                    pillow5.SetActive(false);
                    pillow6.SetActive(false);
                    prevState = "pillow_square";
                }
                else if (row == 1 && col == 1)
                {
                    pillow_square.SetActive(true);
                    pillow1.SetActive(false);
                    pillow2.SetActive(false);
                    pillow3.SetActive(false);
                    pillow5.SetActive(false);
                    pillow6.SetActive(false);
                    prevState = "pillow_square";
                }
                else if (row == 2 && col == 0)
                {
                    pillow_square.SetActive(true);
                    pillow1.SetActive(false);
                    pillow2.SetActive(false);
                    pillow3.SetActive(false);
                    pillow4.SetActive(false);
                    pillow6.SetActive(false);
                    prevState = "pillow_square";
                }
                else if (row == 2 && col == 1)
                {
                    pillow_square.SetActive(true);
                    pillow1.SetActive(false);
                    pillow2.SetActive(false);
                    pillow3.SetActive(false);
                    pillow4.SetActive(false);
                    pillow5.SetActive(false);
                    prevState = "pillow_square";
                }

                pillowPicker.SetActive(false);

                state = "space";

                spacePicker.SetActive(true);

                Debug.Log("DONE THE PILLOWS OMMMMMMMMMMMMMMMMMMMMMMMMMG");
                break;

            case "space":
                row = index_space[0];
                col = index_space[1];
                
                GameObject furniture = GameObject.Find(prevState);

                if(furniture == null)
                {
                    furniture = pillow_square;
                }
                else
                {
                    furniture = furniture.gameObject;
                }

                float oldX = furniture.transform.localPosition.x;
                float oldY = furniture.transform.localPosition.y;
                float oldZ = furniture.transform.localPosition.z;

                float newX = oldX;
                float newY = oldY;
                float newZ = oldZ;

                if (prevState.Contains("Chair"))
                {
                    if (row == 0)
                    {
                        newX = -8.635695f;
                    }
                    else if (row == 1)
                    {
                        newX = 0;
                    }
                    else if (row == 2)
                    {
                        newX = 9;
                    }

                    // col
                    if (col == 0)
                    {
                        newZ = -3.879832f;
                    }
                    else if (col == 1)
                    {
                        newZ = -1;
                    }
                    else if (col == 2)
                    {
                        newZ = 10;
                    }

                    state = "pillow";
                    pillowPicker.SetActive(true);

                    index_space[0] = 0;
                    index_space[1] = 0;
                    GameObject selection = GameObject.Find("spaceSelection").gameObject;
                    selection.transform.localPosition = new Vector3(-110f, 110f, 0f);
                }
                if (prevState == "pillow_square")
                {
                    if (row == 0)
                    {
                        newX = -6.635695f;
                        furniture.transform.Rotate(Vector3.up, 0f);
                    }
                    else if (row == 1)
                    {
                        newX = 1;
                        furniture.transform.Rotate(Vector3.up, 90f);
                    }
                    else if (row == 2)
                    {
                        newX = 10;
                        furniture.transform.Rotate(Vector3.up, 180f);
                    }

                    // col
                    if (col == 0)
                    {
                        newZ = -11;
                        furniture.transform.Rotate(Vector3.up, -90f);
                    }
                    else if (col == 1)
                    {
                        newZ = 0;
                    }
                    else if (col == 2)
                    {
                        newZ = 9.092624f;
                    }

                    state = "explore";
                }

                furniture.transform.localPosition = new Vector3(newX, newY, newZ);

                spacePicker.SetActive(false);

                break;

            default:
                break;
        }
        
    }

    
    private void GestureMessage(string gesture)
    {
        switch(gesture)
        {
            case "SwipeLeft":
                GestureSwipeLeft();
                break;

            case "Sit":
                GestureSit();
                break;

            case "WaveLeft":
                GestureSwipeDown();
                break;

            default:

                Debug.Log(gesture);
                break;
        }
    }

    private void GestureSwipeLeft()
    {
        if (state != "explore" || state != "photo")
        {
            GameObject selection = GameObject.Find(state + "Selection").gameObject;

            if (selection != null)
            {

                this.SendMessageUpwards("Move" + state + "Selection", selection);
            }
            else
            {
                Debug.Log("Hmmmmmmmmmmmmmmmmm");
            }
        }
    }

    private void GestureSwipeDown()
    {
        if(state != "explore" || state != "photo")
        {
            GameObject selection = GameObject.Find(state + "Selection").gameObject;

            if (selection != null)
            {
                GetSelectionPosition();
            }
            else
            {
                Debug.Log("Hmmmmmmmmmmmmmmmmm");
            }
        }
    }

    private void GestureSit()
    {

    }
}
