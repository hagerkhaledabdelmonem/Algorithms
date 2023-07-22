# Modulo Sum
## Description
Given a sequence of positive integers a1, a2, … an, and a positive integer M. Your goal is to determine if a non-empty subsequence of a1, a2, … an that the sum of numbers in this subsequence is divisible by m.

## Requirements:
Implement the following TWO functions in MOST EFFICIENT WAY (Hint: make sure to select the suitable solution direction),
 - 1st function: return whether there’s a subsequence that is divisible by M or not.
 - 2nd function: return the subsequence itself (if found), or null (if no such one).

## Function:
 - ### First Function:
   bool SolveValue(int[] items, int N, int M) <returns>true if there's subsequence with sum divisible by M... false otherwise
   
 - ### Second Function:
   int[] ConstructSolution(int[] items, int N, int M) <returns>if exists, return the numbers themselves whose sum is divisible by ‘M’ else, return null
   
## Example:

| Input  | Output | Subsequence | 
| -------| ------ | ----------- | 
| M = 5, items = [1,2,3]  |  true | 2, 3 |
| M = 6, items = [5]  |  false | Null |
| M = 6, items = [3,1,1,3]  |  true | 3, 3 |
| M = 6, items = [6,6,6,6,6,6]  |  true | 6 |


