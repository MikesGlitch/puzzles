var lines = File.ReadAllLines("./data.txt");

public record Coords (int X, int Y);

public int Part1() {
    var currentHeadPosition = new Coords(0, 0);
    var tailPositions = new List<Coords>(){ new Coords(0, 0) };

    foreach (var line in lines) {
        var parts = line.Split(" ");
        var direction = parts[0];
        var numberOfMoves = int.Parse(parts[1]);

        for (var move = 1; move <= numberOfMoves; move ++) {
            var headAndTailOnDifferentYAxis = currentHeadPosition.Y != tailPositions.Last().Y;
            var headAndTailOnDifferentXAxis = currentHeadPosition.X != tailPositions.Last().X;

            switch(direction) {
                case "L": 
                    currentHeadPosition = new Coords(currentHeadPosition.X - 1, currentHeadPosition.Y);
                    var headTooFarLeft = currentHeadPosition.X - tailPositions.Last().X == -2;
                    if (headAndTailOnDifferentYAxis && headTooFarLeft) {
                        // Move y and x axis position
                        tailPositions.Add(new Coords(tailPositions.Last().X - 1, currentHeadPosition.Y));
                    } else if (headTooFarLeft) {
                        // tail is too far away from the head, move it closer to the left
                        tailPositions.Add(new Coords(tailPositions.Last().X - 1, tailPositions.Last().Y));
                    }
                    break;
                case "R": 
                    currentHeadPosition = new Coords(currentHeadPosition.X + 1, currentHeadPosition.Y);
                    var headTooFarRight = currentHeadPosition.X - tailPositions.Last().X == 2;
                    if (headAndTailOnDifferentYAxis && headTooFarRight) {
                        // Move y and x axis position
                        tailPositions.Add(new Coords(tailPositions.Last().X + 1, currentHeadPosition.Y));
                    } else if (headTooFarRight) {
                        // tail is too far away from the head, move it closer to the right
                        tailPositions.Add(new Coords(tailPositions.Last().X + 1, tailPositions.Last().Y));
                    }

                    break;
                case "U": 
                    currentHeadPosition = new Coords(currentHeadPosition.X, currentHeadPosition.Y + 1);
                    var headTooFarUp = currentHeadPosition.Y - tailPositions.Last().Y == 2;
                    if (headAndTailOnDifferentXAxis && headTooFarUp) {
                        // Move y and x axis position
                        tailPositions.Add(new Coords(currentHeadPosition.X, tailPositions.Last().Y + 1));
                    } else if (headTooFarUp) {
                        // tail is too far away from the head, move it closer to the right
                        tailPositions.Add(new Coords(tailPositions.Last().X, tailPositions.Last().Y + 1));
                    }
                    break;
                case "D": 
                    currentHeadPosition = new Coords(currentHeadPosition.X, currentHeadPosition.Y - 1);
                    var headTooFarDown = currentHeadPosition.Y - tailPositions.Last().Y == -2;
                    if (headAndTailOnDifferentXAxis && headTooFarDown) {
                        // Move y and x axis position
                        tailPositions.Add(new Coords(currentHeadPosition.X, tailPositions.Last().Y - 1));
                    } else if (headTooFarDown) {
                        // tail is too far away from the head, move it closer to the right
                        tailPositions.Add(new Coords(tailPositions.Last().X, tailPositions.Last().Y - 1));
                    }
                    break;
            }
        }
    }

    return tailPositions.GroupBy((position) => $"{position.X} {position.Y}").Count(); // group to remove the duplicates
}

Console.WriteLine($"Part 1: {Part1()}");
