using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Opcje od Mara -> http://wklej.org/id/3417611/
public class MainMenu : MonoBehaviour{

    public void PlayGame()
    {
        //Checkpoints.LoadSaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //+1 should be a var
        //To mozna rozwiazac za pomoca wczytywania danych pliku .txt lub nawet xml 
        //Wystarczy zrobic metode prywatna wczytujaca plik i sprawdzajaca wartosc zmiennej 
    }

    private int LoadLevelNumber()
    {
        //Sprawdzic czy plik istenieje, jesli nie to zrob plik i wrzuc tam wartosc 1, metoda powinna zwrocic wtedy 1
        //Jesli plik istenieje wczytac zmienna z pliku i ja zwrocic
        //.TXT -> https://msdn.microsoft.com/pl-pl/library/system.io.stream(v=vs.110).aspx
        //.XML -> https://msdn.microsoft.com/pl-pl/library/system.xml.linq.xdocument(v=vs.110).aspx
        //To moze sie przydac do rozwiazania .xml -> https://stackoverflow.com/questions/18508765/edit-specific-element-in-xdocument
        //Przy xml lepiej wykorzystac bloki try i catch
        return 1;
    }

    //Do mara po ustawienia
    public void QuitGame()
    {
        //Jesli rozwiazania na checkpoint to powinna byc wykonana jakas metoda save typu:
        /*
         Checkpoints.SaveGame();
         */
        Debug.Log("QUIT");
        Application.Quit();
    }

    //Ta metoda powinna by statyczna w innej klasie np. Checkpoints
    private void SaveGame()
    {
        int Index = SceneManager.GetActiveScene().buildIndex;
        //Zapisac index do pliku xml
    }

}
