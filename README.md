# n_net_poker_player

# Preamble

n_net_poker_player is a console program designed to utilize a neural network to play poker with a tight aggressive playstyle.

This project initally was created in mid to late 2022 for a university assignment

Currently, the network used does not learn and uses an earlier version of n_net, my neural network framework (a link to an updated version can be found here: https://github.com/33365user/n-net)

# Methods and Tools

The method chosen to implement the tight aggressive-poker playing artificial intelligence (AI) was a non-learning neural network.

The neural network will assume that the game of poker is being played with a single 52 card deck

The neural network utilizes:

  Eight inputs (each input corresponding with all possible hands within poker, excluding a high card)
  
  Three outputs (each output corresponding with all possible actions a player could take, those being, bet, check and fold)
  
  Three weights to ensure that the best three hands (a royal flush, straight flush and four of a kind ) are played
  
  Three biases to determine when a given output should fire
  
To determine whether or not a node should fire, firstly, the program determines if there is a playable hand, if there isn’t, the only node that will fire is the fold node. 

If the network determines that the player does have a hand, the highest rank within that hand will be converted into a score, then that score will be compared to the three biases.

If the score is higher than .8 then the network will prompt the user to bet

If the score is higher than .6 but lower than .8, the network will prompt the user to limp/check this round

If the score is lower than .6, the network will prompt the user to fold.

The score is determined by taking the highest ranked card in the hand, then converting the rank of the car into a numerical value.

Rank in Poker      Rank converted to score
2                  .2
3                  .3
4                  .4
5                  .5
6                  .6
7                  .7
8                  .8
9                  .9
10                 1.0
J                  1.1
Q                  1.2
K                  1.3
A                  1.4

