
dataLines = open('data.txt', 'r').read().splitlines()
treeGrid = []

for idx, line in enumerate(dataLines):
    treeGrid.append(list(line))

def isTreeVisibleFromTop(treeGrid, currentTreeLineIndex, currentTreeIndex):
    currentTree = treeGrid[currentTreeLineIndex][currentTreeIndex]
    visible = False
    remainingTreeLinesToCheck = range(currentTreeLineIndex - 1, -1, -1)
    for treeLineIndex in remainingTreeLinesToCheck:
        if treeGrid[treeLineIndex][currentTreeIndex] < currentTree:
            visible = True
        else:
            visible = False
            break

    return visible

def countTreesVisibleFromTop(treeGrid, currentTreeLineIndex, currentTreeIndex):
    currentTree = treeGrid[currentTreeLineIndex][currentTreeIndex]
    count = 0
    remainingTreeLinesToCheck = range(currentTreeLineIndex - 1, -1, -1)
    for treeLineIndex in remainingTreeLinesToCheck:
        if treeGrid[treeLineIndex][currentTreeIndex] < currentTree:
            count += 1
        else:
            count += 1
            break

    return count

def isTreeVisibleFromRight(treeGrid, currentTreeLineIndex, currentTreeIndex):
    currentTree = treeGrid[currentTreeLineIndex][currentTreeIndex]
    visible = False
    
    remainingTreesToCheck = range(currentTreeIndex + 1, len(treeGrid[currentTreeLineIndex]))
    for treeIndex in remainingTreesToCheck:
        if treeGrid[currentTreeLineIndex][treeIndex] < currentTree:
            visible = True
        else:
            visible = False
            break

    return visible


def countTreesVisibleFromRight(treeGrid, currentTreeLineIndex, currentTreeIndex):
    currentTree = treeGrid[currentTreeLineIndex][currentTreeIndex]
    count = 0
    
    remainingTreesToCheck = range(currentTreeIndex + 1, len(treeGrid[currentTreeLineIndex]))
    for treeIndex in remainingTreesToCheck:
        if treeGrid[currentTreeLineIndex][treeIndex] < currentTree:
            count +=1
        else:
            count +=1
            break

    return count

def isTreeVisibleFromBottom(treeGrid, currentTreeLineIndex, currentTreeIndex):
    currentTree = treeGrid[currentTreeLineIndex][currentTreeIndex]
    visible = False
    
    remainingTreesLinesToCheck = range(currentTreeLineIndex + 1, len(treeGrid))
    for treeLineIndex in remainingTreesLinesToCheck:
        if treeGrid[treeLineIndex][currentTreeIndex] < currentTree:
            visible = True
        else:
            visible = False
            break

    return visible

def countTreesVisibleFromBottom(treeGrid, currentTreeLineIndex, currentTreeIndex):
    currentTree = treeGrid[currentTreeLineIndex][currentTreeIndex]
    count = 0
    
    remainingTreesLinesToCheck = range(currentTreeLineIndex + 1, len(treeGrid))
    for treeLineIndex in remainingTreesLinesToCheck:
        if treeGrid[treeLineIndex][currentTreeIndex] < currentTree:
            count += 1
        else:
            count += 1
            break

    return count

def isTreeVisibleFromLeft(treeGrid, currentTreeLineIndex, currentTreeIndex):
    currentTree = treeGrid[currentTreeLineIndex][currentTreeIndex]
    visible = False
    
    remainingTreesToCheck = range(currentTreeIndex - 1, -1, -1)
    for treeIndex in remainingTreesToCheck:
        if treeGrid[currentTreeLineIndex][treeIndex] < currentTree:
            visible = True
        else:
            visible = False
            break

    return visible

def countTreesVisibleFromLeft(treeGrid, currentTreeLineIndex, currentTreeIndex):
    currentTree = treeGrid[currentTreeLineIndex][currentTreeIndex]
    count = 0
    
    remainingTreesToCheck = range(currentTreeIndex - 1, -1, -1)
    for treeIndex in remainingTreesToCheck:
        if treeGrid[currentTreeLineIndex][treeIndex] < currentTree:
            count += 1
        else:
            count += 1
            break

    return count

def part1():
    visibleTreeCount = 0
    for treeLineIndex, treeLine in enumerate(treeGrid):
        if (treeLineIndex == 0 or treeLineIndex == len(treeGrid) - 1):
            visibleTreeCount += len(treeLine) # Add edge trees to the visible count
            continue

        for treeIndex, tree in enumerate(treeLine):
            if(treeIndex == 0 or treeIndex == len(treeLine) -1):
                visibleTreeCount += 1 # Add edge tree to the visible count
                continue

            if (isTreeVisibleFromTop(treeGrid, treeLineIndex, treeIndex)):
                visibleTreeCount += 1
            elif (isTreeVisibleFromRight(treeGrid, treeLineIndex, treeIndex)):
                visibleTreeCount += 1
            elif (isTreeVisibleFromBottom(treeGrid, treeLineIndex, treeIndex)):
                visibleTreeCount += 1
            elif (isTreeVisibleFromLeft(treeGrid, treeLineIndex, treeIndex)):
                visibleTreeCount += 1

    return visibleTreeCount

def part2():
    scenicScores = []
    for treeLineIndex, treeLine in enumerate(treeGrid):
        if (treeLineIndex == 0 or treeLineIndex == len(treeGrid) - 1):
            continue

        for treeIndex, tree in enumerate(treeLine):
            if(treeIndex == 0 or treeIndex == len(treeLine) -1):
                continue

            topCount = countTreesVisibleFromTop(treeGrid, treeLineIndex, treeIndex)
            rightCount = countTreesVisibleFromRight(treeGrid, treeLineIndex, treeIndex)
            bottomCount = countTreesVisibleFromBottom(treeGrid, treeLineIndex, treeIndex)
            leftCount = countTreesVisibleFromLeft(treeGrid, treeLineIndex, treeIndex)
            scenicScores.append(topCount * rightCount * leftCount * bottomCount)

    scenicScores.sort(reverse=True)
    return scenicScores[0]

print(f"Part 1: {part1()}")
print(f"Part 2: {part2()}")