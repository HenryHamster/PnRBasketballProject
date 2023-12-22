# Basketball Vision Training System

## About this project
* Unity Version: 2019.4.21
* Build for Device: Oculus Quest 2
* Toolkit: Oculus Integration
* Speech Recogition: Oculus Voice SDK
* Description: This project is the basketball vision training demo version, including three configurations (i.e., task, opponent, and dribble). The user can use the pitch gesture as Oculus defined to select the configuration for the training task and use speech to respond to the answer.

## Scripts
### IM (Interaction Module)
* MenuManger: The handler for the menu user interface, which includes setting configuration before training and returning the training.


### TCGM (Task Content Generation Module)
* LookAtUser: For each canvas above the virtual player, let it always can face the user.
* OPlayerController: The handler for each opponent virtual player includes (1) Initialize the position (2) Set the next position while running with trajectory. (3) Set the animation each idle or running.
* TaskManager: Set up the task content according to the configuration selected by the user. It includes (1) Setup for each question and (2) Pushing the state in the training such as controlling the virtual player to execute the next position.
* TimerManager: The handler for countdown.
* TPlayerController: The handler for each teammate virtual player includes (1) Initialize the position (2) Set the next position while running with trajectory. (3) Set the animation each idle or running.
* TrajectoryManager: The handler for trajectory includes (1) Loading and parsing trajectory from Resource Folder. (2) Generating the trajectory of the defender. (3) Getting the position for each virtual player at runtime.

### Others
* AudioManager: Responsible for selecting and playing different audio according to the answer correct or not.
* CorrectManager: Check the answer to which the user response.

## Demo
![image](https://gitlab.com/Demi871023/basketball-vision-training/-/raw/main/demo.gif)
