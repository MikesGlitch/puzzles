public abstract record Node(string Name, DirectoryNode Parent) {
        public abstract int GetTotalSizeBytes();
}

public record DirectoryNode(string Name, DirectoryNode Parent, List<Node> Nodes): Node(Name, Parent) {
    public override int GetTotalSizeBytes() {
        var totalBytes = 0;

        foreach (var node in Nodes) {
            totalBytes += node.GetTotalSizeBytes();
        }

        return totalBytes;
    }
}

public record FileNode(string Name, DirectoryNode Parent, int SizeBytes): Node(Name, Parent) {

    public override int GetTotalSizeBytes() => SizeBytes;
}

private Boolean IsCommand(string line) => line.StartsWith("$");

private Node GetNodeListing(string line, DirectoryNode currentDirectory) {
    if (line.StartsWith("dir")) {
        var directoryName = line.Split(" ")[1];
        return new DirectoryNode(directoryName, currentDirectory, new List<Node>());
    } else if (int.TryParse(line.Split(" ")[0], out var numberOfBytes)) {
        var fileName = line.Split(" ")[1];
        return new FileNode(fileName, currentDirectory, numberOfBytes);
    }

    throw new Exception($"Unknown input in line: ${line}");
}


public int GetTotalDirectoryBytesUnderX(int x, DirectoryNode directory) {
    var totalBytes = 0;
    var totalSizeOfDirectory = directory.GetTotalSizeBytes();
    if (totalSizeOfDirectory <= x) {
        totalBytes += totalSizeOfDirectory;
    }

    foreach (DirectoryNode childNode in directory.Nodes.Where((node) => node is DirectoryNode)) {
        totalBytes += GetTotalDirectoryBytesUnderX(x, childNode);
    }

    return totalBytes;
}

public List<int> GetSizeOfSmallestDirectoriesOverSizeX(int x, DirectoryNode directory) {
    var directoriesSizesOverSizeX = new List<int>();
    var totalSizeOfDirectory = directory.GetTotalSizeBytes();
    if (totalSizeOfDirectory >= x) {
        directoriesSizesOverSizeX.Add(totalSizeOfDirectory);
    }

    foreach (DirectoryNode childNode in directory.Nodes.Where((node) => node is DirectoryNode)) {
        if (totalSizeOfDirectory >= x) {
            directoriesSizesOverSizeX.AddRange(GetSizeOfSmallestDirectoriesOverSizeX(x, childNode));
        }
    }

    return directoriesSizesOverSizeX;
}

private DirectoryNode SetupNodes() {    
    var lines = File.ReadAllLines("./data.txt");
    var rootNode = new DirectoryNode("/", null, new List<Node>()); // file system needs at least a root node
    DirectoryNode currentNode = null;

    foreach (var line in lines) {
        if (IsCommand(line)) {
            var commandParts = line.Split(" ");
            var commandText = commandParts[1];
            switch (commandText) {
                case "cd":
                    switch (commandParts[2]) {
                        case "/": 
                            currentNode = rootNode;
                            break;
                        case "..": 
                            currentNode = currentNode.Parent;
                            break;
                        default: 
                            // move into a directory
                            currentNode = (DirectoryNode)currentNode.Nodes.Single((node) => node is DirectoryNode && node.Name == commandParts[2]);
                            break;
                    }
                    break;
                case "ls": break;
            }
        } else {
            // ls output
            var listItem = GetNodeListing(line, currentNode);
            currentNode.Nodes.Add(listItem);
        }
    }

    return rootNode;
}

private int Part1() {
    var rootNode = SetupNodes();
    var sizeLimit = 100000;
    return GetTotalDirectoryBytesUnderX(sizeLimit, rootNode);
}

private int Part2() {
    var rootNode = SetupNodes();
    var totalDiskSpace = 70000000;
    var updateSize = 30000000;
    var usedSpace = rootNode.GetTotalSizeBytes();
    var unusedSpaced = totalDiskSpace - usedSpace;
    var totalSpaceNeeded = updateSize - unusedSpaced;
    var availableDirectoriesToDelete = GetSizeOfSmallestDirectoriesOverSizeX(totalSpaceNeeded, rootNode);
    var sorted = availableDirectoriesToDelete.OrderBy(x => x);
    return sorted.First();
}

Console.WriteLine($"Part 1: {Part1()}");
Console.WriteLine($"Part 2: {Part2()}");
