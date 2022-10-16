
using System;
using System.Collections;

namespace name
{
    class Program {  

            // Goal: Given list of [id, score] sublists, return
            // the average of the top 5 scores for each id in list in increasing order
            // Assuming id and score are ints as dictated in examples

            // Constraints
            // 1 <= items.length <= 1000
            // items[i].length == 2
            // 1 <= IDi <= 1000
            // 0 <= scorei <= 100
            // For each IDi, there will be at least five scores

            // Things to Consider
            // have to keep track of ids we previously encountered
            // have to keep track of the number of times an id was encountered
            // need to continously keep track of the minimum of the id's top 5 scores 

        // Returns the average of the top 5 scores for each unique id is a list
        // Parameter: 2-D array of <id,score>
        // Output: 2-D array <id, average of top 5 scores> 
        static int[,] getTopFiveAverages(int[,] items)
        {            
            int[,] result;

            // create sorted dict of <id, priority queue> to keep
            // track of previous ids
            SortedDictionary<int, PriorityQueue<int,int>> dict = new SortedDictionary<int, PriorityQueue<int,int>>();

            // for every sublist in items:
            for (int sublist = 0 ; sublist < items.GetLength(0); sublist++){

              var currID = items[sublist,0];
              var currVal = items[sublist,1];

              // check if id is already in dict
              if(!dict.ContainsKey(currID)){
                // if not insert new key pair of <id, priority queue>
                dict.Add(currID, new PriorityQueue<int, int>());
              }

              // Add current score to priority queue 
              dict[currID].Enqueue(currVal, currVal);
              
              // remove minimum score from id's queue if
              // id is encountered more than 5 times
              if(dict[currID].Count > 5){
                dict[currID].Dequeue();
              }
            }

            result = new int[dict.Count,2];
            int resultIndex = 0;

             // for each item in dict calculate average
             // and store <id, average> in result
             foreach (var pair in dict){
                int currSum = 0;
                foreach (var i in Enumerable.Range(0, 5)){
                    currSum += (pair.Value).Dequeue();
                }
                result[resultIndex,0] = pair.Key;
                result[resultIndex,1] = (currSum/5);
                resultIndex++;
             }
  
           return result;
        }     
        
        public static void Main()
        {
             /*int [,] items =  {{1,91},{1,92},{2,93},{2,97},{1,60},{2,77},
                                {1,65},{1,87},{1,100},{2,100},{2,76}}; */

            int [,] items =  {{1,100},{7,100},{1,100},{7,100},{1,100},{7,100},{1,100},{7,100},{1,100},{7,100}};


            int [,] result = getTopFiveAverages(items); 

            // Print Result
            Console.Write("Result { ");
            for(int i = 0 ; i < result.GetLength(0); i++){
              Console.Write("{" + result[i,0] + "," + result[i,1] + "} ");
            }
            Console.Write("} ");
        }
    }
}

