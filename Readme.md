### Rafael Landivar University
### Formal and Automated Languages
### Derek André Menéndez Urizar
### Project carried out in the IDE Unity 2017.3.1f1

# Turing Machine Project
This project has the ability to simulate different turing machines, with the possibility of showing whether an entry is valid or not. Also the possibility
adding more turing machines is within reach, since you only have to add the rules through a dictionary and automatically the
new Turing machine.

The project looks like this image:
![](https://i.imgur.com/J7nbqCd.png)

To use the project, the following steps must be followed:

  1. Execute the .exe or play the machine from the IDE Unity 2017.3.1f1 (this or later)
  2. Choose the Turing machine that you want to simulate
  3. Enter the entry for the selected Turing machine.
  4. Start the machine.

## Using the Simulator

To use the simulator you must choose the Turing machine you want to use as shown in the following image:
![](https://i.imgur.com/If9ghr6.png)

Once the Turing machine has been chosen, you must enter the machine's entrance as shown in the following image:
![](https://i.imgur.com/MJbkVoP.png)

Once you have chosen your Turing Machine and entered its entry, you should only start the Turing machine with these
Steps:

In the menu select this button:
![](https://imgur.com/77TvaMu)

And so you can execute any entry in any Turing Machine.

## Approved Entry

If the Turing machine accepts the input then the following will happen on the screen:
![](https://i.imgur.com/iNQn1G4.png)

As you can see the head and spheres of each of the blocks of the machine will turn green, approving the entrance.

## Rejected Entry

If the Turing machine rejects the input then the following will happen on the screen:
![](https://i.imgur.com/HWhng1B.png)

As you can see the head and spheres of each of the blocks of the machine will turn red, rejecting the entry.

## Restarting the Turing Machine

When you finish reading an entry, you can restart the Turing machine by pressing this button.
![](https://i.imgur.com/bSM5kV2.png)

## Moving the camera

When the Turing machine of your result, you can move the camera with the arrow keys to zoom out enough to see the full result.

# Tickets by Turing machine

In the next section we will show the examples of how you should enter the entries on each of the Turing machines.

## Sum

The correct way to enter sums in the machine is as follows -> 11 + 11 or 11+ or +11

Example of results:

11+11 = BBB1111BBB  
11+111 = BBB11111BBB  

Note: you must not add the same symbol or any other symbol other than the one shown in the example.

## Subtraction

The correct way to enter subtraction in the machine is as follows -> 11-11 or -11 or 11-

Example of results:

11-11 = BBBBBB  
11-111 = BBB-1BBB  

Note: you must not add the same symbol or any other symbol other than the one shown in the example.

## Multiplication

The correct way to enter multiplications in the machine is as follows -> 11 * 11

Example of results:

11*11 = BBB1111BBB  
11*111 = BBB111111BBB  

Note: you must not add the same symbol or any other symbol other than the one shown in the example.

## Palindromes

The correct way to enter palindromes in the machine is as follows and only with letters "abc" -> aba or aabbaa or acca

Example of results:

aba = BBBBBB (siendo aprobado)  
abba = BBBBBB (siendo aprobado)  

Note: you must not add the same symbol or any other symbol other than the one shown in the example.

## String Copy

The correct way to enter a chain copy in the machine is as follows and only with letters "abc" -> abc or abbc or aaa or ccc etc.

Example of results:

aa = BBBaaaaBBB (being approved)
abba = BBBabbaabbaBBB (being approved) 

Note: you must not add the same symbol or any other symbol other than the one shown in the example.

# Why is my project robust?

Firstly because several tests have been implemented in each of the Turing machines and all have given the expected result. Besides having
The ease of importing new machines to the project means that the project is not only robust but also expandable. Besides that it is implemented
the machine in 3D and is quite pleasing to the eye, taking into account that in Unity so far there is no 3D Turing machine.

# Do you want to be a collaborator?

Send me an email to derekurizar@gmail.com and tell me what you want to add.





