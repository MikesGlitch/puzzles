var file = File.ReadAllText("./data.txt");
var pairs = file.Split(Environment.NewLine);

public int Part1() {
    var numberOfDuplicates = 0;
    foreach (var pair in pairs) {
        var elfs = pair.Split(",");
        var firstElfRange = elfs[0].Split("-");
        var secondElfRange = elfs[1].Split("-");
        var firstElfContainsSecond = (int.Parse(firstElfRange[0]) <= int.Parse(secondElfRange[0])) && int.Parse(firstElfRange[1]) >= int.Parse(secondElfRange[1]);
        var secondElfContainsFirst = (int.Parse(secondElfRange[0]) <= int.Parse(firstElfRange[0])) && int.Parse(secondElfRange[1]) >= int.Parse(firstElfRange[1]);
        if (firstElfContainsSecond || secondElfContainsFirst) {
            numberOfDuplicates++;
        }
    }

    return numberOfDuplicates;
}

public int Part2() {
    var numberOfOverlaps = 0;
    foreach (var pair in pairs) {
        var elfs = pair.Split(",");
        var firstElfRange = elfs[0].Split("-");
        var secondElfRange = elfs[1].Split("-");
        var firstElfContainsSecond = (int.Parse(firstElfRange[0]) <= int.Parse(secondElfRange[0])) && int.Parse(firstElfRange[1]) >= int.Parse(secondElfRange[0]);
        var secondElfContainsFirst = (int.Parse(secondElfRange[0]) <= int.Parse(firstElfRange[0])) && int.Parse(secondElfRange[1]) >= int.Parse(firstElfRange[0]);
        if (firstElfContainsSecond || secondElfContainsFirst) {
            numberOfOverlaps++;
        }
    }

    return numberOfOverlaps;
}

Console.WriteLine($"Part 1: {Part1()}");
Console.WriteLine($"Part 2: {Part2()}");
