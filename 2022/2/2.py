moves = {
    "X": 1,
    "Y": 2,
    "Z": 3
}
    
gamePoints = {
    "lose": 0,
    "draw": 3,
    "win": 6,
}

outcomes = {
  "A X": gamePoints["draw"],
  "A Y": gamePoints["win"],
  "A Z": gamePoints["lose"],
  "B X": gamePoints["lose"],
  "B Y": gamePoints["draw"],
  "B Z": gamePoints["win"],
  "C X" : gamePoints["win"],
  "C Y" : gamePoints["lose"],
  "C Z" : gamePoints["draw"],
}

part2MoveMap = {
  "A X": "Z",
  "A Y": "X",
  "A Z": "Y",
  "B X": "X",
  "B Y": "Y",
  "B Z": "Z",
  "C X" : "Y",
  "C Y" : "Z",
  "C Z" : "X",
}

data = open('C://Users/PandaMan/Desktop/advent/2/data.txt', 'r').read()

def part1():
    rounds = data.split('\n')
    score = 0
    for round in rounds:
        roundMoves = round.split()
        myMove = roundMoves[1]
        myMovePoints = moves[myMove]
        score += myMovePoints + outcomes[round]
    print(score)

    
def part2():
    rounds = data.split('\n')
    score = 0
    for round in rounds:
        roundMoves = round.split()
        theirMove = roundMoves[0]
        myMove = part2MoveMap[round]
        myMovePoints = moves[myMove]
        score += myMovePoints + outcomes[f"{theirMove} {myMove}"]
    print(score)

part1()
part2()