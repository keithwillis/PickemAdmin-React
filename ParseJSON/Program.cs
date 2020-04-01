using System;

namespace ParseJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read entire contents of Skilldata.txt
            System.IO.StreamReader file =
    new System.IO.StreamReader(@"c:\test.txt");
            while ((string line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
            }

            file.Close();

            //Replace ],[ with ]\n[
            //Replace [[ with [\n[
            //Replace ]] with ]\n]
            //Save the file

            //Read the file line by line and ignore the first and last item
            //Key:  SkillEn, EffectEn, GroupID, LevelCap, MaxCD, <nothing>, special1, special2, special3, special4, special5, special6, special7, special8

        }
    }
}
