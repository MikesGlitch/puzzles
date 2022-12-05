import copy

# Cheated a bit here - didnt want to write a parser
stackDataRaw = [
    ["F", "T", "C", "L", "R", "P", "G", "Q"],
    ["N", "Q", "H", "W", "R", "F", "S", "J"],
    ["F", "B", "H", "W", "P", "M", "Q"],
    ["V", "S", "T", "D", "F",],
    ["Q", "L", "D", "W", "V", "F", "Z"],
    ["Z", "C", "L", "S"],
    ["Z", "B", "M", "V", "D", "F"],
    ["T", "J", "B"],
    ["Q", "N", "B", "G", "L", "S", "P", "H"],
]

moves = open('moves-data.txt', 'r').read().split("\n")

def printOutput(stackData): 
    letters = []
    for item in stackData:
        if item:
            letters.append(item[len(item) - 1])
    print(''.join(letters))

def part1(stackData):
    for move in moves:
        moveParts = move.split(" ")
        numItemsToMove = int(moveParts[1])
        fromIndex = int(moveParts[3]) - 1
        toIndex = int(moveParts[5]) - 1
        for _ in range(numItemsToMove):
            item = stackData[fromIndex].pop()
            stackData[toIndex].append(item)
    printOutput(stackData)

def part2(stackData):
    for move in moves:
        moveParts = move.split(" ")
        numItemsToMove = int(moveParts[1])
        fromIndex = int(moveParts[3]) - 1
        toIndex = int(moveParts[5]) - 1
        poppedItems = []
        for _ in range(numItemsToMove):
            poppedItems.append(stackData[fromIndex].pop())
        for _ in range(len(poppedItems)):
            stackData[toIndex].append(poppedItems.pop())

    printOutput(stackData)

part1(copy.deepcopy(stackDataRaw))
part2(copy.deepcopy(stackDataRaw))
