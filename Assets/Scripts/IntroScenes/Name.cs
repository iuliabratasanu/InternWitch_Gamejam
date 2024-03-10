using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class Name : MonoBehaviour
{
    public TextMeshProUGUI display_player_name;

    private void Awake()
    {
        display_player_name.text = "This is to certify that " + IntroductionScript.scene1.player_name + " has successfully completed the rigorous and enchanting Supreme Witch Internship Program in the mystical realm of potions and spells." + System.Environment.NewLine + System.Environment.NewLine + "Throughout the magical journey, " + IntroductionScript.scene1.player_name + " has exhibited unparalleled dedication, creativity, and a profound understanding of the art of potion-making. Their commitment to mastering the craft and unraveling the secrets of magic has set them apart as a true sorcerer of extraordinary potential." + System.Environment.NewLine + System.Environment.NewLine + IntroductionScript.scene1.player_name + " has not only embraced the responsibilities of continuing the witches' tradition but has also brought joy, laughter, and a touch of enchantment to the lives of countless beings. Through the creation of beauty potions, aging elixirs, and time-reversal spells," + IntroductionScript.scene1.player_name + " has proven to be a master of both skill and humor in the magical world." + System.Environment.NewLine + System.Environment.NewLine + "The completion of this internship marks the evolution of " + IntroductionScript.scene1.player_name + " into a Supreme Witch, equipped with knowledge, wit, and a magical notebook filled with the secrets of potion-making. As " + IntroductionScript.scene1.player_name + " triumphantly graduates from this program, we bestow upon them the title of Supreme Witch, with the full confidence that they will continue to weave magic and wonder in the world beyond.";



        //display_player_name.text = "Congratulations, " + IntroductionScript.scene1.player_name + "!";

    }

    public void Exit()
    {
        Application.Quit();
    }
}
