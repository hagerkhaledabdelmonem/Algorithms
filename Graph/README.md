# Community Detection
## Description:
In FCIS-social app, students are linked to each other via a friend-relationship. However, due to different interests, students of the same interest tend to link together forming a small community.
Given an **UNDIRECTED Graph** with relations between different students, count the number of different communities in this app.

## Input:
 - |V| = from 4000 to 8000
 - |E| = sparse or dense
 - Number of communities = from 1 to 100

## Function Implemention:
static int CountCommunities(KeyValuePair<string, string>[] edges)
"edges": array of friend-relation edges in the graph (where key: studentID1, value: studentID2)

## returns:
Number of different communities in the Graph

## Example: 
edges1[0] = new KeyValuePair<string, string>("1", "4"); 
edges1[1] = new KeyValuePair<string, string>("4", "5"); 
### Expected Output = 1;



edges4[0] = new KeyValuePair<string, string>("1", "5"); 
edges4[1] = new KeyValuePair<string, string>("1", "4"); 
edges4[2] = new KeyValuePair<string, string>("1", "3"); 
edges4[3] = new KeyValuePair<string, string>("1", "2"); 
edges4[4] = new KeyValuePair<string, string>("2", "3"); 
edges4[5] = new KeyValuePair<string, string>("3", "4"); 
edges4[6] = new KeyValuePair<string, string>("4", "5"); 
edges4[7] = new KeyValuePair<string, string>("5", "2"); 
edges4[8] = new KeyValuePair<string, string>("6", "7");
### Expected Output = 2;
