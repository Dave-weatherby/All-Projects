def main():
    startData = [100, 2, 323, 66, 65, 67, 99, 27, 212, 8]
    sortedData = []
    # main for loop
    for y in range(0, 10):
        largest = 0
        # sorting from largest to smallest
        for x in range(0, 10):
            if startData[x] > largest and startData[x] != -1:
                largest = startData[x]
                Index = x
        # appending new order to new list
        sortedData.append(largest)
        startData[Index] = -1
    # printing loop
    for n in range(0, 10):
        print(sortedData[n])

main()
