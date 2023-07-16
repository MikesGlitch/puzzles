import string

data = open('data.txt', 'r').read()

def getItemPriority(letter):
    return string.ascii_letters.index(letter) + 1

def part1():
    rucksacks = data.split('\n')
    allRucksacksPriorityTotal = 0
    for rucksack in rucksacks:
        midPoint = len(rucksack) // 2
        compartment1 = rucksack[0 : midPoint]
        compartment2 = rucksack[midPoint : len(rucksack)]

        checkedChars = []
        rucksackPriorityTotal = 0
        for char in list(compartment1):
            if char in compartment2 and char not in checkedChars:
                checkedChars.append(char)
                rucksackPriorityTotal += getItemPriority(char)

        allRucksacksPriorityTotal += rucksackPriorityTotal
    
    print(allRucksacksPriorityTotal)

def part2():
    rucksacks = data.split('\n')
    allGroupRucksacksPriorityTotal = 0
    currentGroup = []
    for rucksack in rucksacks:
        currentGroup.append(rucksack)
        if len(currentGroup) == 3:
            ## have all rucksacks of the group - calculate then clear for next group
            firstElfRucksack = currentGroup[0]
            checkedItems = []
            groupRucksacksPriorityTotal = 0
            for item in list(firstElfRucksack):
                if item not in checkedItems and item in currentGroup[1] and item in currentGroup[2]:
                    checkedItems.append(item)
                    groupRucksacksPriorityTotal += getItemPriority(item)
            
            allGroupRucksacksPriorityTotal += groupRucksacksPriorityTotal
            currentGroup = []
    
    print(allGroupRucksacksPriorityTotal)

part1()
part2()