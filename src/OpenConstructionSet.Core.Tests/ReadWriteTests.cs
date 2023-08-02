namespace OpenConstructionSet.Core.Tests;

public class ReadWriteTests
{
    const string Folder = @"C:\Program Files (x86)\Steam\steamapps\common\Kenshi\";
    const string GameData = @"data\gameData.base";
    const string F = @"mods\f\f.mod";

    [Theory]
    [InlineData(GameData)]
    [InlineData(F)]
    public void LoadAndSave(string inputFile)
    {
        var inputPath = Folder + inputFile;
        var outputPath = Path.GetTempFileName();

        using (var reader = new OcsReader(File.OpenRead(inputPath)))
        using (var writer = new OcsWriter(File.Create(outputPath)))
        {
            var dataFile = reader.ReadData();

            writer.Write(dataFile);
        }

        var inputData = File.ReadAllBytes(inputPath);
        var outputData = File.ReadAllBytes(outputPath);

        Assert.Equal(inputData, outputData);

        File.Delete(outputPath);
    }
}