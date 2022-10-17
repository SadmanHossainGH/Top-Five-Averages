# Top-Five-Averages
            # Goal: Given list of [id, score] sublists, return
            # the average of the top 5 scores for each id in list in increasing order
            # Assuming id and score are ints as dictated in examples

            # Constraints
            # 1 <= items.length <= 1000
            # items[i].length == 2
            # 1 <= IDi <= 1000
            # 0 <= scorei <= 100
            # For each IDi, there will be at least five scores

            # Things to Consider
            # have to keep track of ids we previously encountered
            # have to keep track of the number of times an id was encountered
            # need to continously keep track of the minimum of the id's top 5 scores 
