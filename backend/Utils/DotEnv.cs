namespace backend.Utils;

public static class DotEnv
{
    public static void Load(string filename)
    {
        if (!File.Exists(filename))
            return;

        foreach (var line in File.ReadAllLines(filename))
        {
            var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) continue;
            Environment.SetEnvironmentVariable(parts[0], parts[1]); 
        }
    }
}