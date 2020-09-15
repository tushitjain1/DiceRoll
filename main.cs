using System;
using static System.Console;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    dice_game(); //calling the method to start the program
  }

  public static void dice_game(){
    List<int> possible_outcomes = new List<int>(){  //a list  of all the possible outcomes of a dice rolls
      1,
      2,
      3,
      4,
      5,
      6
    };
    Random rnd = new Random(); //creats a new object random and assings random to it
    var start_game = false;
    WriteLine("Are you ready to start your game? Enter 'y' to start or 'r' for the rules of the game:");
    var reponse = ReadLine();
    WriteLine(""); //to add spacing between lines
    if (reponse == "y"){
      start_game = true;
    } //these if and else if statements are basically present to allow the user to get the rules of the game
    else if (reponse == "r"){
      WriteLine("You roll a dice and keep adding to your score. You can choose to stop after each role, if you roll a six then you are out and lose all of your points and get zero for the game. The scores are exported to a High Score Table along with the players name.");
      start_game = true;   
    }
    IDictionary<string, int> high_score = new Dictionary<string, int>(); //empty dictionary that will keep track of the high scores
    while (start_game == true){ // starts the game using the flag made before
      WriteLine("What is your name? "); // asks user for their name
      var player_name = ReadLine();
      var roll_again = true; // another flag for rolling again or walking away
      var score = 0; // current player score
      //start_game = false;
      while (roll_again == true){
        var roll = possible_outcomes[rnd.Next(possible_outcomes.Count)];
        if (roll != 6){
          score += roll;
          WriteLine("You rolled a {0}" , roll);
          WriteLine("Your current score is {0}", score);
          WriteLine("Do you want to walk away? 'y' to walk away, or hit enter to continue playing. ");
          var choice_to_walk = ReadLine();
          if (choice_to_walk == "y"){
            WriteLine("You have decided to walk away with the current score of {0}" , score);
            roll_again = false;
            WriteLine("Do you want to play again? Press 'y' to play again or hit enter to exit. ");
            var play_again = ReadLine();
            if (play_again == "y"){
              WriteLine("Play under a different name.");
            }
            else{
              start_game = false;
            }
          }
        
        }
        else if (roll == 6){
          WriteLine("You have rolled a six and have lost the game.");
          score = 0;
          roll_again = false;
          WriteLine("Do you want to play again? Press 'y' to play again or hit enter to exit. ");
          var play_again = ReadLine();
          if (play_again == "y"){
            WriteLine("Play under a different name.");
          }
          else{
            start_game = false;
          }

 
        }
      }
      high_score.Add(player_name,score);
      WriteLine("Leaderboard:");
      WriteLine(""); //provides gap
      foreach(KeyValuePair<string, int> kvp in high_score)
			Console.WriteLine("Name: {0}, Score: {1}", kvp.Key, kvp.Value);
    }

  }
}