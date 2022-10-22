
public static class MySharedData 
{
    private static int score = -1; //test value as no one will have a negative score
    private static string name = "Test";
    private static int intermediate_score = 0;
    public static int GetCurrentScore()
    {
        return score;
    }
    public static string GetName()
    {
        return name;
    }

    public static void SetName(string new_name)
    {
        name = new_name;
    }
    public static void SetScore(int new_score)
    {
        score = new_score;
    }
    public static void SetIntermediateScore(int new_score)
    {
        intermediate_score = new_score;
    }

    public static int GetIntermediateScore()
    {
        return intermediate_score;
    }


}
